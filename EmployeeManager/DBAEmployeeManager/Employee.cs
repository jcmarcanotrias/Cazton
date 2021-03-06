namespace DBAEmployeeManager
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal Salary { get; set; }

        public string Picture { get; set; }

        public string Bio { get; set; }

        public int DepartmentId { get; set; }
    }
}
