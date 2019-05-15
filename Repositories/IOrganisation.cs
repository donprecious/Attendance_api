using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
namespace AttendanceApi.Repositories
{
   public interface IOrganisation
   {
       Task Create(Data.Organisation organisation);

       Task Delete(int organisationId);

       Task Update(Data.Organisation organisation);
       Task<bool> Find(int organisationId);
        Task<Data.Organisation> Get(int organisationId);

        Task<ICollection<Data.Organisation>> List();
 
       Task<bool> Save();
    }
}
