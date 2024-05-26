using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;

namespace edusys.Api.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly Context _context;
        public DisciplinaRepository(Context context)
        {
            _context = context;
        }
        public Task<DisciplinaRepository> Editar(DisciplinaRepository Disciplina)
        {
            throw new NotImplementedException();
        }

        public void Excluir(DisciplinaRepository Disciplina)
        {
            throw new NotImplementedException();
        }

        public Task<DisciplinaRepository> Inserir(DisciplinaRepository Disciplina)
        {
            throw new NotImplementedException();
        }

        public Task<DisciplinaRepository> ObterPeloId(int DisciplinaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DisciplinaRepository>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
