using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IBaseRepository baseRepository, IAlunoRepository alunoRepository)
        {
            _baseRepository = baseRepository;
            _alunoRepository = alunoRepository;
        }     

        public async Task<Aluno> Inserir(Aluno model)
        {
            try
            {
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
