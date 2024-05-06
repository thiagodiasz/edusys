using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task<Aluno> Inserir(Aluno Aluno);
        Task<Aluno> Editar(Aluno Aluno);
        void Excluir(Aluno Aluno);
        Task<Aluno> ObterPeloId(int AlunoId);
        Task<IEnumerable<Aluno>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
