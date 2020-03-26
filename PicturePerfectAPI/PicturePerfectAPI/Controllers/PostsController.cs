using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicturePerfectAPI.Models;

namespace PicturePerfectAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostsController(IPostRepository context)
        {
            _postRepository = context;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.GetAll().OrderBy(p => p.DatePosted);
        }

        // Get: api/Posts/<id>
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        // POST: api/Posts
        [HttpPost]
        public ActionResult<Post> PostPost(Post post)
        {
            _postRepository.Add(post);
            _postRepository.SaveChanges();

            return CreatedAtAction(nameof(GetPost),
                new { id = post.PostId }, post);
        }

        // PUT: api/Posts/<id>
        [HttpPut("{id}")]
        public IActionResult PutPost(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }
            _postRepository.Update(post);
            _postRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Posts/<id>
        [HttpDelete("{id}")]
        public ActionResult<Post> DeletePost(int id)
        {
            Post post = _postRepository.GetBy(id);
            if(post == null)
            {
                return NotFound();
            }
            _postRepository.Delete(post);
            _postRepository.SaveChanges();
            return post;
        }
    }
}