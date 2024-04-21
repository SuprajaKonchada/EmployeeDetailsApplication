using EmployeeDetailsApplication.Data;

namespace EmployeeDetailsApplication.Services
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
