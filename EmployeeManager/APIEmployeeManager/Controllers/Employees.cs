using DBAEmployeeDepartment;
using DTOEmployeeDepartment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIEmployeeManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Employees : ControllerBase
    {
        DBManager dbManager;

        public Employees()
        {
            dbManager = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return dbManager.GetEmployees();
        }

        [HttpGet]
        [Route("GetById")]
        public Employee GetById(int id)
        {
            return dbManager.GetEmployeeById(id);
        }

        [HttpPost]
        public bool Post(Employee employee)
        {
            return dbManager.AddEmployee(employee);
        }

        [HttpPut]
        public bool Put(Employee employee)
        {
            return dbManager.UpdateEmployee(employee);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return dbManager.DeleteEmployee(id);
        }
    }
}
