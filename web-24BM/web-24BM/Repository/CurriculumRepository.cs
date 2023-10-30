using Microsoft.EntityFrameworkCore;
using web_24BM.Data;
using web_24BM.Models;
using web_24BM.Services;

namespace web_24BM.Repository
{
    public class CurriculumRepository
    {
        private readonly ApplicationDbContext _context;

        public CurriculumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Curriculum>> GetAll()
        {
            return await _context.curriculums.ToListAsync();
        }

        public async Task<int> Create(Curriculum model)
        {
            _context.curriculums.Add(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Curriculum model)
        {
            _context.curriculums.Update(model);
            return await _context.SaveChangesAsync();
        }
        public async Task<Curriculum> GetById(int IdEvidencia)
        {
            return _context.curriculums.Find(IdEvidencia);
            //return _context.EvidenciaAprendizajes.FirstOrDefault(x => x.Id == IdEvidencia);
            //return _context.EvidenciaAprendizajes.Where( x => x.Id == IdEvidencia);
        }

        public async Task<int> Delete(int IdCurriculum)
        {
            var curriculum = _context.curriculums.Find(IdCurriculum);
            _context.curriculums.Remove(curriculum);
            return await _context.SaveChangesAsync();
        }
    }
}
