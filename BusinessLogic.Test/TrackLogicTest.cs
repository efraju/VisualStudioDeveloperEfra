using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentValidation;
using FluentAssertions;

namespace BusinessLogic.Test
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
            var result =_trackLogic.GetComposer(1);
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();


        }

        [Fact]
        public void GetComposerId_Track_Test()
        {
            var result = _trackLogic.GetComposer(1);
            result.Should().Be(1);
        }
    }
}
