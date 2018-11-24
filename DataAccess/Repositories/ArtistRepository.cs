using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<GetArtistModel> PaginatedArtistList(string searchTerm, int page, int rows)
        {
            var param1 = new SqlParameter {
                ParameterName= "searchTerm",
            Value=searchTerm};
            var param2 = new SqlParameter
            {
                ParameterName = "page",
                Value = page
            };
            var param3 = new SqlParameter
            {
                ParameterName = "rows",
                Value = rows
            };
            return Context.Database.SqlQuery<GetArtistModel>("Paginated_Artist_List @searchTerm,@page,@rows", param1,param2,param3).ToList();
              
        }

 
    }
}
