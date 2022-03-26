using System.ComponentModel.DataAnnotations;

namespace DTOEmployeeDepartment
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string Bio { get; set; }

        public int DepartmentId { get; set; }
    }
}
