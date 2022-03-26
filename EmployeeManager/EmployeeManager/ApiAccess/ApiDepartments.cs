using DTOEmployeeDepartment;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManager.ApiAccess
{
    public class ApiDepartments
    {
        private const string baseDepartmentsURL = "https://localhost:44393/Departments";

        public List<Department> GetAll()
        {
            List<Department> departments;

            using (HttpClient client = new HttpClient())
            {
                departments = JsonConvert.DeserializeObject<List<Department>>(client.GetStringAsync(baseDepartmentsURL).Result);
            }

            return departments;
        }

        public bool Add(Department department)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(department), Encoding.UTF8, "application/json");

                var result = client.PostAsync(baseDepartmentsURL, content).Result;

                return result.IsSuccessStatusCode;
            }
        }

        public Department GetById(int id)
        {
            Department department = null;

            using (HttpClient client = new HttpClient())
            {
                string departmentStr = client.GetStringAsync(baseDepartmentsURL + $"/GetById?id={id}").Result;

                if (!string.IsNullOrEmpty(departmentStr))
                {
                    department = JsonConvert.DeserializeObject<Department>(departmentStr);
                }
            }

            return department;
        }

        public bool Edit(Department department)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(department), Encoding.UTF8, "application/json");

                var result = client.PutAsync(baseDepartmentsURL, content).Result;

                return result.IsSuccessStatusCode;
            }
        }

        public bool Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync(baseDepartmentsURL + $"?id={id}&force={true}").Result;

                return result.IsSuccessStatusCode;
            }
        }


    }
}
