using BusinessLogic;
using DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1.BusinessLogic
{
   public class TrackLogicTest
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackLogic _trackLogic;

        public TrackLogicTest()
        {
            var repoMocked = new TrackRepositoryMocked();
            _unitOfWork = repoMocked.GetInstance();


            _trackLogic = new TrackLogic(_unitOfWork);
        }

        [Fact]

        public void GetComposer_Track_Test()
        {
            var result = _unitOfWork.Tracks.GetAll();
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();


        }
    }
}
