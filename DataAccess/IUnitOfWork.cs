using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        ITrackRepository Tracks { get; }
        IRepository<Playlist> Playlists { get; }
        IRepository<Genre> Genres { get; }
        IRepository<MediaType> MediaTypes { get; }
        IRepository<Album> Albums { get; }
        int Complete();
    }
}
