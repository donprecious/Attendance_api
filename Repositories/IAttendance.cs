using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
namespace AttendanceApi.Repositories
{
   public interface IAttendance
   {
       Task Create(Data.Attendance attendance);

       Task Delete(int id);

       Task DeleteCandidateRecord(int canidateId);

       //Task Update(Data.CandidatePhoto candidatePhoto);

       Task<bool> Find(int canidateId);
        Task<Data.Attendance> Get(int id);

        Task<ICollection<Data.Attendance>> List();

        Task<ICollection<Data.Attendance>> List(int orgId);
        Task<ICollection<Data.Attendance>> List(int orgId, int groupId, int candidateId);

        Task<bool> Save();
    }
}
