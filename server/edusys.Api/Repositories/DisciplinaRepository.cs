using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly Context _context;
        public DisciplinaRepository(Context context)
        {
            _context = context;
        }
        //public void Task<T> Inserir(Disciplina Disciplina)
        //{
        //    //Execute procecedure             
        //    await _context.Disciplina.AddAsync(Disciplina);
        //    return Disciplina;
        //}

        public async Task<Disciplina> ObterPeloId(int disciplinaId)
        {
            var disciplina = await _context.Disciplina
                           .AsNoTracking()
                           .FirstOrDefaultAsync(a => a.Id == disciplinaId);

            return disciplina;
        }

        public async Task<Disciplina[]> ObterTodos()
        {

            IQueryable<Disciplina> consulta = _context.Disciplina.AsNoTracking();

            return await consulta.ToArrayAsync();
        }
    }
}
