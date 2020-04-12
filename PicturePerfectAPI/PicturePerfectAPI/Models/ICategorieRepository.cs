using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
    public interface ICategorieRepository
    {
        Categorie GetBy(int id);
        Categorie GetByNaam(string naam);
        IEnumerable<Categorie> GetAll();
        void SaveChanges();
        void Add(Categorie categorie);
        void Update(Categorie categorie);
        void Remove(Categorie categorie);
            }
}
