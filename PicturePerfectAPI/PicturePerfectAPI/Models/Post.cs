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
        public string Categorie { get; set; }
        public int Likes { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int GebruikerId { get; set; }

        public Post(string beschrijving, string categorieNaam, Gebruiker gebruiker)
        {
            DatePosted = DateTime.Now;
            Fotos = new List<Foto>();
            Categorie = categorieNaam;
            Likes = 0;
            Beschrijving = beschrijving;
            Gebruiker = gebruiker;
        }
        public Post() {
            Fotos = new List<Foto>();
            //Gebruiker = new Gebruiker();
        }

        public void AddFoto(Foto foto)
        {
            Fotos.Add(foto);
        }
    }
}
