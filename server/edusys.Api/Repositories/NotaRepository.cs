using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;

namespace edusys.Api.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly Context _context;
        public NotaRepository(Context context)
        {
            _context = context;
        }
        public Task<Professor> Editar(Nota Nota)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Nota Nota)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> Inserir(Nota Nota)
        {
            throw new NotImplementedException();
        }

        public Task<Nota> ObterPeloId(int NotaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Nota>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
