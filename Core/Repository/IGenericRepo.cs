using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        IQueryable<T> Get();
        Task<T> Get(long Id);
        Task<T> Add(T entity);
        void Edit(T entity);
        T Delete(T entity);
        T Delte(T entity);
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetByConditionWithInclude(Expression<Func<T, bool>> expression, List<string> includes);
    }
}
