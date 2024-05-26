using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<DisciplinaRepository> Inserir(DisciplinaRepository Disciplina);
        Task<DisciplinaRepository> Editar(DisciplinaRepository Disciplina);
        void Excluir(DisciplinaRepository Disciplina);
        Task<DisciplinaRepository> ObterPeloId(int DisciplinaId);
        Task<IEnumerable<DisciplinaRepository>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
