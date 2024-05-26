using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IEstadoRepository
    {
        Task<Professor> Inserir(Estado Estado);
        Task<Professor> Editar(Estado Estado);
        void Excluir(Estado Estado);
        Task<Estado> ObterPeloId(int EstadoId);
        Task<IEnumerable<Estado>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
