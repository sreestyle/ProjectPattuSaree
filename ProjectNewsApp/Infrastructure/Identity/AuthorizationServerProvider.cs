using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PattuSaree.Data.Infrastructure;
using PattuSaree.Data.Repositories;
using PattuSaree.Entity;
using PattuSaree.Enums.Constant;
using PattuSaree.Enums.Encryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ProjectNewsApp.Infrastructure.Identity
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                await Task.FromResult(context.Validated());
            }
            catch (Exception ex)
            {

                //var commonexception = new CommonException();
                //commonexception.ExceptionDetails(ex, JsonConvert.SerializeObject(""), _exceptionLogging);
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            try
            {
                foreach (var property in context.Properties.Dictionary)
                {
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
                }
                return Task.FromResult<object>(null);
            }
            catch (Exception ex)
            {

                //var commonexception = new CommonException();
                //commonexception.ExceptionDetails(ex, JsonConvert.SerializeObject(""), _exceptionLogging);
                return Task.FromResult<object>(null);
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                

                //var domain = new LoginViewModel();
                var user = new EntityBaseRepository<UserMaster>(new DbFactory()).FindBy(x => x.Username == context.UserName).FirstOrDefault();

                // validate the credentials
                var isValid = false;
                
                if (user.Username == context.UserName && PattuSareeEncryption.Decrypt(user.HashedPassword) == context.Password)
                        isValid = true;


                var xy = PattuSareeEncryption.Encrypt(context.Password);


                if (!isValid)
                {
                    var x = PattuSareeEncryption.Encrypt(context.Password);
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                //START--Added by Ajitsingh thakur for fetch user Role And user privilege base on role
                var userRole = new EntityReadOnlyBaseRepository<UserRole>(new DbFactory()).FindBy(ur => ur.UserMasterId == user.UserMasterId && ur.IsDeleted == false).Include(ur => ur.Role).FirstOrDefault();

                var multipleUserRole = new EntityReadOnlyBaseRepository<UserRole>(new DbFactory()).FindBy(ur => ur.UserMasterId == user.UserMasterId && ur.IsDeleted == false).Include(ur => ur.Role).ToList();

                string multipleRoleJson = JsonConvert.SerializeObject(multipleUserRole, Formatting.None,new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

               
               

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(PattuSareeConstant.IdentityClaimUserId, user.UserMasterId.ToString()));
                identity.AddClaim(new Claim(PattuSareeConstant.IdentityClaimUserKey, user.KeyId.ToString()));
                identity.AddClaim(new Claim(PattuSareeConstant.IdentityClaimUserName, user.Username));

                identity.AddClaim(new Claim(PattuSareeConstant.IdentityClaimFirstName, user.FirstName));
                identity.AddClaim(new Claim(PattuSareeConstant.IdentityClaimLastName, user.LastName));

                identity.AddClaim(new Claim(ClaimTypes.Role, userRole != null ? userRole.Role.RoleName : "ADMIN"));

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "UserId", user.UserMasterId.ToString() },
                    { "UserRole", userRole!=null? userRole.Role.RoleName:"ADMIN"},
                    { "UserRoleId",userRole?.Role.RoleId.ToString() ?? "14"},
                    { "MultipleRole",multipleRoleJson}
                    

                });

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
                await Task.FromResult(context.Validated(identity));
            }
            catch (Exception ex)
            {
                //var data = context.UserName + "," + context.Password;
                //var commonexception = new CommonException();
                //commonexception.ExceptionDetails(ex, JsonConvert.SerializeObject(data), _exceptionLogging);
            }
        }

        
    }
}