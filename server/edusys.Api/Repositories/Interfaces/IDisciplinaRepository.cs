using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<Disciplina> Inserir(Disciplina Disciplina);
        Task<Disciplina> Editar(Disciplina Disciplina);
        void Excluir(Disciplina Disciplina);
        Task<Disciplina> ObterPeloId(int DisciplinaId);
        Task<IEnumerable<Disciplina>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
