using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IProfessorRepository
    {
        Task<Professor> Inserir(Professor Professor);
        Task<Professor> Editar(Professor Professor);
        void Excluir(Professor Professor);
        Task<Professor> ObterPeloId(int ProfessorId);
        Task<IEnumerable<Professor>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
