using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.DTOs
{
    public class CategorieDTO
    {
        [Required]
        public string CategorieNaam { get; set; }
    }
}
