using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public interface IGebruikerRepository
    {
        Gebruiker GetBy(string email );
        Gebruiker GetById(int id);
        void Add(Gebruiker gebruiker);
        IEnumerable<Gebruiker> GetAll();
        void SaveChanges();
    }
}
