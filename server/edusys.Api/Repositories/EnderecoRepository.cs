using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;

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

        public Task<Endereco> ObterPeloId(int EnderecoId)
        {
            throw new NotImplementedException();
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
