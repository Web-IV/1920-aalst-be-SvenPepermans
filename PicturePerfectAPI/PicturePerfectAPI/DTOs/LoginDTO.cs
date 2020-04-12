using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.DTOs
{
    public class LoginDTO
    {
        [Required]       
        public string Gebruikersnaam { get; set; }
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
