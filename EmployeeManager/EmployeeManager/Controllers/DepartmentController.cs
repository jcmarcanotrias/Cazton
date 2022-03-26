using DTOEmployeeDepartment;
using EmployeeManager.ApiAccess;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace EmployeeManager.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DepartmentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ApiDepartments api = new ApiDepartments();

            return View(api.GetAll());
        }

        public IActionResult ListAll()
        {
            ApiDepartments api = new ApiDepartments();

            List<Department> departments = api.GetAll();

            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmCreate(Department department)
        {
            ApiDepartments api = new ApiDepartments();

            if (api.Add(department))
            {
                return Redirect("~/Department/Index");
            }

            return Redirect("~/Department/Create");
        }

        public IActionResult Edit(int id)
        {
            ApiDepartments api = new ApiDepartments();

            Department department = api.GetById(id);

            if (department != null)
            {
                return View(department);
            }

            return Redirect("~/Department/Index");
        }

        [HttpPost]
        public IActionResult ConfirmEdit(Department department)
        {
            ApiDepartments api = new ApiDepartments();

            if (api.Edit(department))
            {
                return Redirect("~/Department/Index");
            }

            return Redirect($"~/Department/Edit/{department.Id}");
        }

        public IActionResult Delete(int id)
        {
            ApiDepartments api = new ApiDepartments();

            Department department = api.GetById(id);

            if (department != null)
            {
                return View(department);
            }

            return Redirect("~/Department/Index");
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            ApiDepartments api = new ApiDepartments();

            if (api.Delete(id))
            {
                return Redirect("~/Department/Index");
            }

            return Redirect($"~/Department/Delete/{id}");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
