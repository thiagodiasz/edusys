using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class CursoController : Controller
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        /// <summary>
        /// Obter todos Cursos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("curso/obterTodos")]
        public async Task<ActionResult<IEnumerable<Curso>>> ObterTodosCursos()
        {
            return Ok(await _cursoRepository.ObterTodos());
        }


        [HttpPost("curso/cadastrarCurso")]
        public async Task<ActionResult> CadastrarCurso(Curso Curso)
        {
            await _cursoRepository.Inserir(Curso);

            if (await _cursoRepository.SaveAllAsync())
            {
                return Ok("Curso cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Curso");
        }

        /// <summary>
        /// Editar um Curso.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Curso/editarCurso")]
        public async Task<ActionResult> EditarCurso(Curso Curso)
        {
            await _cursoRepository.Editar(Curso);

            if (await _cursoRepository.SaveAllAsync())
            {
                return Ok("Curso editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Curso");
        }

        /// <summary>
        /// Excluir um Curso por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("curso/excluirCurso/{id}")]
        public async Task<ActionResult> ExcluirCurso(int id)
        {
            var curso = await _cursoRepository.ObterPeloId(id);

            if (curso == null)
            {
                return NotFound("Curso não encontrado");
            }

            _cursoRepository.Excluir(curso);

            if (await _cursoRepository.SaveAllAsync())
            {
                return Ok("Curso excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Curso");
        }

        /// <summary>
        /// Obter Curso por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("curso/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var curso = await _cursoRepository.ObterPeloId(id);

            if (curso == null)
            {
                return NotFound("Curso não encontrado");
            }

            return Ok(curso);
        }
    }
}
