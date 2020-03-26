using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetById(int id);
        Gebruiker GetByUserName(string gebruikersNaam);
        void Add(Gebruiker gebruiker);
        void Update(Gebruiker gebruiker);
        void Delete(Gebruiker gebruiker);
        void SaveChanges();
    }
}
