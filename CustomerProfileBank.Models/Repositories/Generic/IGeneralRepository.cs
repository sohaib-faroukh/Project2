using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Repositories.Generic
{
    public interface IGeneralRepository<T> where T : class
    {

        IEnumerable<T> GetAll();
        T FindById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        bool Delete(int Id);
        T Edit(T entity);
        T Edit(T oldEntity, T newEntity);
        IQueryable<T> Include(Expression<Func<T, object>> includes);
        void Save();
    }
}
