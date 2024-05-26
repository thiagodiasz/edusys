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

        public Task<Disciplina> Editar(Disciplina Disciplina)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Disciplina Disciplina)
        {
            throw new NotImplementedException();
        }

        public Task<Disciplina> Inserir(Disciplina Disciplina)
        {
            throw new NotImplementedException();
        }

        public Task<Disciplina> ObterPeloId(int DisciplinaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Disciplina>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
