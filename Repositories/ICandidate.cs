using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
namespace AttendanceApi.Repositories
{
   public interface ICandidate
   {
       Task Create(Data.Candidate candidate);

       Task Delete(int id);
       Task DeleteByCandidate(int canidateId);
       Task Update(Data.Candidate candidate);

       Task<bool> Find(int canidateId);
        Task<Data.Candidate> Get(int canidateId);

        Task<ICollection<Data.Candidate>> List();
        Task<ICollection<Data.Candidate>> List(int orgid);
        Task<ICollection<Data.Candidate>> List(int orgid, int OrggroupId);

        Task<bool> Save();
    }
}
