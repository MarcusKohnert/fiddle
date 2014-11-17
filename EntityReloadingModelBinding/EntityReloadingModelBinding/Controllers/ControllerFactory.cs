using System.Web.Mvc;

namespace EntityReloadingModelBinding.Controllers
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Home")
                return new HomeController();

            return base.CreateController(requestContext, controllerName);
        }
    }
}