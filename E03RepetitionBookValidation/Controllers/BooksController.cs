using Microsoft.AspNetCore.Mvc;
using E03RepetitionBookValidation.Models;

namespace E03RepetitionBookValidation.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Book book)
        {
            if (book.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Year must be less than or equal to " + DateTime.Now.Year);
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine(book.ToString());
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}