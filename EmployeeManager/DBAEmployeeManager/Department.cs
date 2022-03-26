using System.Collections.Generic;

namespace DBAEmployeeManager
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
