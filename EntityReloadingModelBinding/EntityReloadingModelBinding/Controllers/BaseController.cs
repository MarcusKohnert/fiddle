using System.Web.Mvc;
namespace EntityReloadingModelBinding.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly Repo repo;

        public BaseController(Repo repo)
        {
            this.repo = repo;
        }

        public T ReadEntity<T>(int id)
        {
            return this.repo.Get<T>(id);
        }
    }
}