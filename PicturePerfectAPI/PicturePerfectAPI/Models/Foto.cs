using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public class Foto
    {
        public int FotoId { get; set; }
        
        public string Url { get; set; }
       
        public string Naam { get; set; }
       


        public Foto(string naam)
        {
            
            Url = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Resources", "Images")), naam);

            Naam = naam;
        }

        public Foto() { }
    }
}
