using DTOEmployeeDepartment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManager.ApiAccess
{
    public class ApiEmployees
    {
        private const string baseEmployeesURL = "https://localhost:44393/Employees";

        public List<Employee> GetAll()
        {
            List<Employee> employees;

            using (HttpClient client = new HttpClient())
            {
                employees = JsonConvert.DeserializeObject<List<Employee>>(client.GetStringAsync(baseEmployeesURL).Result);
            }

            return employees;
        }

        public bool Add(Employee employee)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                var result = client.PostAsync(baseEmployeesURL, content).Result;

                return result.IsSuccessStatusCode;
            }
        }

        public Employee GetById(int id)
        {
            Employee employee = null;

            using (HttpClient client = new HttpClient())
            {
                string employeeStr = client.GetStringAsync(baseEmployeesURL + $"/GetById?id={id}").Result;

                if (!string.IsNullOrEmpty(employeeStr))
                {
                    employee = JsonConvert.DeserializeObject<Employee>(employeeStr);
                }
            }

            return employee;
        }

        public bool Edit(Employee employee)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                var result = client.PutAsync(baseEmployeesURL, content).Result;

                return result.IsSuccessStatusCode;
            }
        }

        public bool Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync(baseEmployeesURL + $"?id={id}").Result;

                return result.IsSuccessStatusCode;
            }
        }


    }
}
