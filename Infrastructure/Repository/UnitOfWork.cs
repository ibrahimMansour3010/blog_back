using Core.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        public IGenericRepo<Blog> _Blog { get; set; }
        private BlogContext _blogContext;
        public UnitOfWork(IGenericRepo<Blog> blog, BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IGenericRepo<Blog> Blog
        {
            get
            {
                if (_Blog == null)
                    _Blog = new GenericRepo<Blog>(_blogContext);
                return _Blog;
            }
        }

        public void Dispose()
        {
            _blogContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _blogContext.SaveChangesAsync();
        }
    }
}
