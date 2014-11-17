using EntityReloadingModelBinding.Models;
using System.Net;
using System.Web.Mvc;

namespace EntityReloadingModelBinding.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
            : base(new Repo())
        { }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int id)
        { 
            var entity = this.repo
                             .Get<Entity>(id);

            var vm = new VMEntity(entity);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Get(VMEntity vm)
        {
            this.repo.Save(vm.Entity);

            if (this.RouteData.Values["id"] == null)
                return RedirectToAction("Get", new { id = vm.Entity.Id });

            return View(vm);
        }
    }
}