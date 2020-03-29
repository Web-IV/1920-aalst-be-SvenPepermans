using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicturePerfectAPI.DTOs;
using PicturePerfectAPI.Models;

namespace PicturePerfectAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public ActionResult<Post> PostPost(PostDTO post)
        {
            Post postToCreate = new Post() { Beschrijving = post.Beschrijving };
            foreach (var f in post.Fotos)
                postToCreate.AddFoto(new Foto(f.Url, f.Naam));
            _postRepository.Add(postToCreate);
            _postRepository.SaveChanges();

            return CreatedAtAction(nameof(GetPost),
                new { id = postToCreate.PostId }, postToCreate);
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