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
        private readonly IGebruikerRepository _gebruikerRepository;
        public PostsController(IPostRepository context, IGebruikerRepository gebruikerRepository)
        {
            _postRepository = context;
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Posts
        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>Array of posts ordered by date</returns>
        [AllowAnonymous]
        [HttpGet]       
        public IEnumerable<Post> GetPosts(string beschrijving = null, string categorieNaam = null)
        {
            if (string.IsNullOrEmpty(beschrijving) && string.IsNullOrEmpty(categorieNaam))
                return _postRepository.GetAll();
            return _postRepository.GetPosts(beschrijving, categorieNaam);
        }


        // Get: api/Posts/<id>
        /// <summary>
        /// Get the post with given id
        /// </summary>
        /// <param name="id"> The id of the post that we want to see</param>
        /// <returns>The post</returns>

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


        /// Get: api/Posts/<gebruikersId>
        /// <summary>
        /// Gets all the posts of the user with given id
        /// </summary>
        /// <returns>All the posts of the user with given id</returns>
        [AllowAnonymous]
        [HttpGet("Posts/{gebruikersId}")]
        public IEnumerable<Post> GetPostsFromUser(int gebruikersId)
        {
            // Gebruiker gebruiker = _gebruikerRepository.GetById(id);
            IEnumerable<Post> posts = _postRepository.GetByGebruikerId(gebruikersId);
            return posts;
        }
        /// <summary>
        /// Adds new post
        /// </summary>
        /// <param name="post">The newly created post</param>

        [HttpPost]
        public ActionResult<Post> PostPost(PostDTO post)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(User.Identity.Name);

            Post postToCreate = new Post() { Beschrijving = post.Beschrijving, Gebruiker = gebruiker, CategorieNaam = post.CategorieNaam};
           
            foreach (var f in post.Fotos)
                postToCreate.AddFoto(new Foto(f.Naam));
            _postRepository.Add(postToCreate);
            _postRepository.SaveChanges();

            return CreatedAtAction(nameof(GetPost),
                new { id = postToCreate.PostId }, postToCreate);
        }

        // PUT: api/Posts/<postId>
        /// <summary>
        /// Updates a post with new information
        /// </summary>
        /// <param name="postId">Id of post to be updated</param>
        /// <param name="post">The updated post</param>
        /// <returns></returns>
        [HttpPut("{postId}")]
        public IActionResult PutPost(int postId, Post post)
        {
            if (postId != post.PostId)
            {
                return BadRequest();
            }
            _postRepository.Update(post);
            _postRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletes the post with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted post if exists</returns>
        
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