using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicturePerfectAPI.DTOs;
using PicturePerfectAPI.Models;

namespace PicturePerfectAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        public readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        /// <summary>
        /// Get the current user
        /// </summary>
        /// <returns>The gebruiker</returns>
        [HttpGet()]
        public ActionResult<GebruikerDTO> GetGebruiker()
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(User.Identity.Name);
            return new GebruikerDTO(gebruiker);
        }

        

        /// Get: api/Gebruiker/<id>
        /// <summary>
        /// Get the User with given id
        /// </summary>
        /// <param name="id"> The id of the User that we want to see</param>
        /// <returns>The gebruiker</returns>

        [HttpGet("{id}")]
        public ActionResult<Gebruiker> GetGebruikerWithId(int id)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetById(id);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return gebruiker;
        }

    }
}
