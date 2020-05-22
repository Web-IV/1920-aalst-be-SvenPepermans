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
        public string Base64 { get; set; }
       


        public Foto(string naam)
        {
            var extensie = naam.Split(".");
            Url = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Resources", "Images")), naam);       
            Base64 = "data:image/"+ extensie[extensie.Length-1]+";base64, "+Convert.ToBase64String(File.ReadAllBytes(Url));

            Naam = naam;
        }

        public Foto() { }
    }
}
