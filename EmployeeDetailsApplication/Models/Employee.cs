using System.ComponentModel.DataAnnotations;

namespace EmployeeDetailsApplication.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public int DepartmentId { get; set; }
        public string? Details { get; set; }
        public decimal Experience { get; set; }
        public  Department? Department { get; set; }
        public string? EmployeeSkill { get; set; }
        public string? EmployeeProject { get; set; }
    }

}
