using Microsoft.AspNetCore.Mvc;
using _278Project.Models;
namespace _278Project.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new EmployeeContext())
            {
                foreach(var user in db.Users)
                {
                    if (user.Enabled == true)
                    {
                        return View();
                    }

                }
            }
            return View("~/Views/Home/SignIn.cshtml");
        }
        public IActionResult AddEmployee()
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
        public IActionResult AddEmployee(EmployeeModel employee)
        {   
            using (var db = new EmployeeContext())
            {
                db.Add(employee);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ListEmployees()
        {
            using (var db = new EmployeeContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.Enabled == true)
                    {
                        List<EmployeeModel> employees = new List<EmployeeModel>();
                        employees = db.Employees.ToList();
                        ViewBag.Employees = employees;
                        return View();
                    }

                }
            }
            return View("~/Views/Home/SignIn.cshtml");
            
        }


        public IActionResult DeleteEmployee(EmployeeModel demployee)
        {
            var employee = new EmployeeModel() { Id = demployee.Id };
            using(var db = new EmployeeContext())
            {
                db.Attach(employee);
                db.Remove(employee);
                db.SaveChanges();
            }
            return RedirectToAction("ListEmployees");
        }

        public IActionResult UpdateSalary()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSalary(EmployeeModel uemployee)
        {
            using (var db = new EmployeeContext())
            {
                foreach(var employee in db.Employees)
                {
                    if (employee.Id == uemployee.Id)
                    {
                        employee.Salary = uemployee.Salary;
                        db.SaveChanges();
                        return View("Index");
                    }
                }
            }
            return View();
        }
    }
}
