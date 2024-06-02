using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface IDisciplinaService
    {
        Task<Disciplina> Inserir(Disciplina model);
        Task<Disciplina> Atualizar(int disciplinaId, Disciplina model);
        Task<bool> Excluir(int disciplinaId);
        Task<Disciplina> ObterPeloId(int disciplinaId);
        Task<Disciplina[]> ObterTodos();
    }
}
