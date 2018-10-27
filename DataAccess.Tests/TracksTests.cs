using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using DataAccess;

namespace ClassLibrary1
{
    public class TracksTests
    {
        private readonly IUnitOfWork _unitOfWork;

        public TracksTests()
        {
            // aquí se crea la conexión a BD
            _unitOfWork = new UnitOfWork(new DatabaseContext());
        }

        [Fact]
        public void Get_By_Playlist_Id()
        {
            var tracks = _unitOfWork.Tracks.GetByPlaylistId(1);
            tracks.Count().Should().Be(3290);
        }


    }
}
