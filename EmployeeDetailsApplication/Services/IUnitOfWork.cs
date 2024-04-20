using EmployeeDetailsApplication.Models;
using EmployeeDetailsApplication.Repositories;
using System;

namespace EmployeeDetailsApplication.Services
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }

}
