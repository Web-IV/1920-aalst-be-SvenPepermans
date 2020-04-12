using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PicturePerfectAPI.DTOs
{
    public class PostDTO
    {
        [Required]
        public string Beschrijving { get; set; }

        [Required]
        public IList<FotoDTO> Fotos { get; set; }

        [Required]
        public CategorieDTO Categorie { get; set; }
    }
}
