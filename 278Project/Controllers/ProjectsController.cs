using Microsoft.AspNetCore.Mvc;
using _278Project.Models;
namespace _278Project.Controllers
{
    public class ProjectsController : Controller
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
        public IActionResult AddProject()
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
        public IActionResult AddProject(ProjectModel project)
        {
            using (var db = new EmployeeContext())
            {
                db.Add(project);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ListProjects()
        {
            using (var db = new EmployeeContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Enabled == true)
                    {
                        List<ProjectModel> projects = new List<ProjectModel>();
                        projects = db.Projects.ToList();
                        ViewBag.Projects = projects;
                        return View();
                    }

                }
            }
            return View("~/Views/Home/SignIn.cshtml");
            
        }
        public IActionResult FinishProject(ProjectModel dproject)
        {
            using (var db = new EmployeeContext())
            {
                var project = db.Projects.Where(p => p.Id == dproject.Id).FirstOrDefault();
                var employees = db.Employees.Where(e => e.ProjectId == dproject.Id).ToList();
                foreach(var emp in employees)
                {
                    emp.ProjectId = 0;
                    emp.Status = "UnAssigned";
                }
                project.Status = "Finished";
                db.SaveChanges();
            }
            return RedirectToAction("ListProjects");
        }
    }
}
