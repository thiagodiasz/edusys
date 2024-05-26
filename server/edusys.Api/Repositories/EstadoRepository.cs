using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;

namespace edusys.Api.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly Context _context;
        public EstadoRepository(Context context)
        {
            _context = context;
        }
        public Task<Professor> Editar(Estado Estado)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Estado Estado)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> Inserir(Estado Estado)
        {
            throw new NotImplementedException();
        }

        public Task<Estado> ObterPeloId(int EstadoID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estado>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
