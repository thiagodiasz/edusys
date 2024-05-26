using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly Context _context;
        public ProfessorRepository(Context context)
        {
            _context = context;
        }
        public Task<Professor> Editar(Professor Professor)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Professor Professor)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> Inserir(Professor Professor)
        {
            await _context.Professor.AddAsync(Professor);
            return Professor;
        }

        public async Task<Professor> ObterPeloId(int ProfessorId)
        {
            var Professor = await _context.Professor.Where(x => x.Id == ProfessorId).FirstOrDefaultAsync();
            return Professor;
        }

        public async Task<IEnumerable<Professor>> ObterTodos()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
