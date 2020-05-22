using Microsoft.EntityFrameworkCore;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data.Repositories
{
    public class FotoRepository : IFotoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Foto> _fotos;

        public FotoRepository(ApplicationDbContext context)
        {
            _context = context;
            _fotos = _context.Fotos;
        }
        public void Add(Foto foto)
        {
            _fotos.Add(foto);
        }

        public IEnumerable<Foto> GetAll()
        {
            return _fotos.ToList();
        }

        public Foto GetByNaam(string naam)
        {
            return _fotos.FirstOrDefault(f => f.Naam == naam);
        }
        public Foto GetBy(int id)
        {
            return _fotos.SingleOrDefault(f => f.FotoId == id);
        }

        public void Remove(Foto foto)
        {
            _fotos.Remove(foto);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Foto foto)
        {
            _context.Update(foto);
        }
    }
}
