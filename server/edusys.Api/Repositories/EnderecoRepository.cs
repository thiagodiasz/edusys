using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly Context _context;
        public EnderecoRepository(Context context)
        {
            _context = context;
        }
        public Task<Professor> Editar(Endereco Endereco)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Endereco Endereco)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> Inserir(Endereco Endereco)
        {
            throw new NotImplementedException();
        }

        public async Task<Endereco> ObterPeloId(int EnderecoId)
        {
            var endereco = await _context.Endereco
                         .AsNoTracking()                          
                         .FirstOrDefaultAsync(a => a.Id == EnderecoId);

            return endereco;
        }

        public Task<IEnumerable<Endereco>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
