using edusys.Api.Entities;
using edusys.Api.Repositories;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class CursoService : ICursoService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ICursoRepository _cursoRepository;
        private IDisciplinaRepository _disciplinaRepository;


        public CursoService(IBaseRepository baseRepository, ICursoRepository cursoRepository, IDisciplinaRepository disciplinaRepository)
        {
            _baseRepository = baseRepository;
            _cursoRepository = cursoRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public async Task<Curso> Inserir(Curso model)
        {
            try
            {
                var cursoExistente = await _cursoRepository.ObterPeloId(model.Id);
                if (cursoExistente != null)
                {
                    throw new Exception("Já existe um curso com esse ID");
                }

                
                _baseRepository.Add<Curso>(model);

               

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _cursoRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public async Task<Curso> Atualizar(int cursoId, Curso model)
        {
            try
            {
                var curso = await _cursoRepository.ObterPeloId(cursoId);
                if (curso == null) return null;

                model.Id = curso.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _cursoRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int cursoId)
        {
            try
            {
                
                var curso = await _cursoRepository.ObterPeloId(cursoId);
                if (curso == null) throw new Exception("Curso não encontrado");


                _baseRepository.Delete<Curso>(curso);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Curso> ObterPeloId(int cursoId)
        {
            try
            {
                var cursos = await _cursoRepository.ObterPeloId(cursoId);
                if (cursos == null) return null;

                return cursos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Curso[]> ObterTodos()
        {
            try
            {
                var cursos = await _cursoRepository.ObterTodos();
                if (cursos == null) return null;

                return cursos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }            
        }

        #region CursoDisciplina
        public async Task<CursoDisciplina> InserirCursoDisciplina(CursoDisciplina model)
        {
            try
            {
                var cursoExistente = await _cursoRepository.ObterPeloId(model.CursoId);
                if (cursoExistente == null)
                {
                    throw new Exception("Curso não encontrado.");
                }

                var disciplinaExistente = await _disciplinaRepository.ObterPeloId(model.DisciplinaId);
                if (disciplinaExistente == null)
                {
                    throw new Exception("Disciplina não encontrada.");
                }

                // Apenas definindo as chaves estrangeiras
                model.Curso = null;
                model.Disciplina = null;

                _baseRepository.Add<CursoDisciplina>(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _cursoRepository.ObterCursoDisplinaPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<CursoDisciplina> InserirCursoDisciplina(CursoDisciplina model)
        //{
        //    try
        //    {
        //        var cursoExistente = await _cursoRepository.ObterPeloId(model.CursoId);
        //        if (cursoExistente != null)
        //        {
        //           model.Curso = cursoExistente;
        //        }

        //        var disciplina = await _disciplinaRepository.ObterPeloId(model.DisciplinaId);
        //        if (disciplina != null)
        //        {
        //           model.Disciplina = disciplina;
        //        }

        //        //model.Curso = cursoExistente;
        //        //model.Disciplina = model.Disciplina;

        //        _baseRepository.Add<CursoDisciplina>(model);



        //        if (await _baseRepository.SaveChangesAsync())
        //        {
        //            return await _cursoRepository.ObterCursoDisplinaPeloId(model.Id);
        //        }
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<CursoDisciplina> AtualizarCursoDisciplina(int cursoId, CursoDisciplina model)
        {
            try
            {
                var curso = await _cursoRepository.ObterPeloId(cursoId);
                if (curso == null) return null;

                model.Id = curso.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _cursoRepository.ObterCursoDisplinaPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExcluirCursoDisciplina(int cursoId)
        {
            try
            {

                var curso = await _cursoRepository.ObterCursoDisplinaPeloId(cursoId);
                if (curso == null) throw new Exception("Curso não encontrado");


                _baseRepository.Delete<CursoDisciplina>(curso);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CursoDisciplina> ObterCursoDisciplinaPeloId(int cursoId)
        {
            try
            {
                var cursos = await _cursoRepository.ObterCursoDisplinaPeloId(cursoId);
                if (cursos == null) return null;

                return cursos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CursoDisciplina[]> ObterTodosCursoDisciplina()
        {
            try
            {
                var cursos = await _cursoRepository.ObterTodosCursoDisciplina();
                if (cursos == null) return null;

                return cursos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
