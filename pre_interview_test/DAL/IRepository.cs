using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pre_interview_test.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> List();

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        void Save();
    }
}
