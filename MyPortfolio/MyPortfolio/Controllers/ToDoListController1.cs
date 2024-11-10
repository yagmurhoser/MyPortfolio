using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ToDoListController1 : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()
		{
			var values = context.ToDoLists.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateToDoList()
		{
			return View();
		}

		[HttpPost]

		public IActionResult CreateToDoList(ToDoList toDolist)
		{
			toDolist.Status = false;
			context.ToDoLists.Add(toDolist);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteToDoList(int id)
		{
			var value = context.ToDoLists.Find(id);
			context.ToDoLists.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet] 
		public IActionResult UpdateToDoList(int id)
		{
			var value = context.ToDoLists.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateToDoList(ToDoList toDolist)
		{
			context.ToDoLists.Update(toDolist);
			context.SaveChanges();
			return RedirectToAction("Index");

		}

		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = context.ToDoLists.Find(id);
			value.Status = false;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = context.ToDoLists.Find(id);
			value.Status = true;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
