using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepo<T>: IGenericRepo<T> where T : class
    {
        private readonly BlogContext _blogContext;
        private readonly DbSet<T> _entity;
        public GenericRepo(BlogContext blogContext)
        {
            _blogContext = blogContext;
            _entity = _blogContext.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return _entity;
        }
        public async Task<T> Get(long Id)
        {
            return await _entity.FindAsync(Id);
        }
        public async Task<T> Add(T entity)
        {
            var returnedEntity = await _entity.AddAsync(entity);
            return returnedEntity.Entity;
        }
        public  void Edit(T entity)
        {
            _entity.Update(entity);
        }
        public  T Delete(T entity)
        {
           var returnedEntity = _entity.Remove(entity);
            return returnedEntity.Entity;
        }
        public  T Delte(T entity)
        {
           var returnedEntity = _entity.Remove(entity);
            return returnedEntity.Entity;
        }
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _entity.Where(expression);
        }
        public IEnumerable<T> GetByConditionWithInclude(Expression<Func<T, bool>> expression, List<string> includes)
        {
            var result = _entity.Where(expression);
            includes.ToList().ForEach(a =>
            {
                result = result.Include(a);
            });
            return result;
        }
    }
}
