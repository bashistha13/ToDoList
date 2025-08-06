using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoListApp.Controllers
{
    public class ToDoController : Controller
    {
        private static List<ToDoItem> items = new List<ToDoItem>();

        public IActionResult Index()
        {
            return View(items);
        }

        [HttpPost]
        public IActionResult Create(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                items.Add(new ToDoItem { Id = items.Count + 1, Title = title, IsCompleted = false });
            }
            return RedirectToAction("Index");
        }

        public IActionResult ToggleComplete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}