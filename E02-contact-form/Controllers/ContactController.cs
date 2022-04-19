using System.Net.Mail;
using E02_contact_form.Models;
using Microsoft.AspNetCore.Mvc;

namespace E02_contact_form.Controllers
{

    public class ContactController : Controller
    {
        private readonly IConfiguration configuration;

        public ContactController(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

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
                ViewBag.SentMail = false;

                if (bool.Parse(configuration["smtp:enabled"]))
                {
                    SmtpClient smtp = new SmtpClient(configuration["smtp:host"]);
                    smtp.EnableSsl = bool.Parse(configuration["smtp:enableSsl"]);
                    smtp.Port = int.Parse(configuration["smtp:port"]);
                    smtp.Credentials = new System.Net.NetworkCredential(
                        configuration["smtp:auth:user"], configuration["smtp:auth:pass"]);

                    try
                    {
                        smtp.Send(model.Email, "toaddress@somwhere.com",
                           "Email Subject", $"name:{model.Name}\n email:{model.Email}\n message:{model.Message}");

                        ViewBag.SentMail = true;
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateMessageWithAttachment()", ex.ToString());
                    }
                }

                ViewBag.Title = "Details";
                return View("Details", model);
            }
            else
            {
                ViewBag.Title = "Contact";
                return View(model);
            }
        }
    }
}