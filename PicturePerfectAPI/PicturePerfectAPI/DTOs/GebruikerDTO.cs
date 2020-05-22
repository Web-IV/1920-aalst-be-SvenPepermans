using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.DTOs
{
    public class GebruikerDTO
    {
        public int GebruikersId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
     //   public IEnumerable<Post> Posts { get; set; }
     //   public IEnumerable<Foto> Fotos { get; set; }
        public GebruikerDTO() { }

        public GebruikerDTO(Gebruiker gebruiker) : this()
        {
            GebruikersId = gebruiker.GebruikersId;
            Voornaam = gebruiker.Voornaam;
            Achternaam = gebruiker.Achternaam;
            Gebruikersnaam = gebruiker.Gebruikersnaam;
            Email = gebruiker.Email;
           // Posts = gebruiker.Posts;
           // Fotos = gebruiker.Fotos;

        }
    }
}
