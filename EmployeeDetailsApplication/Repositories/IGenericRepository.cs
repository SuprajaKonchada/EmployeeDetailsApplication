using System.Collections.Generic;

namespace EmployeeDetailsApplication.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
