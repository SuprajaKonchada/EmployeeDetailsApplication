using System.ComponentModel.DataAnnotations;

namespace EmployeeDetailsApplication.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
