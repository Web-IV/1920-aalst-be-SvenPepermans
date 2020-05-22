using Microsoft.EntityFrameworkCore;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
            _posts = _context.Posts;
        }
        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts.Include(p => p.Gebruiker).Include(p => p.Fotos).ToList();
        }

        public IEnumerable<Post> GetByGebruikerId(int id)
        {
            return _posts.Where(p => p.GebruikerId == id).Include(p => p.Gebruiker).Include(p => p.Fotos).ToList();
        }

        public Post GetBy(int id)
        {
            return _posts.Include(p => p.Gebruiker).Include(p => p.Fotos).SingleOrDefault(p => p.PostId == id);
        }

        public IEnumerable<Post> GetByDate(DateTime date)
        {
            return _posts.Where(p => p.DatePosted == date).Include(p => p.Gebruiker).Include(p => p.Fotos).ToList();
        }

        public IEnumerable<Post> GetPosts(string beschrijving = null, string categorieNaam = null)
        {
            var posts = _posts.Include(p => p.Gebruiker).Include(p => p.Fotos).AsQueryable();
            if (!string.IsNullOrEmpty(beschrijving))
                posts = posts.Where(p => p.Beschrijving.IndexOf(beschrijving) >= 0);
            if (!string.IsNullOrEmpty(categorieNaam))
                posts = posts.Where(p => p.CategorieNaam == categorieNaam);
            return posts.OrderBy(p => p.DatePosted).ToList();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Update(post);
        }
    }
}
