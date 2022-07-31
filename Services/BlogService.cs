using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class BlogService: IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BlogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GenericResponse<object> GetAllBlogs(int PageNumber,int RecordsPerPage)
        {
            var response = new GenericResponse<object>();
            var blogs = _unitOfWork.Blog.Get()
                .OrderByDescending(i=>i.CreationDate)
                .Skip((PageNumber ) * RecordsPerPage).Take(RecordsPerPage)
                .Select(i => _mapper.Map<BlogItem>(i)).ToList();
            
            if (blogs.Any())
            {
                response.Status = true;
                response.Message = "success";
                response.Response = new { totalRows = _unitOfWork.Blog.Get().Count(), data= blogs.ToList()};
                // for test loader
                //Thread.Sleep(2000);
                return response;
            }
            response.Status = false;
            response.Message = "no data";
            response.Response = null;
            return response;
        }
        public async Task<GenericResponse<BlogDTO>> GetBlogById(long Id)
        {
            var response = new GenericResponse<BlogDTO>();
            var blog = await _unitOfWork.Blog.Get(Id);

            if (blog != null)
            {
                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<BlogDTO>(blog);

                return response;
            }
            response.Status = false;
            response.Message = "no data";
            response.Response = null;
            return response;
        }
        public async Task<GenericResponse<BlogDTO>> ManageBlog(BlogDTO model)
        {
            var response = new GenericResponse<BlogDTO>();
            if(model.id == 0) // add
            {
                var result = await _unitOfWork.Blog.Add(_mapper.Map<Blog>(model));
                await _unitOfWork.SaveAsync();
                if(result != null)
                {
                    response.Status = true;
                    response.Message = "success";
                    response.Response = _mapper.Map<BlogDTO>(result);
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "failed";
                    response.Response = null;
                    return response;
                }
            }
            else // edit
            {
                var blog = await _unitOfWork.Blog.Get(model.id);
                blog.Title = model.title;
                blog.Body = model.body;
                blog.CreationDate = Convert.ToDateTime(model.creationDate);

                _unitOfWork.Blog.Edit(blog);
                await _unitOfWork.SaveAsync();

                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<BlogDTO>(blog);
                return response;
            }
        }
        public async Task<GenericResponse<BlogDTO>> DeleteBlogById(long Id)
        {
            var response = new GenericResponse<BlogDTO>();
            var blog = await _unitOfWork.Blog.Get(Id);
            if (blog != null)
            {
                blog = _unitOfWork.Blog.Delete(blog);
                await _unitOfWork.SaveAsync();

                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<BlogDTO>(blog);

                return response;
            }


            response.Status = false;
            response.Message = "no data";
            response.Response = null;
            return response;
        }
    }
}
