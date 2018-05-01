using System;
using System.Data.Entity;
using System.Linq;

namespace CustomersDAL.DAL.Repository
{
    public class SqlRepository<T> : IRepository<T>
                                    where T : class,IEntity,new()
    {
        DbSet<T> _dbSet;
        DbContext _contexct;
        public SqlRepository(DbContext contexct)
        {
            _contexct = contexct;
            _dbSet = contexct.Set<T>();
            
        }



        public void Add(T newEntity)
        {
            _dbSet.Add(newEntity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            
        }


        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            
            return _dbSet.Where(predicate).AsQueryable();
        }


        public IQueryable<T> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public T FindById(long Id)
        {
            return _dbSet.Single(o => o.Id == Id);
        }


        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _contexct.Entry(entity).State = EntityState.Modified;

           
        }
    }
}
