using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Professor> Inserir(Matricula Matricula);
        Task<Professor> Editar(Matricula Matricula);
        void Excluir(Matricula EstaMatriculado);
        Task<Matricula> ObterPeloId(int MatriculaId);
        Task<IEnumerable<Matricula>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
