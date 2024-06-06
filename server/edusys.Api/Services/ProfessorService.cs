using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ProfessorService(IBaseRepository baseRepository, IProfessorRepository professorRepository, IEstadoRepository estadoRepository, IEnderecoRepository enderecoRepository)
        {
            _baseRepository = baseRepository;
            _professorRepository = professorRepository;
            _estadoRepository = estadoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Professor> Inserir(Professor model)
        {
            try
            {
                var estadoExistente = await _estadoRepository.ObterPeloId(model.Endereco.EstadoId);

                if (estadoExistente == null)
                {
                    throw new Exception("Estado não encontrado.");
                }

                var enderecoExistente = await _enderecoRepository.ObterPeloId(model.EnderecoId);


                if (enderecoExistente != null)
                {
                    model.Endereco = enderecoExistente;
                }

                _baseRepository.Add<Professor>(model);
                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _professorRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Professor> Atualizar(int professorId, Professor model)
        {
            try
            {
                var professor = await _professorRepository.ObterPeloId(professorId);
                if (professor == null) return null;

                model.Id = professor.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _professorRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int professorId)
        {
            try
            {

                var professor = await _professorRepository.ObterPeloId(professorId);
                if (professor == null) throw new Exception("Professor não encontrado");


                _baseRepository.Delete<Professor>(professor);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Professor> ObterPeloId(int professorId)
        {
            try
            {
                var professores = await _professorRepository.ObterPeloId(professorId);
                if (professores == null) return null;

                return professores;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Professor[]> ObterTodos()
        {
            try
            {
                var professores = await _professorRepository.ObterTodos();
                if (professores == null) return null;

                return professores;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
