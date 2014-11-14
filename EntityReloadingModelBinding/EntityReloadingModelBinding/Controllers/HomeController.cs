using EntityReloadingModelBinding.Models;
using System.Web.Mvc;

namespace EntityReloadingModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entity = new Entity();
            var vm = new VMEntity(entity);
            return View(vm);
        }
    }
}