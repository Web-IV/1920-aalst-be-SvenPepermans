using Microsoft.EntityFrameworkCore;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(ApplicationDbContext context)
        {
            _context = context;
            _gebruikers = _context.Gebruikers;
        }
        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public void Delete(Gebruiker gebruiker)
        {
            _gebruikers.Remove(gebruiker);
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers.ToList();
        }

        public Gebruiker GetById(int id)
        {
            return _gebruikers.SingleOrDefault(g => g.GebruikersId == id);
        }

        public Gebruiker GetByUserName(string gebruikersNaam)
        {
            return _gebruikers.SingleOrDefault(g => g.Gebruikersnaam == gebruikersNaam);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Gebruiker gebruiker)
        {
            _context.Update(gebruiker);
        }
    }
}
}
