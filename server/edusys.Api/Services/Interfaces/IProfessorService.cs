using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<Professor> Inserir(Professor model);
        Task<Professor> Atualizar(int professorId, Professor model);
        Task<bool> Excluir(int professorId);
        Task<Professor> ObterPeloId(int professorId);
        Task<Professor[]> ObterTodos();
    }
}
