using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface ICursoRepository 
    {    
        Task<Curso> ObterPeloId(int cursoId);
        Task<Curso[]> ObterTodos();
        Task<CursoDisciplina> ObterCursoDisplinaPeloId(int cursoId);
        Task<CursoDisciplina[]> ObterTodosCursoDisciplina();

    }
}
