using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetBy(int id);
        IEnumerable<Post> GetByDate(DateTime date);
        IEnumerable<Post> GetByGebruikerId(int id);
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        void SaveChanges();
    }
}
