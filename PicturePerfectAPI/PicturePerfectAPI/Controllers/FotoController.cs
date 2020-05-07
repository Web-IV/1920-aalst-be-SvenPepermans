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
        public HttpResponseMessage UploadFotos()
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

                            var foto = new Foto(fileName);
                            _fotoRepository.Add(foto);
                        }
                    }

                }
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}