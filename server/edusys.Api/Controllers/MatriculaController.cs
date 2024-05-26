using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }
        /// <summary>
        /// Obter todos Matriculas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("matricula/obterTodos")]
        public async Task<ActionResult<IEnumerable<Matricula>>> ObterTodosMatriculas()
        {
            return Ok(await _matriculaRepository.ObterTodos());
        }


        [HttpPost("matricula/cadastrarMatricula")]
        public async Task<ActionResult> CadastrarMatricula(Matricula Matricula)
        {
            await _matriculaRepository.Inserir(Matricula);

            if (await _matriculaRepository.SaveAllAsync())
            {
                return Ok("Matricula cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Matricula");
        }

        /// <summary>
        /// Editar um Matricula.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Matricula/editarMatricula")]
        public async Task<ActionResult> EditarMatricula(Matricula Matricula)
        {
            await _matriculaRepository.Editar(Matricula);

            if (await _matriculaRepository.SaveAllAsync())
            {
                return Ok("Matricula editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Matricula");
        }

        /// <summary>
        /// Excluir um Matricula por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("matricula/excluirMatricula/{id}")]
        public async Task<ActionResult> ExcluirMatricula(int id)
        {
            var matricula = await _matriculaRepository.ObterPeloId(id);

            if (matricula == null)
            {
                return NotFound("Matricula não encontrado");
            }

            _matriculaRepository.Excluir(matricula);

            if (await _matriculaRepository.SaveAllAsync())
            {
                return Ok("Matricula excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Matricula");
        }

        /// <summary>
        /// Obter Matricula por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("matricula/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var matricula = await _matriculaRepository.ObterPeloId(id);

            if (matricula == null)
            {
                return NotFound("Matricula não encontrado");
            }

            return Ok(matricula);
        }
    }
}
