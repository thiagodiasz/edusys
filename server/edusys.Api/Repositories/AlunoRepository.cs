using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly Context _context;
        public AlunoRepository(Context context)
        {
            _context = context;
        }
        //public void Task<T> Inserir(Aluno Aluno)
        //{
        //    //Execute procecedure             
        //    await _context.Aluno.AddAsync(Aluno);
        //    return Aluno;
        //}

        public async Task<Aluno> ObterPeloId(int alunoId)
        {
            var aluno = await _context.Aluno
                           .AsNoTracking()
                            .Include(a => a.Endereco)
                                .ThenInclude(e => e.Estado)
                            .Include(a => a.Telefone)
                           .FirstOrDefaultAsync(a => a.Id == alunoId);

            return aluno;
        }

        public async Task<Aluno[]> ObterTodos()
        {

            IQueryable<Aluno> consulta = _context.Aluno.AsNoTracking();

            consulta = consulta
                 .Include(a => a.Endereco)
                 .ThenInclude(e => e.Estado)
                 .Include(a => a.Telefone).OrderBy(x => x.Id);
            return await consulta.ToArrayAsync();
        }      
    }
}
