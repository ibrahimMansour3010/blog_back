using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public IActionResult GetAllBlogs([FromQuery] int PageNumber = 0, int RecordsPerPage = 5)
        {
            try
            {
                return Ok(_blogService.GetAllBlogs(PageNumber , RecordsPerPage));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ManageBlog")]
        public async Task<IActionResult> ManageBlog(BlogDTO model)
        {
            try
            {
                return Ok( await _blogService.ManageBlog(model));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetBlogById/{id}")]
        public async Task<IActionResult> ManageBlog(long id)
        {
            try
            {
                return Ok( await _blogService.GetBlogById(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteBlogById/{id}")]
        public async Task<IActionResult> DeleteBlogById(long id)
        {
            try
            {
                return Ok( await _blogService.DeleteBlogById(id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
