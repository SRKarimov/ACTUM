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
        DbContext _ctx;

        public BaseRepository(DbContext ctx)
        {
            this._ctx = ctx;
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Update(T entity)
        {
            
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public ICollection<T> List()
        {
            return _ctx.Set<T>().ToList();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
