using _278Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _278Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserModel user)
        {
            using (var db = new EmployeeContext())
            {
                foreach (var tempuser in db.Users)
                {
                    if (tempuser.UserName == user.UserName && tempuser.Password == user.Password)
                    {
                        tempuser.Enabled = true;
                        db.SaveChanges();
                        return View("Index");
                    }

                }
            }
            return View("Index");
        }

        public IActionResult SignOutU()
        {
            using (var db = new EmployeeContext())
            {
                foreach (var tempuser in db.Users)
                {
                    if (tempuser.Enabled==true)
                    {
                        tempuser.Enabled = false;
                        db.SaveChanges();
                        return View("Index");
                    }

                }
            }
            return View("Index");
        }
    }
}