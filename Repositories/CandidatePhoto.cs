using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceApi.Repositories
{
    public class CandidatePhoto : ICandidatePhoto
    {
      

        private readonly ApplicationDbContext _context;
        public CandidatePhoto(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Data.CandidatePhoto candidatePhoto)
        {
            await _context.CandidatePhotos.AddAsync(candidatePhoto);
        }

        public async Task Delete(int id)
        {

            _context.CandidatePhotos.Remove(await _context.CandidatePhotos.FindAsync(id));
        }

        public async Task DeleteCandidatePhotos(int canidateId)
        {
            var cand = await _context.CandidatePhotos.Where(a => a.CandidateId == canidateId).ToListAsync();

            _context.RemoveRange(cand);
        }

        public async Task Update(Data.CandidatePhoto candidatePhoto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Find(int canidateId)
        {
          return  await _context.CandidatePhotos.AnyAsync(a => a.CandidateId == canidateId);
        }

        public async Task<Data.CandidatePhoto> Get(int id)
        {
            return await _context.CandidatePhotos.FindAsync(id);
        }

        public async Task<ICollection<Data.CandidatePhoto>> List()
        {
            return await _context.CandidatePhotos.ToListAsync();
        }

        public async Task<ICollection<Data.CandidatePhoto>> List(int candidateId)
        {
            return await _context.CandidatePhotos.Where(a => a.CandidateId == candidateId).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
