using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
namespace AttendanceApi.Repositories
{
   public interface IOrganisationUser
   {
       Task Create(Data.OrganisationUser organisation);

       Task Delete(int id);
       Task RemoveUser(string userId);

        Task Update(Data.OrganisationUser organisation);

       Task<Data.OrganisationUser> Get(int Id);
       
       Task<ICollection<Data.OrganisationUser>> List();
    
       Task<ICollection<Data.OrganisationUser>> OrganisationList(int orgId);

       Task<bool> FindUser(string userId);
        Task<bool> Save();
    }
}
