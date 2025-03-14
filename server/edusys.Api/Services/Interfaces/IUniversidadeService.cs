using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface IUniversidadeService
    {
        Task<Universidade> Inserir(Universidade model);
        Task<Universidade> Atualizar(int universidadeId, Universidade model);
        Task<bool> Excluir(int universidadeId);
        Task<Universidade> ObterPeloId(int universidadeId);
        Task<Universidade[]> ObterTodos();
    }
}
