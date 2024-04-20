using EmployeeDetailsApplication.Data;
using EmployeeDetailsApplication.Models;
using EmployeeDetailsApplication.Repositories;

namespace EmployeeDetailsApplication.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
