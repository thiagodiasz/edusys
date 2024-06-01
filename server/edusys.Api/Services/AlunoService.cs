using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEstadoRepository _estadoRepository;

        public AlunoService(IBaseRepository baseRepository, IAlunoRepository alunoRepository, IEstadoRepository estadoRepository)
        {
            _baseRepository = baseRepository;
            _alunoRepository = alunoRepository;
            _estadoRepository = estadoRepository;
        }

        public async Task<Aluno> Inserir(Aluno model)
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
                _baseRepository.Add<Aluno>(model);
                if(await _baseRepository.SaveChangesAsync())
                {
                    return await _alunoRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Aluno> Atualizar(int alunoId, Aluno model)
        {
            try
            {
                var aluno = await _alunoRepository.ObterPeloId(alunoId);
                if (aluno == null) return null;

                model.Id = aluno.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _alunoRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int alunoId)
        {
            try
            {
                
                var aluno = await _alunoRepository.ObterPeloId(alunoId);
                if (aluno == null) throw new Exception("Aluno não encontrado");


                _baseRepository.Delete<Aluno>(aluno);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno> ObterPeloId(int alunoId)
        {
            try
            {
                var alunos = await _alunoRepository.ObterPeloId(alunoId);
                if (alunos == null) return null;

                return alunos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Aluno[]> ObterTodos()
        {
            try
            {
                var alunos = await _alunoRepository.ObterTodos();
                if (alunos == null) return null;

                return alunos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }            
        }
    }
}
