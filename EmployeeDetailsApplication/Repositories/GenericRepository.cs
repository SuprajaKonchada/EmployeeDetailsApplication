using EmployeeDetailsApplication.Repositories;
using EmployeeDetailsApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsApplication.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }


        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
