using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor> ObterPeloId(int professorId);
        Task<Professor[]> ObterTodos();
    }
}
