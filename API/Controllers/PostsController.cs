using Application.Posts;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostsController : BaseApiController
    {

        [HttpGet]   //api/posts
        public async Task<ActionResult<List<Post>>> GetPosts() {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]   //api/posts/guid
        public async Task<ActionResult<Post>> GetPost(Guid id) {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            await Mediator.Send(new Create.Command {Post = post});
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(Guid id, Post post)
        {
            post.Id = id;

            await Mediator.Send(new Edit.Command{Post = post});

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await Mediator.Send(new Delete.Command{ Id = id });

            return Ok();
        }

    }
}