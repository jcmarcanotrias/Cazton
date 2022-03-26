using DTOEmployeeDepartment;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DBAEmployeeDepartment
{
    public class DBManager : DbContext
    {
        public DBManager()
        {

        }

        public DBManager(string serverName, string dbName) : base($"data source={serverName};initial catalog={dbName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {

        }

        public DBManager(string serverName, string dbName, string user, string pass) : base($"data source={serverName};initial catalog={dbName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {

        }



        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public bool AddDepartment(Department department)
        {
            try
            {

                Departments.Add(department);

                SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                //TODO log exception
                throw;
            }
        }

        public bool UpdateDepartment(Department department)
        {
            try
            {

                var oldDepartment = Departments.FirstOrDefault(x => x.Id == department.Id);
                if (oldDepartment != null)
                {
                    oldDepartment.Name = department.Name;
                    oldDepartment.Description = department.Description;

                    SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                //TODO log exception
                throw;
            }

            return false;
        }

        public bool DeleteDepartment(int Id, bool force = false)
        {
            try
            {
                var department = Departments.FirstOrDefault(x => x.Id == Id);
                if (department != null)
                {
                    if (department.Employees.Count > 0)
                    {
                        if (!force)
                        {
                            throw new Exception($"Department {department.Name} has employees");
                        }

                        Employees.RemoveRange(department.Employees);
                    }

                    Departments.Remove(department);

                    SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                //TODO log exception
                throw;
            }

            return false;
        }

        public Department GetDepartmentByName(string v)
        {
            Department department = null;

            try
            {
                department = Departments.FirstOrDefault(x => x.Name == v);
            }
            catch (Exception)
            {

                throw;
            }

            return department;
        }

        public Department GetDepartmentById(int id)
        {
            
            try
            {
                return Departments.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<Department> GetDepartments()
        {
            List<Department> departments = null;

            try
            {
                departments = Departments.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return departments;
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                Employees.Add(employee);

                SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                var oldEmployee = Employees.FirstOrDefault(x => x.Id == employee.Id);
                if (oldEmployee != null)
                {
                    oldEmployee.Name = employee.Name;
                    oldEmployee.LastName = employee.LastName;
                    oldEmployee.Email = employee.Email;
                    oldEmployee.Phone = employee.Phone;
                    oldEmployee.Salary = employee.Salary;
                    oldEmployee.Picture = employee.Picture;
                    oldEmployee.Bio = employee.Bio;                    
                    oldEmployee.DepartmentId = employee.DepartmentId;

                    SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                //TODO log exception
                throw;
            }

            return false;
        }

        public bool DeleteEmployee(int Id)
        {
            try
            {
                var employee = Employees.FirstOrDefault(x => x.Id == Id);
                if (employee != null)
                {
                    Employees.Remove(employee);

                    SaveChanges();

                    return true;
                }

            }
            catch (Exception ex)
            {
                //TODO log exception
                throw;
            }

            return false;
        }

        public Employee GetEmployeeByName(string v)
        {
            try
            {
                return Employees.FirstOrDefault(x => x.Name == v);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return Employees.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = null;

            try
            {
                employees = Employees.ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return employees;
        }

    }
}