using edusys.Api.Entities;
using edusys.Api.Repositories;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoRepository _cursoRepository;

        public DisciplinaService(IBaseRepository baseRepository, IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository)
        {
            _baseRepository = baseRepository;
            _disciplinaRepository = disciplinaRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<Disciplina> Inserir(Disciplina model)
        {
            try
            {
                if (model.Curso != null && model.Curso != null)
                {
                    if (model.CursoId == 0)
                    {
                        model.CursoId = model.CursoId;
                    }
                }
                model.Curso = await _cursoRepository.ObterPeloId(model.CursoId);
                _baseRepository.Add<Disciplina>(model);
                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _disciplinaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Disciplina> Atualizar(int disciplinaId, Disciplina model)
        {
            try
            {
                var disciplina = await _disciplinaRepository.ObterPeloId(disciplinaId);
                if (disciplina == null) return null;

                model.Id = disciplina.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _disciplinaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int disciplinaId)
        {
            try
            {

                var disciplina = await _disciplinaRepository.ObterPeloId(disciplinaId);
                if (disciplina == null) throw new Exception("Disciplina não encontrado");


                _baseRepository.Delete<Disciplina>(disciplina);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Disciplina> ObterPeloId(int disciplinaId)
        {
            try
            {
                var disciplinas = await _disciplinaRepository.ObterPeloId(disciplinaId);
                if (disciplinas == null) return null;

                return disciplinas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Disciplina[]> ObterTodos()
        {
            try
            {
                var disciplinas = await _disciplinaRepository.ObterTodos();
                if (disciplinas == null) return null;

                return disciplinas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
