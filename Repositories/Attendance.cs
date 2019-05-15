using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Repositories
{
    public class Attendance : IAttendance
    {
        private readonly ApplicationDbContext _context;
        public Attendance(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Data.Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
        }

        public async Task Delete(int id)
        {
            _context.Attendances.Remove(await _context.Attendances.FindAsync(id));
        }

        public async Task DeleteCandidateRecord(int canidateId)
        {
            throw new NotImplementedException();



        }

        public async Task<bool> Find(int canidateId)
        {
            throw new NotImplementedException();
        }

        public async Task<Data.Attendance> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Data.Attendance>> List()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<ICollection<Data.Attendance>> List(int orgId)
        {
            return await _context.Attendances.Where(a => a.Candidate.OrganisationGroup.OrganisationId == orgId).ToListAsync();

        }

        public async Task<ICollection<Data.Attendance>> List(int orgId, int groupId, int candidateId)
        {
            return await _context.Attendances
                .Where(a =>
                    a.Candidate.OrganisationGroup.OrganisationId == orgId)
                .Where(a => a.Candidate.OrganisationGroupId == groupId)
                .Where(a => a.CandidateId == candidateId)
                .ToListAsync();

        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);

        }
    }
}
