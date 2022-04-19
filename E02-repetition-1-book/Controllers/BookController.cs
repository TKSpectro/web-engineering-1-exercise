using Microsoft.AspNetCore.Mvc;
using E02_repetition_1_book.Models;

namespace E02_repetition_1_book.Controllers;

public class BookController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        ViewBag.Title = "Book List";
        return View(Books);
    }

    public IActionResult Details(int id)
    {
        Book? book = Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        ViewBag.Title = book.Name;
        return View(book);
    }

    private static List<Book> Books => new List<Book>{
        new Book{
            Id = 1,
            Name = "The Lord of the Rings",
            Author = "J.R.R. Tolkien",
            ISBN = "978-0-395-19395-8",
            Published = new DateOnly(1954, 9, 21),
            Edition = 1
        },
        new Book{
            Id = 2,
            Name = "The Hobbit",
            Author = "J.R.R. Tolkien",
            ISBN = "978-0-395-19395-8",
            Published = new DateOnly(1937, 9, 21),
            Edition = 1
        },
        new Book{
            Id = 3,
            Name = "Harry Potter and the Philosopher's Stone",
            Author = "J.K. Rowling",
            ISBN = "978-0-395-19395-8",
            Published = new DateOnly(1997, 9, 21),
            Edition = 1
        },
    };
}

