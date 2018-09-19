using PattuSaree.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PattuSaree.ViewModel;

namespace ProjectNewsApp.Areas.Common.Controllers
{
    [RoutePrefix("api/common")]
    public class SingUpController : ApiController
    {
        private readonly ISignUpService _iSignUpService;

        public SingUpController(ISignUpService iSignUpService)
        {
            _iSignUpService = iSignUpService;
        }

        [HttpPost]
        [Route("singup")]
        public void SingUp(UserMasterViewModel userVm)
        {
            _iSignUpService.SingUp(userVm);
        }
       
    }
}
