using Microsoft.EntityFrameworkCore;
using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Infra;

namespace PizzaFlow.Intranet.Business.PizzaFlowBase.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        protected readonly Database _context;
        protected readonly DbSet<T> _dbSet;

        public DataRepository(Database context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Query()
            => _dbSet.AsNoTracking();

        public T? GetById(int id)
            => _dbSet.Find(id);

        public void Add(T entity)
            => _dbSet.Add(entity);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public void Delete(T entity)
            => _dbSet.Remove(entity);

        public void SaveChanges()
            => _context.SaveChanges();
    }
}