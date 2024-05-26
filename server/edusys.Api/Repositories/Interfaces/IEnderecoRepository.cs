using edusys.Api.Entities;

namespace edusys.Api.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Professor> Inserir(Endereco Endereco);
        Task<Professor> Editar(Endereco Endereco);
        void Excluir(Endereco Endereco);
        Task<Endereco> ObterPeloId(int EnderecoId);
        Task<IEnumerable<Endereco>> ObterTodos();
        Task<bool> SaveAllAsync();
    }
}
