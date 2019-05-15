using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
namespace AttendanceApi.Repositories
{
   public interface ICandidatePhoto
   {
       Task Create(Data.CandidatePhoto candidatePhoto);

       Task Delete(int id);

       Task DeleteCandidatePhotos(int canidateId);

       Task Update(Data.CandidatePhoto candidatePhoto);

       Task<bool> Find(int canidateId);
        Task<Data.CandidatePhoto> Get(int id);

        Task<ICollection<Data.CandidatePhoto>> List();
        Task<ICollection<Data.CandidatePhoto>> List(int candidateId);

        Task<bool> Save();
    }
}
