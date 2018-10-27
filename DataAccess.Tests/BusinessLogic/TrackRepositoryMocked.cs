using AutoFixture;
using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using Models;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.BusinessLogic
{
    public class TrackRepositoryMocked
    {

        private readonly List<Track> _tracks;

        public TrackRepositoryMocked()
        {
            _tracks = GetTracks();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(c => c.Tracks)
                .Returns(GetRepositoryMocked);

            return mocked.Object;
        }

        private ITrackRepository GetRepositoryMocked()
        {
            var trackMocked = new Mock<ITrackRepository>();

            trackMocked.Setup(c => c.GetAll())
                .Returns(_tracks);

            return trackMocked.Object;
        }

        private List<Track> GetTracks()
        {
            var fixture = new Fixture();
            var tracks = fixture.CreateMany<Track>
                (10).ToList();

            for (int i = 0; i < 10; i++)
            {
                tracks[i].TrackId = i + 1;

            }
            return tracks;
        }
    }
}
