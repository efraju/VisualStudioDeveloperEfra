using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(DatabaseContext context) : base(context)
        {
        }
        public Artist GetByName(string name)
        {
            return Context.Artist.FirstOrDefault(a => a.Name == name);
        }

        public IEnumerable<Artist> GetListOfArtistSP()
        {
            return Context.Database.SqlQuery<Artist>("spGetListOfArtist");
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
            lista.ForEach(artist => Context.Artist.Add(artist));
        }
    }
}
