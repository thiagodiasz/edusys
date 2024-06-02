using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface INotaService
    {
        Task<Nota> Inserir(Nota model);
        Task<Nota> Atualizar(int notaId, Nota model);
        Task<bool> Excluir(int notaId);
        Task<Nota> ObterPeloId(int notaId);
        Task<Nota[]> ObterTodos();
    }
}
