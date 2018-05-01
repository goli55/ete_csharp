using System;
using System.Linq;
using System.Linq.Expressions;

namespace CustomersDAL.DAL.Repository
{
    public interface IRepository<T>
    {
        void Add(T newEntity);
        void Remove(T entity);
        void Update(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAll();
        T FindById(long Id);


    }
}
