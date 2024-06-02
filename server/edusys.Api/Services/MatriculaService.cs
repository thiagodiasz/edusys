using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IBaseRepository baseRepository, IMatriculaRepository matriculaRepository)
        {
            _baseRepository = baseRepository;
            _matriculaRepository = matriculaRepository;
        }

        public async Task<Matricula> Inserir(Matricula model)
        {
            try
            {
                _baseRepository.Add<Matricula>(model);
                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _matriculaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Matricula> Atualizar(int matriculaId, Matricula model)
        {
            try
            {
                var matricula = await _matriculaRepository.ObterPeloId(matriculaId);
                if (matricula == null) return null;

                model.Id = matricula.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _matriculaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int matriculaId)
        {
            try
            {

                var matricula = await _matriculaRepository.ObterPeloId(matriculaId);
                if (matricula == null) throw new Exception("Matricula não encontrado");


                _baseRepository.Delete<Matricula>(matricula);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Matricula> ObterPeloId(int matriculaId)
        {
            try
            {
                var matriculas = await _matriculaRepository.ObterPeloId(matriculaId);
                if (matriculas == null) return null;

                return matriculas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Matricula[]> ObterTodos()
        {
            try
            {
                var matriculas = await _matriculaRepository.ObterTodos();
                if (matriculas == null) return null;

                return matriculas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
