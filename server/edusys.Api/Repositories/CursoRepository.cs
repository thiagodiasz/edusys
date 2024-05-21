using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly Context _context;
        public CursoRepository(Context context)
        {
            _context = context;
        }
        public Task<Curso> Editar(Curso Curso)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Curso Curso)
        {
            throw new NotImplementedException();
        }

        public async Task<Curso> Inserir(Curso Curso)
        {
            await _context.Curso.AddAsync(Curso);
            return Curso;
        }

        public async Task<Curso> ObterPeloId(int CursoId)
        {
            var Curso = await _context.Curso.Where(x => x.Id == CursoId).FirstOrDefaultAsync();
            return Curso;
        }

        public async Task<IEnumerable<Curso>> ObterTodos()
        {
            return await _context.Curso.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
