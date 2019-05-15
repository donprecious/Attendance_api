using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Repositories
{
    public class OrganisationGroup: IOrganisationGroup
    {
        private readonly ApplicationDbContext _context;
        public OrganisationGroup(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Data.OrganisationGroup organisationGroup)
        {
           await _context.OrganisationGroups.AddAsync(organisationGroup);
        }

        public async Task Delete(int id)
        {
             _context.OrganisationGroups.Remove(await _context.OrganisationGroups.FindAsync(id));
        }

        public async Task DeleteByOrganisation(int orgId)
        {
            var org = await _context.OrganisationGroups.Where(a => a.OrganisationId == orgId).SingleOrDefaultAsync();
            _context.Remove(org);
        }

        public async Task Update(Data.OrganisationGroup organisationGroup)
        {
            throw new NotImplementedException();
        }

        public async Task<Data.OrganisationGroup> Get(int id)
        {
            return await _context.OrganisationGroups.FindAsync(id);
        }

        public async Task<ICollection<Data.OrganisationGroup>> List()
        {
            return await _context.OrganisationGroups.ToListAsync();

        }

        public async Task<ICollection<Data.OrganisationGroup>> OrganisationList(int orgId)
        {
            return await _context.OrganisationGroups.Where(a=>a.OrganisationId == orgId).ToListAsync();
        }

        public async Task<bool> FindOrganisation(int orgId)
        {
            return await _context.OrganisationGroups.AnyAsync(a => a.OrganisationId == orgId);

        }

        public async Task<bool> Find(int id)
        {
            return await _context.OrganisationGroups.AnyAsync(a => a.Id == id);

        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
