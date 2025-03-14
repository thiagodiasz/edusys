using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly Context _context;
        public MatriculaRepository(Context context)
        {
            _context = context;
        }
        //public void Task<T> Inserir(Matricula Matricula)
        //{
        //    //Execute procecedure             
        //    await _context.Matricula.AddAsync(Matricula);
        //    return Matricula;
        //}

        public async Task<Matricula> ObterPeloId(int matriculaId)
        {
            var matricula = await _context.Matricula
                           .AsNoTracking()
                           .FirstOrDefaultAsync(a => a.Id == matriculaId);

            return matricula;
        }

        public async Task<Matricula[]> ObterTodos()
        {

            IQueryable<Matricula> consulta = _context.Matricula.AsNoTracking();

            consulta = consulta
                .Include(e => e.Aluno)
                .Include(e => e.Curso).OrderBy(x => x.Id);
            return await consulta.ToArrayAsync();
        }
    }
}
