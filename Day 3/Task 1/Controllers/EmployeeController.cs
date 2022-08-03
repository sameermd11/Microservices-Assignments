using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _repos;

        public EmployeeController(IEmployeeRepo repos)
        {
            _repos = repos;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> empList = _repos.GetAllEmployees();
            return View(empList);
        }

        public IActionResult Details(int id)
        {
            Employee empObj = _repos.GetEmployeeByID(id);
            return View(empObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _repos.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _repos.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _repos.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _repos.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repos.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
