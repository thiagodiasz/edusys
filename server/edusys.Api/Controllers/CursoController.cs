using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        /// <summary>
        /// Obter todos Cursos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("curso")]
        public async Task<IActionResult> ObterTodosCursos()
        {
            try
            {
                var cursos = await _cursoService.ObterTodos();
                if (cursos == null) return NotFound("Nenhum curso encontrado");
                
                return Ok(cursos);
            }
            catch (Exception)
            {
        
                  return BadRequest("Ocorreu um erro ao salvar Curso"); ;
            }
        }
        
        
        [HttpPost("curso/inserir")]
        public async Task<IActionResult> Inserir(Curso model)
        {
            try
            {
            
                var curso = await _cursoService.Inserir(model);

                if (curso == null) return BadRequest("Erro ao inserir curso");
                
                return Ok("Curso cadastrado com sucesso");
            }
            catch (Exception)
            {
        
                throw new Exception("Erro ao inserir curso");
            }
           
        }

        /// <summary>
        /// Editar um Curso.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("curso/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Curso model)
        {
            try
            {
                var curso = await _cursoService.Atualizar(id, model);

                if (curso == null) return BadRequest("Erro ao atualizar curso");
                
                return Ok("Curso atualizado com sucesso");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Curso por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("curso/excluir/{id}")]
        public async Task<IActionResult> ExcluirCurso(int id)
        {
            try
            {
                return await _cursoService.Excluir(id) ?
                Ok("Curso deletado"):
                    BadRequest("Não foi possível excluir o curso");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
        
        /// <summary>
        /// Obter Usuário por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("curso/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var cursos = await _cursoService.ObterPeloId(id);
                if (cursos == null) return NotFound("Nenhum curso encontrado");
        
                return Ok(cursos);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Curso");
            }
        }
        }    
}
