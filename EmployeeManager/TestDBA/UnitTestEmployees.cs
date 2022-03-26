using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBAEmployeeDepartment;
using DTOEmployeeDepartment;

namespace TestDBA
{
    [TestClass]
    public class UnitTestEmployees
    {
        [TestMethod]
        public void TestMethodAddEmployee()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue(dbMgr.AddEmployee(new Employee()
            {
                Name = "Emp1",
                LastName = "Emp1",
                Email = "emp1@mail.com",
                Phone = "55555555",
                Salary = 2000,
                Picture = "Picture1",
                Bio = "Emp1",
                DepartmentId = 1
            }));

        }

        [TestMethod]
        public void TestMethodUpdateEmployee()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue(dbMgr.UpdateEmployee(new Employee()
            {
                Name = "Emp10",
                LastName = "Emp10",
                Email = "emp10@mail.com",
                Phone = "654654654",
                Salary = 1000,
                Picture = "Picture10",
                Bio = "Emp10",
                DepartmentId = 1
            }));

        }

        [TestMethod]
        public void TestMethodDeleteEmployee()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue(dbMgr.DeleteEmployee(1));

        }

        [TestMethod]
        public void TestMethodEmployeeByName()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            var employee = dbMgr.GetEmployeeByName("Emp10");

            Assert.IsNotNull(employee);

        }


        [TestMethod]
        public void TestMethodEmployees()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            var employees = dbMgr.GetEmployees();

            Assert.IsNotNull(employees);

        }
    }
}
