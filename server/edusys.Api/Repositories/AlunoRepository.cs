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
        public Task<Aluno> Editar(Aluno Aluno)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Aluno Aluno)
        {
            throw new NotImplementedException();
        }

        public async Task<Aluno> Inserir(Aluno Aluno)
        {
            await _context.Aluno.AddAsync(Aluno);
            return Aluno;
        }

        public async Task<Aluno> ObterPeloId(int AlunoId)
        {
            var Aluno = await _context.Aluno.Where(x => x.Id == AlunoId).FirstOrDefaultAsync();
            return Aluno;
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
