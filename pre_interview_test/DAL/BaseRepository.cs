using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace pre_interview_test.DAL
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected Context _ctx;
        protected DbSet<T> _dbSet;

        public BaseRepository(Context ctx)
        {
            this._ctx = ctx;
            this._dbSet = _ctx.Set<T>();
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
            Save();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public T Find(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public ICollection<T> List()
        {
            return _dbSet.ToList();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
