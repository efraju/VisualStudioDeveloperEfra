using AutoFixture;
using DataAccess;
using DataAccess.Repositories;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Test
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


            trackMocked.Setup(c => c.GetById(It.IsAny<int>()))
                .Returns((int id)=>_tracks.FirstOrDefault(x=>x.TrackId==id));

            return trackMocked.Object;
        }

        private List<Track> GetTracks()
        {
            //var fixture = new Fixture();
            //var tracks = fixture.CreateMany<Track>
            //    (10).ToList();

            //for (int i = 0; i < 10; i++)
            //{
            //    tracks[i].TrackId = i + 1;

            //}
            //return tracks;
            return new List<Track>
            {
                new Track
                {
                    TrackId=1,
                    Composer="Cibertec1"
                },

                 new Track
                {
                    TrackId=1,
                    Composer="Cibertec2"
                }
            };
        }
    }
}
