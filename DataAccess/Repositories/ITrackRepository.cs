using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        IEnumerable<Track> GetByPlaylistId(int playlistId); 

    }
}
