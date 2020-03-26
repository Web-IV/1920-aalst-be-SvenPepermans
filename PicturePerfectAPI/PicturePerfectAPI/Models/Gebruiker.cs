using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public class Gebruiker
    {
        public int GebruikersId { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string Achternaam { get; set; }
        public ICollection<Post> Posts { get; private set; }

        public Gebruiker(string gebruikersnaam, string email, string voornaam, string achternaam)
        {
            Gebruikersnaam = gebruikersnaam;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Posts = new List<Post>();
            Email = email;
        }
    }
}
