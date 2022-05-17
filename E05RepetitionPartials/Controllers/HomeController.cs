using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E05RepetitionPartials.Models;

namespace E05RepetitionPartials.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(Books);
    }

    public IActionResult Details(int id)
    {
        var book = Books.Find((b)=> b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        
        return PartialView(book);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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