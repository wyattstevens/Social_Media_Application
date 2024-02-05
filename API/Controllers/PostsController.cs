using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {
        private readonly DataContext _context;
        public PostsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]   //api/posts
        public async Task<ActionResult<List<Post>>> GetPosts() {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]   //api/posts/guid
        public async Task<ActionResult<Post>> GetPost(Guid id) {
            return await _context.Posts.FindAsync(id);
        }

    }
}