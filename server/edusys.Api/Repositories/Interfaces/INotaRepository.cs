using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface INotaRepository
    {
        Task<Professor> Inserir(Nota Nota);
        Task<Professor> Editar(Nota Nota);
        void Excluir(Nota Nota);
        Task<Nota> ObterPeloId(int NotaId);
        Task<IEnumerable<Nota>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
