using System.Diagnostics;
using E04RepetitionDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace E04RepetitionDatabase.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbContext _context;

    public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var notes = _context.Notes.AsEnumerable();
        
        return View(notes);
    }
    
    public IActionResult Create()
    {
        return View(new Note());
    }

    [HttpPost]
    public IActionResult Create(Note note)
    {
        _context.Notes.Add(note);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult Delete(Guid noteId)
    {
        Note? note = _context.Notes.Find(noteId);
        if (note == null)
        {
            throw new Exception("Note not found");
        }
        
        _context.Notes.Remove(note);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
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
}
