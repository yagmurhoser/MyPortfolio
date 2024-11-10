using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			var values = context.ToDoLists.Where(x => x.Status == false).ToList();
			ViewBag.toDoListCount = context.ToDoLists.Where(x => x.Status == false).Count();
			return View(values);
		}
	}
}
