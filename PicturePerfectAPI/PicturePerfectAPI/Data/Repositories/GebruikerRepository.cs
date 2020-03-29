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


        public Gebruiker GetBy(string email)
        {
            return _gebruikers.Include(g => g.Posts).ThenInclude(g => g.Fotos).SingleOrDefault(c => c.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

     
    }
}

