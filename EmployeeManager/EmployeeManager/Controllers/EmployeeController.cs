using DTOEmployeeDepartment;
using EmployeeManager.ApiAccess;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private const string baseEmployeeURL = "https://localhost:44393/Employees";

        private readonly ILogger<HomeController> _logger;

        public EmployeeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ApiEmployees api = new ApiEmployees();

            return View(api.GetAll());
        }

        public IActionResult Create()
        {
            ApiDepartments apiDepartment = new ApiDepartments();

            ViewBag.Departments = apiDepartment.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult ConfirmCreate(Employee employee)
        {
            ApiEmployees api = new ApiEmployees();

            if(api.Add(employee))
            {
                return Redirect("~/Employee/Index");
            }

            return Redirect("~/Employee/Create");
        }

        public IActionResult Edit(int id)
        {
            ApiDepartments apiDepartment = new ApiDepartments();

            ViewBag.Departments = apiDepartment.GetAll();

            ApiEmployees api = new ApiEmployees();

            Employee employee = api.GetById(id);

            if(employee != null)
            {
                return View(employee);
            }

            return Redirect("~/Employee/Index");
        }

        [HttpPost]
        public IActionResult ConfirmEdit(Employee employee)
        {
            ApiEmployees api = new ApiEmployees();

            if(api.Edit(employee))
            {
                return Redirect("~/Employee/Index");
            }
           
            return Redirect($"~/Employee/Edit/{employee.Id}");
        }

        public IActionResult Delete(int id)
        {

            ApiDepartments apiDepartment = new ApiDepartments();

            ViewBag.Departments = apiDepartment.GetAll();

            ApiEmployees api = new ApiEmployees();

            Employee employee = api.GetById(id);

            if (employee != null)
            {
                return View(employee);
            }

            return Redirect("~/Employee/Index");
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            ApiDepartments apiDepartment = new ApiDepartments();

            ViewBag.Departments = apiDepartment.GetAll();

            ApiEmployees api = new ApiEmployees();

            if (api.Delete(id))
            {
                return Redirect("~/Employee/Index");
            }

            return Redirect($"~/Employee/Delete/{id}");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
