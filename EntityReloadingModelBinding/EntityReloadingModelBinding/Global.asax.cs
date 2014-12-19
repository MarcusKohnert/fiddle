using EntityReloadingModelBinding.Controllers;
using EntityReloadingModelBinding.ModelBinder;
using EntityReloadingModelBinding.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace EntityReloadingModelBinding
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(VMEntity), new ViewModelBinder<Entity>());

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}
