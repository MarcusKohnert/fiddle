using EntityReloadingModelBinding.Models;
using System.Net;
using System.Web.Mvc;

namespace EntityReloadingModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int id)
        { 
            var repo = new Repo();
            var entity = repo.Get<Entity>(id);
            var vm = new VMEntity(entity);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Get(VMEntity vm)
        {
            var repo = new Repo();
            repo.Save(vm.Entity);

            if (this.RouteData.Values["id"] == null)
                return RedirectToAction("Get", new { id = vm.Entity.Id });

            return View(vm);
        }
    }
}