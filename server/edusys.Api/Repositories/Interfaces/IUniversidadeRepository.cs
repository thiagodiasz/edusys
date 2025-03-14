using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IUniversidadeRepository 
    {    
        Task<Universidade> ObterPeloId(int universidadeId);
        Task<Universidade[]> ObterTodos();
    }
}
