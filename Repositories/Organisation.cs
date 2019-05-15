using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Repositories
{

   
    public class Organisation: IOrganisation
    {
        private readonly ApplicationDbContext _context;
        public Organisation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Data.Organisation organisation)
        {
           await _context.Organisations.AddAsync(organisation);
        }

        public async Task Delete(int organisationId)
        {
            var org = await _context.Organisations.FindAsync(organisationId);
            _context.Remove(org);
        }

        public async Task<bool> Find(int organisationId)
        {
            return await _context.Organisations.AnyAsync(a=>a.Id == organisationId);
        }

        public async Task<Data.Organisation> Get(int organisationId)
        {
            return await _context.Organisations.Where(a => a.Id == organisationId).SingleOrDefaultAsync();
        }

        public async Task<ICollection<Data.Organisation>> List()
        {
            return await _context.Organisations.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }

        public Task Update(Data.Organisation organisation)
        {
            throw new NotImplementedException();
        }
    }
}
