using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBooking_NewMVC.Models;
using TravelBooking_NewMVC.Repository;

namespace TravelBooking_NewMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        //private readonly ICatagoryRepository _catrepository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _repository.GetEmployees();
            return View(employees);
            
        }
        public IActionResult AddEmployee()
        {
            ViewBag.Employees = new SelectList(_repository.GetEmployees(), "EmpId", "EmpFirst");
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _repository.AddEmoloyee(employee);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployee(int id)
        {
            ViewBag.Categories = new SelectList(_repository.GetEmployees(), "EmpId", "EmpFirstName");
            Employee? employee = _repository.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee, int id)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateEmployee(employee, id);

            }
            return RedirectToAction("Index");
        }
    }
}
