using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly Context _context;
        public NotaRepository(Context context)
        {
            _context = context;
        }
        //public void Task<T> Inserir(Nota Nota)
        //{
        //    //Execute procecedure             
        //    await _context.Nota.AddAsync(Nota);
        //    return Nota;
        //}

        public async Task<Nota> ObterPeloId(int notaId)
        {
            var nota = await _context.Nota
                           .AsNoTracking()
                            .Include(d => d.Disciplina)
                           .FirstOrDefaultAsync(a => a.Id == notaId);

            return nota;
        }

        public async Task<Nota[]> ObterTodos()
        {

            IQueryable<Nota> consulta = _context.Nota.AsNoTracking();

            consulta = consulta
                 .Include(d => d.Disciplina)
                 .Include(d => d.Matricula)
                 .ThenInclude(e => e.Aluno)
                 .Include(d => d.Matricula)
                 .ThenInclude(e => e.Curso);
            ;

            return await consulta.ToArrayAsync();
        }
    }
}
