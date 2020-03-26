using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        public DateTime DatePosted { get; set; }
        [Required]
        public ICollection<Foto> Fotos { get; set; }
        [Required]
        public ICollection<Categorie> Categories { get; set; }
        public int Likes { get; set; }

        public Post(string beschrijving)
        {
            DatePosted = DateTime.Now;
            Fotos = new List<Foto>();
            Categories = new List<Categorie>();
            Likes = 0;
        }

        public void FotoToevoegen(Foto foto)
        {
            Fotos.Add(foto);
        }

        public void CategorieToevoegen(Categorie cat)
        {
            Categories.Add(cat);
        }
    }
}
