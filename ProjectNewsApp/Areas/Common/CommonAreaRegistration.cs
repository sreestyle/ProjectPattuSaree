using System.Web.Mvc;

namespace ProjectNewsApp.Areas.Common
{
    public class CommonAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Common";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Common_default",
                "Common/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}