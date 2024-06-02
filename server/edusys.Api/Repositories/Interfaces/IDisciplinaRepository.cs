using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<Disciplina> ObterPeloId(int disciplinaId);
        Task<Disciplina[]> ObterTodos();
    }
}
