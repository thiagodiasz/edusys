using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;

namespace edusys.Api.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly Context _context;
        public MatriculaRepository(Context context)
        {
            _context = context;
        }
        public Task<Professor> Editar(Matricula Matricula)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Matricula EstaMatriculado)
        {
            throw new NotImplementedException();
        }

        public Task<Professor> Inserir(Matricula Matricula)
        {
            throw new NotImplementedException();
        }

        public Task<Matricula> ObterPeloId(int MatriculaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Matricula>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
