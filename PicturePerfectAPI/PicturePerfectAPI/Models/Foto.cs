using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public class Foto
    {
        public int FotoId { get; set; }
        
        public string Url { get; set; }
       
        public string Naam { get; set; }


        public Foto(string url, string naam)
        {
            Url = url;
            Naam = naam;
        }
    }
}
