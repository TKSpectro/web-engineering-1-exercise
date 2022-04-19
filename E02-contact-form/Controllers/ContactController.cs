using E02_contact_form.Models;
using Microsoft.AspNetCore.Mvc;

namespace E02_contact_form.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Title = "Contact";
        return View(new ContactForm());
    }

    [HttpPost]
    public IActionResult Index(ContactForm model)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Title = "Details";
            return View("Details", model);
        }
        else
        {
            ViewBag.Title = "Contact";
            return View(new ContactForm());
        }

    }
}