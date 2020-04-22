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
        public Categorie Categorie { get; set; }
        public int Likes { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int GebruikerId { get; set; }

        public Post(string beschrijving, Categorie categorie)
        {
            DatePosted = DateTime.Now;
            Fotos = new List<Foto>();
            Categorie = categorie;
            Likes = 0;
            Beschrijving = beschrijving;
        }
        public Post() { }

        public void AddFoto(Foto foto)
        {
            Fotos.Add(foto);
        }
    }
}
