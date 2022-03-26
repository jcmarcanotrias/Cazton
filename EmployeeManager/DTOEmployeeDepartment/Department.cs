using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOEmployeeDepartment
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(200), Required]
        public string Description { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
