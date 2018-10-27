using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Models;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        // Artists
        public IArtistRepository Artists { get; private set; }
        // Tracks
        public ITrackRepository Tracks { get; private set; }
        // Playlists
        public IRepository<Playlist> Playlists { get; private set; }
        // Genres
        public IRepository<Genre> Genres { get; private set; }
        // MediaTypes
        public IRepository<MediaType> MediaTypes { get; private set; }
        // Albums
        public IRepository<Album> Albums { get; private set; }

        public readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            // no olvidar inicializar todos los repositorios que se van a utilizar en este unit of work
            Artists = new ArtistRepository(_context);
            Tracks = new TrackRepository(_context);
            Playlists = new Repository<Playlist>(_context);
            Genres = new Repository<Genre>(_context);
            MediaTypes = new Repository<MediaType>(_context);
            Albums = new Repository<Album>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
