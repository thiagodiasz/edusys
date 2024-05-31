using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<Aluno> Inserir(Aluno model);
        Task<Aluno> Atualizar(int alunoId, Aluno model);
        Task<bool> Excluir(int alunoId);
        Task<Aluno> ObterPeloId(int alunoId);
        Task<Aluno[]> ObterTodos();
    }
}
