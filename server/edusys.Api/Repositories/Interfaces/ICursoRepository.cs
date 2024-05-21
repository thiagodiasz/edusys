using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso> Inserir(Curso Curso);
        Task<Curso> Editar(Curso Curso);
        void Excluir(Curso Curso);
        Task<Curso> ObterPeloId(int CursoId);
        Task<IEnumerable<Curso>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
