using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Repositories
{
    public class Candidate : ICandidate
    {
        private readonly ApplicationDbContext _context;
        public Candidate(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Data.Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
        }

        public async Task Delete(int id)
        {
            _context.Candidates.Remove(await _context.Candidates.FindAsync(id));
        }

        public async Task DeleteByCandidate(int canidateId)
        {
            throw new NotImplementedException();

        }

        public async Task Update(Data.Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Find(int canidateId)
        {
            return await _context.Candidates.AnyAsync(a => a.Id == canidateId);
        }

        public async Task<Data.Candidate> Get(int canidateId)
        {
            return await _context.Candidates.SingleOrDefaultAsync(a => a.Id == canidateId);
        }

        public async Task<ICollection<Data.Candidate>> List()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<ICollection<Data.Candidate>> List(int orgid)
        {
            return await _context.Candidates.Where(a => a.OrganisationGroupId == orgid).ToListAsync();
        }

        public async Task<ICollection<Data.Candidate>> List(int orgid, int OrggroupId)
        {
            return await _context.Candidates
                .Where(a => a.OrganisationGroupId == orgid && 
                            a.OrganisationGroupId == OrggroupId)
                .ToListAsync();

        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
