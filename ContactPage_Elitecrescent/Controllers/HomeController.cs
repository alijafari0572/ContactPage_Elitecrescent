using ContactPage_Elitecrescent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataLayer;
using Entities;

namespace ContactPage_Elitecrescent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContactDbContext _context;

        public HomeController(ILogger<HomeController> logger, ContactDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact_Model contactModel)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(new Contact()
                {
                    FullName = contactModel.FullName,
                    Email = contactModel.Email,
                    PhoneNumber = contactModel.PhoneNumber,
                    Title = contactModel.Title,
                    Text = contactModel.Text
                });
                _context.SaveChanges();
                TempData["message"] = "Thanks for Feedback!";
                return RedirectToAction("Index", "Home");
            }
            return View(contactModel);
        }
    }
}