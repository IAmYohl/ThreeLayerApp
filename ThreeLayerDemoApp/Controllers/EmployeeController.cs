using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
//using ThreeLayerDemoApp.Models;

namespace ThreeLayerDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployeesAsync(); //this makes sure the business logic gets processed before returning the view
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await employeeService.AddEmployeeAsync(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await employeeService.GetEmployeeWithIdAsync(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee updEmployee)
        {
            await employeeService.EditEmployeeAsync(updEmployee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employeeDetails = await employeeService.EmployeeDetailsAsync(id);
            return View(employeeDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeeService.GetEmployeeWithIdAsync(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee employeeToDelete)
        {
            await employeeService.DeleteEmployeeAsync(employeeToDelete);
            return RedirectToAction("Index");
        }
    }
}
