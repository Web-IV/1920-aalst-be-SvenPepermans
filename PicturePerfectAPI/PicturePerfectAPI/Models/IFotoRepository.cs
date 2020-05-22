using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicturePerfectAPI.Models
{
   public interface IFotoRepository
    {
        IEnumerable<Foto> GetAll();
        Foto GetBy(int id);
        Foto GetByNaam(string naam);
        void Add(Foto foto);
        void Update(Foto foto);
        void Remove(Foto foto);
        void SaveChanges();
    }
}
