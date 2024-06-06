using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class NotaService : INotaService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly INotaRepository _notaRepository;
        private readonly ICursoRepository _cursoRepository;

        public NotaService(IBaseRepository baseRepository, INotaRepository notaRepository, ICursoRepository cursoRepository)
        {
            _baseRepository = baseRepository;
            _notaRepository = notaRepository;
            _cursoRepository = cursoRepository;
        }

        public async Task<Nota> Inserir(Nota model)
        {
            try
            {
                //if (model.Disciplina != null && model.Disciplina.Curso != null)
                //{
                //    if (model.Disciplina.CursoId == 0)
                //    {
                //        model.Disciplina.CursoId = model.Disciplina.Curso.Id;
                //    }
                //}
                //model.Disciplina.Curso = await _cursoRepository.ObterPeloId(model.Disciplina.CursoId);
                _baseRepository.Add<Nota>(model);
                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _notaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Nota> Atualizar(int notaId, Nota model)
        {
            try
            {
                var nota = await _notaRepository.ObterPeloId(notaId);
                if (nota == null) return null;

                model.Id = nota.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _notaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int notaId)
        {
            try
            {

                var nota = await _notaRepository.ObterPeloId(notaId);
                if (nota == null) throw new Exception("Nota não encontrado");


                _baseRepository.Delete<Nota>(nota);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Nota> ObterPeloId(int notaId)
        {
            try
            {
                var notas = await _notaRepository.ObterPeloId(notaId);
                if (notas == null) return null;

                return notas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Nota[]> ObterTodos()
        {
            try
            {
                var notas = await _notaRepository.ObterTodos();
                if (notas == null) return null;

                return notas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
