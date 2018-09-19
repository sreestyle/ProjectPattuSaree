using System.Web.Http;
using ProjectNewsApp.Mapping;

namespace ProjectNewsApp
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //// Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}