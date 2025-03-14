using edusys.Api.Entities;
using System.Diagnostics.Eventing.Reader;

namespace edusys.Api.Services.Interfaces
{
    public interface ICursoService
    {
        Task<Curso> Inserir(Curso model);
        Task<Curso> Atualizar(int cursoId, Curso model);
        Task<bool> Excluir(int cursoId);
        Task<Curso> ObterPeloId(int cursoId);
        Task<Curso[]> ObterTodos();
        Task<CursoDisciplina> InserirCursoDisciplina(CursoDisciplina model);
        Task<CursoDisciplina> AtualizarCursoDisciplina(int cursoId, CursoDisciplina model);
        Task<bool> ExcluirCursoDisciplina(int cursoId);
        Task<CursoDisciplina> ObterCursoDisciplinaPeloId(int cursoId);
        Task<CursoDisciplina[]> ObterTodosCursoDisciplina();



    }
}
