using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBlogService
    {
        GenericResponse<object> GetAllBlogs(int PageNumber, int RecordsPerPage);
        Task<GenericResponse<BlogDTO>> GetBlogById(long Id);
        Task<GenericResponse<BlogDTO>> ManageBlog(BlogDTO model);
        Task<GenericResponse<BlogDTO>> DeleteBlogById(long Id);
    }
}
