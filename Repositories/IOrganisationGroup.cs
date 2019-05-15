using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
namespace AttendanceApi.Repositories
{
   public interface IOrganisationGroup
   {
       Task Create(Data.OrganisationGroup organisationGroup);

       Task Delete(int id);
       Task DeleteByOrganisation(int orgId);

       

        Task Update(Data.OrganisationGroup organisationGroup);

       Task<Data.OrganisationGroup> Get(int id);
       
       Task<ICollection<Data.OrganisationGroup>> List();
    
       Task<ICollection<Data.OrganisationGroup>> OrganisationList(int orgId);

       Task<bool> FindOrganisation(int orgId);
       Task<bool> Find(int id);

        Task<bool> Save();
    }
}
