﻿using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class CursoService : ICursoService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ICursoRepository _cursoRepository;

        public CursoService(IBaseRepository baseRepository, ICursoRepository cursoRepository)
        {
            _baseRepository = baseRepository;
            _cursoRepository = cursoRepository;
        }     

        public async Task<Curso> Inserir(Curso model)
        {
            try
            {
                _baseRepository.Add<Curso>(model);
                if(await _baseRepository.SaveChangesAsync())
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
    }
}
