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

        public ProfessorService(IBaseRepository baseRepository, IProfessorRepository professorRepository, IEstadoRepository estadoRepository)
        {
            _baseRepository = baseRepository;
            _professorRepository = professorRepository;
            _estadoRepository = estadoRepository;
        }

        public async Task<Professor> Inserir(Professor model)
        {
            try
            {
                if (model.Endereco != null && model.Endereco.Estado != null)
                {
                    if (model.Endereco.EstadoId == 0)
                    {
                        model.Endereco.EstadoId = model.Endereco.Estado.Id;
                    }
                }
                model.Endereco.Estado = await _estadoRepository.ObterPeloId(model.Endereco.EstadoId);
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
