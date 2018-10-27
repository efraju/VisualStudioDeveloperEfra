using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Track> GetByPlaylistId(int playlistId)
        {
            var tracks = Context.Playlist.Include(p => p.Tracks).FirstOrDefault(p => p.PlaylistId == playlistId).Tracks;

            // convertimos el resultado a lista y lo retornamos
            return tracks.ToList();
        }

       
    }
}
