using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepo<Blog> Blog { get; }
        Task SaveAsync();
    }
}
