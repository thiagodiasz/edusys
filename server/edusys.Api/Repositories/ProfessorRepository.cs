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
        //public void Task<T> Inserir(Professor Professor)
        //{
        //    //Execute procecedure             
        //    await _context.Professor.AddAsync(Professor);
        //    return Professor;
        //}

        public async Task<Professor> ObterPeloId(int professorId)
        {
            var professor = await _context.Professor
                           .AsNoTracking()
                            .Include(a => a.Endereco)
                                .ThenInclude(e => e.Estado)
                            .Include(a => a.Telefone)
                           .FirstOrDefaultAsync(a => a.Id == professorId);

            return professor;
        }

        public async Task<Professor[]> ObterTodos()
        {

            IQueryable<Professor> consulta = _context.Professor.AsNoTracking();

            consulta = consulta
                 .Include(a => a.Endereco)
                 .ThenInclude(e => e.Estado)
                 .Include(a => a.Telefone).OrderBy(x => x.Id);
            return await consulta.ToArrayAsync();
        }
    }
}
