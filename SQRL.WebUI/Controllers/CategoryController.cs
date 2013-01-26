using System.Web.Mvc;
using SQRL.DataAccess.Abstract;

namespace SQRL.WebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _repository;

		public CategoryController(ICategoryRepository repository)
		{
			_repository = repository;
		}
		//
		// GET: /Category/

		public ActionResult List()
		{
			return View(_repository.Categories);
		}
	}
}
