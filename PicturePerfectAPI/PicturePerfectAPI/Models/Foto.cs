using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public class Foto
    {
        public int FotoId { get; set; }
        public string Url { get; set; }
        public Post Post { get; set; }
        public string Naam { get; set; }

        public Foto(string url, Post post, string naam)
        {
            Url = url;
            Post = post;
            Naam = naam;
        }
    }
}
