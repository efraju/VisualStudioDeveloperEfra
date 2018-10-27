using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArtistRespository
    {
        private DatabaseContext _context;
        public ArtistRespository()
        {
            _context = new DatabaseContext();
        }

        public void InsertarRegistrosPrueba()
        {
            var lista = new List<Artist>
            {
                new Artist { Name = "Mana"},
                new Artist { Name = "Metallica"},
                new Artist { Name = "Bareto"}
            };

            // insertar cada artista a la BD (a través del context)
            lista.ForEach(artist => _context.Artist.Add(artist));
            // commit
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }
    }
}
