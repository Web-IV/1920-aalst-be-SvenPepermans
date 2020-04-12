using Microsoft.EntityFrameworkCore;
using PicturePerfectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Data.Repositories
{
    public class CategorieRepository : ICategorieRepository

    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Categorie> _categories;

        public CategorieRepository(ApplicationDbContext context, DbSet<Categorie> categories)
        {
            _context = context;
            _categories = _context.Categories;
        }

        public void Add(Categorie categorie)
        {
            _categories.Add(categorie);
        }

        public IEnumerable<Categorie> GetAll()
        {
            return _categories.ToList();
        }

        public Categorie GetBy(int id)
        {
            return _categories.SingleOrDefault(c => c.CategorieId == id);
        }

        public Categorie GetByNaam(string naam)
        {
            return _categories.SingleOrDefault(c => c.CategorieNaam == naam);
        }

        public void Remove(Categorie categorie)
        {
            _categories.Remove(categorie);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Categorie categorie)
        {
            _context.Update(categorie);
        }
    }
}
