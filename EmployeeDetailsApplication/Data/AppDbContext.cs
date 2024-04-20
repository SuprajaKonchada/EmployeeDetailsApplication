using EmployeeDetailsApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsApplication.Data
{
    public class AppDbContext : DbContext
    {
        // Define DbSet properties for your models
        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Department> Departments { get; set; }
        public required DbSet<Project> Projects { get; set; }
        public required DbSet<Skill> Skills { get; set; }

        // Constructor accepting DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    }
}
