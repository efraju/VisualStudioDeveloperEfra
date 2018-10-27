using DataAccess.Repositories;
using FluentAssertions;
using Models;
using System.Linq;
using Xunit;

namespace DataAccess.Tests
{
    public class ArtistRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistRepositoryTest()
        {
            // si la BD no está creada, la creará
            _unitOfWork = new UnitOfWork(new DatabaseContext());
        }

        [Fact]
        public void Test_Artist_Init()
        {
            // inserta los registros de prueba
            _unitOfWork.Artists.InsertarRegistrosPrueba();
            // hacer el commit
            _unitOfWork.Complete();
            // verificamos que se insertaron los registros
            var count = _unitOfWork.Artists.Count();
            count.Should().Be(6);
        }

        [Fact]
        public void Test_Connection_And_Count_Greater_Than_Zero()
        {

            var count = _unitOfWork.Artists.Count();
            count.Should().BeGreaterThan(0);
            //Assert.True(count > 0);
        }
    }
}
