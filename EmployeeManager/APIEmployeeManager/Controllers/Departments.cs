using DBAEmployeeDepartment;
using DTOEmployeeDepartment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIEmployeeManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Departments : ControllerBase
    {
        DBManager dbManager;

        public Departments()
        {
            dbManager = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");
        }

        [HttpGet]
        public List<Department> Get()
        {
            return dbManager.GetDepartments();
        }

        [HttpGet]
        [Route("GetById")]
        public Department GetById(int id)
        {
            return dbManager.GetDepartmentById(id);
        }

        [HttpPost]
        public bool Post(Department department)
        {
            return dbManager.AddDepartment(department);
        }

        [HttpPut]
        public bool Put(Department department)
        {
            return dbManager.UpdateDepartment(department);
        }

        [HttpDelete]
        public bool Delete(int id, bool force = false)
        {
            return dbManager.DeleteDepartment(id, force);
        }
    }
}
