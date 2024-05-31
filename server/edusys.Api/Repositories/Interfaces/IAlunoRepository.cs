using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IAlunoRepository 
    {    
        Task<Aluno> ObterPeloId(int alunoId);
        Task<Aluno[]> ObterTodos();
    }
}
