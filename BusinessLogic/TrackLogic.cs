using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class TrackLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
        }

        public string GetComposer(int id)
        {
            var list = _unitOfWork.Tracks.GetAll
                ().ToList();

            var record = list.FirstOrDefault(x => x.TrackId == id);

            if (record == null) return string.Empty;  

            return record.Composer;

        }

        public int GetComposerId(int id)
        {
            var record = _unitOfWork.Tracks.GetById(id);

            return record.TrackId;
        }
    }
}
