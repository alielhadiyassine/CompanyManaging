using Microsoft.AspNetCore.Mvc;
using _278Project.Models;

namespace _278Project.Controllers
{
    public class MatchingController : Controller
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

        [HttpPost]
        public IActionResult Index(MatchingModel matching)
        {
            using (var db = new EmployeeContext())
            {
                
                var employee = db.Employees.Where(e => e.Id == matching.empId).FirstOrDefault();
                if (employee.Status == "UnAssigned")
                {
                    var project = db.Projects.Where(p => p.Id == matching.projId).FirstOrDefault();
                    if (project.Status == "UnAssigned")
                    {
                        project.Status = "Assigned";
                    }
                    else if (project.Status == "Finished")
                    {
                        return View();
                    }
                    employee.Status = "Assigned";
                    employee.ProjectId = matching.projId;
                    db.Add(matching);
                }
                db.SaveChanges();
            }

            return View();
        }
    }
}
