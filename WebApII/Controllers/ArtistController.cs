using DataAccess;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using WebApII.Controllers;
using WebApII.Models;

namespace WebApII
{
    [RoutePrefix("api/artist")]
    public class ArtistController:ApiController
    {
      [HttpGet]
      [Route("GetAll")]
      public IEnumerable<Artist> GetAll()
        {
            using (var unitOfWork =
                new UnitOfWork(new DatabaseContext()))
            {
                return unitOfWork.Artists.GetAll();
            }
        }

        [HttpGet]
        [Route("GetByID/{id:int}")]
        public Artist GetById(int id)
        {
            using (var unitOfWork =
                new UnitOfWork(new DatabaseContext()))
            {
                return unitOfWork.Artists.GetById(id);
            }
        }

        [HttpPost]
        [Route("add")]
        public void Add(AddArtist request)
        {
            var param = new Artist { Name = request.Descripcion };
            using (var unitOfWork =
               new UnitOfWork(new DatabaseContext()))
            {
                  unitOfWork.Artists.Add(param);
                unitOfWork.Complete();
            }
        }

        [HttpPost]
        [Route("GetPaginatedArtistList")]
        public IEnumerable<GetArtistModel> GetPaginatedArtistList(GetArtist request)
        {
            using (var unitOfWork =
                new UnitOfWork(new DatabaseContext()))
            {
                return unitOfWork.Artists.PaginatedArtistList(request.SearchTerm,request.Page,request.Rows);
            }
        }
    }
}