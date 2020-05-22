using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.DTOs
{
    public class FotoDTO
    {
        [Required]
        public string Naam { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Base64 { get; set; }

    }
}
