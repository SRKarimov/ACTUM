using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace pre_interview_test.DAL
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private Context _ctx;
        private DbSet<T> _dbSet;

        public BaseRepository(Context ctx)
        {
            this._ctx = ctx;
            this._dbSet = _ctx.Set<T>();
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
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
            
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
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
