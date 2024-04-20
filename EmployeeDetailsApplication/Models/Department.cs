using System.ComponentModel.DataAnnotations;

namespace EmployeeDetailsApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

}
