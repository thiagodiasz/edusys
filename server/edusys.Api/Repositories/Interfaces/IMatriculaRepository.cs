using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula> ObterPeloId(int matriculaId);
        Task<Matricula[]> ObterTodos();
    }
}
