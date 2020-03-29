using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public interface IGebruikerRepository
    {
        Gebruiker GetByUserName(string gebruikersNaam);
        void Add(Gebruiker gebruiker);
        void SaveChanges();
    }
}
