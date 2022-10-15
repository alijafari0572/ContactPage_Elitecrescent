using ContactPage_Elitecrescent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ContactPage_Elitecrescent.Repositories;
using DataLayer;
using Entities;

namespace ContactPage_Elitecrescent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContactDbContext _context;
        private readonly ICheckEmail _checkEmail;


        public HomeController(ILogger<HomeController> logger, ContactDbContext context, ICheckEmail checkEmail)
        {
            _logger = logger;
            _context = context;
            _checkEmail = checkEmail;
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
                if (!_checkEmail.CheckValidEmail(contactModel))
                {
                    TempData["message"] = "Email is not valid";
                    return View(contactModel);
                }
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