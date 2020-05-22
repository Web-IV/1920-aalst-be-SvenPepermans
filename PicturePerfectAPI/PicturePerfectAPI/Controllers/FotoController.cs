using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicturePerfectAPI.Models;

namespace PicturePerfectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        
        private readonly IFotoRepository _fotoRepository;

        public FotoController(IFotoRepository fotoRepository)
        {
            _fotoRepository = fotoRepository;
            
        }
        public HttpResponseMessage UploadFotos(int postId)
        {
            
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;

                    var folderName = Path.Combine("Resources", "Images");
                    var uploadpath = Path.Combine(Directory.GetCurrentDirectory(), folderName);                  
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploadpath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            fileStream.Close();
                            var foto = new Foto(fileName);
                            _fotoRepository.Add(foto);
                        }
                    }

                }
            }
            _fotoRepository.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // Get: api/Posts/<id>
        /// <summary>
        /// Get the post with given id
        /// </summary>
        /// <param name="id"> The id of the post that we want to see</param>
        /// <returns>The post</returns>

        [HttpGet("{id}")]
        public ActionResult<Foto> GetFoto(int id)
        {
            Foto foto = _fotoRepository.GetBy(id);
            if (foto == null)
            {
                return NotFound();
            }
            return foto;
        }
    }
}