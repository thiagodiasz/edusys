using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<Matricula> Inserir(Matricula model);
        Task<Matricula> Atualizar(int matriculaId, Matricula model);
        Task<bool> Excluir(int matriculaId);
        Task<Matricula> ObterPeloId(int matriculaId);
        Task<Matricula[]> ObterTodos();
    }
}
