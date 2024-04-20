using System.ComponentModel.DataAnnotations;

namespace EmployeeDetailsApplication.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public int DepartmentId { get; set; }
        public  Department? Department { get; set; }
    }
}
