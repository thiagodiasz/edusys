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
        //public void Task<T> Inserir(Curso Curso)
        //{
        //    //Execute procecedure             
        //    await _context.Curso.AddAsync(Curso);
        //    return Curso;
        //}

        public async Task<Curso> ObterPeloId(int cursoId)
        {
            var curso = await _context.Curso
                           .AsNoTracking()
                           .FirstOrDefaultAsync(a => a.Id == cursoId);

            return curso;
        }

        public async Task<Curso[]> ObterTodos()
        {

            IQueryable<Curso> consulta = _context.Curso.AsNoTracking();

            consulta = consulta.Include(e => e.Disciplinas).OrderBy(x => x.Id);
            return await consulta.ToArrayAsync();
        }      
    }
}
