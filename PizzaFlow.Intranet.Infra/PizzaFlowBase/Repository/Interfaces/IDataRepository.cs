using PizzaFlow.Intranet.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces
{
    public interface IDataRepository<T> where T : class, IEntityBase 
    {
        T? GetById(int id);
        IQueryable<T> Query();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }

}
