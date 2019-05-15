using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Repositories
{
    public class OrganisationUser: IOrganisationUser
    {
        private readonly ApplicationDbContext _context;
        public OrganisationUser(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Data.OrganisationUser organisation)
        {
            await _context.OrganisationUsers.AddAsync(organisation);
        }

        public async Task Delete(int id)
        {
            _context.OrganisationUsers.Remove(await _context.OrganisationUsers.FindAsync(id));
        }

        public async Task RemoveUser(string userId)
        {
            _context.OrganisationUsers.Remove(await _context.OrganisationUsers.Where(a=>a.UserId == userId).FirstOrDefaultAsync());
        }

        public async Task Update(Data.OrganisationUser organisation)
        {
            throw new NotImplementedException();
        }

        public async Task<Data.OrganisationUser> Get(int Id)
        {
            return await _context.OrganisationUsers.FindAsync(Id);
        }

        public async Task<ICollection<Data.OrganisationUser>> List()
        {
            return await _context.OrganisationUsers.ToListAsync();
        }

        public async Task<ICollection<Data.OrganisationUser>> OrganisationList(int orgId)
        {
            return await _context.OrganisationUsers.Where(a=>a.OrganisationId == orgId).ToListAsync();
        }

        public async Task<bool> FindUser(string userId)
        {
            return await _context.OrganisationUsers.AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> Save()
        {

            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
