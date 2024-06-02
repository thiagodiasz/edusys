using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> ObterPeloId(int notaId);
        Task<Nota[]> ObterTodos();
    }
}
