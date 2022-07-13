using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _278Project.Models;
namespace _278Project.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new EmployeeContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Enabled == true)
                    {

                        return View();
                    }

                }
            }
            return View("~/Views/Home/SignIn.cshtml");
        }

        public IActionResult ReportEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReportEmployee(EmployeeModel employee)
        {
            using (var db = new EmployeeContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Enabled == true)
                    {
                        foreach(var empl in db.Employees)
                        {
                            if (empl.Id == employee.Id)
                            {
                                ViewBag.Employees = empl;
                            }
                        }
                        
                        return View();
                    }

                }
            }
            return View("~/Views/Home/SignIn.cshtml");
        }

        public IActionResult ReportProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReportProject(ProjectModel project)
        {
            using (var db = new EmployeeContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Enabled == true)
                    {
                        foreach (var proj in db.Projects)
                        {
                            if (proj.Id == project.Id)
                            {
                                ViewBag.Project = proj;
                            }
                        }
                        List<EmployeeModel> employees = new List<EmployeeModel>();
                        foreach (var empl in db.Employees)
                        {
                            if (empl.ProjectId == project.Id)
                            {
                                employees.Add(empl);
                            }
                        }
                        ViewBag.Employees = employees;

                        return View();
                    }

                }
            }
            return View("~/Views/Home/SignIn.cshtml");
        }
    }
}
