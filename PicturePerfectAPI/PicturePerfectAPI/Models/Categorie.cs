using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string CategorieNaam { get; set; }

        public Categorie(string naam)
        {
            CategorieNaam = naam;
        }
        
        public Categorie() { }
    }
}
