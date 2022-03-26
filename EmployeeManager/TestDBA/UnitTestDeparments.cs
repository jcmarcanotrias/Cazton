using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBAEmployeeDepartment;
using DTOEmployeeDepartment;

namespace TestDBA
{
    [TestClass]
    public class UnitTestDeparments
    {
        [TestMethod]
        public void TestMethodAddDepartment()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue (dbMgr.AddDepartment(new Department() { Name = "Human Resource", Description = "Human Resource Deparment" }));

        }

        [TestMethod]
        public void TestMethodUpdateDepartment()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue(dbMgr.UpdateDepartment(new Department() { Name = "PPSS", Description = "Professional Services" }));

        }

        [TestMethod]
        public void TestMethodDeleteDepartment()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue(dbMgr.DeleteDepartment(2));

        }

        [TestMethod]
        public void TestMethodDeleteDepartmentAndEmployees()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            Assert.IsTrue(dbMgr.DeleteDepartment(7, true));

        }

        [TestMethod]
        public void TestMethodDepartmentByName()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            var department = dbMgr.GetDepartmentByName("Human Resource");

            Assert.IsNotNull(department);

        }


        [TestMethod]
        public void TestMethodDepartments()
        {
            var dbMgr = new DBManager("(LocalDb)\\MSSQLLocalDB", "DBAEmployeeDepartment.Model1");

            var departments = dbMgr.GetDepartments();

            Assert.IsNotNull(departments);

        }
    }
}
