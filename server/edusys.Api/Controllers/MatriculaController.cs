using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class MatriculaController : Controller
    {
        public class InserirAlunoComMatriculaRequest
        {
            public int AlunoId {  get; set; }
            public int CursoId { get; set; }
        }

        private readonly IMatriculaService _matriculaService;
        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        /// <summary>
        /// Obter todos Matriculas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("matricula")]
        public async Task<IActionResult> ObterTodosMatriculas()
        {
            try
            {
                var matriculas = await _matriculaService.ObterTodos();
                if (matriculas == null) return NotFound("Nenhum matricula encontrado");

                return Ok(matriculas);
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao salvar Matricula"); ;
            }
        }
      

        [HttpPost("matricula/inserir")]
        public async Task<IActionResult> Inserir([FromBody] InserirAlunoComMatriculaRequest request)
        {
            try
            {

                await _matriculaService.Inserir(request.AlunoId, request.CursoId);
                var matriculas = await _matriculaService.ObterUltimaMatriculaInserida();

                return Ok(matriculas);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao inserir matricula");
            }

        }

        /// <summary>
        /// Editar um Matricula.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("matricula/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Matricula model)
        {
            try
            {
                var matricula = await _matriculaService.Atualizar(id, model);

                if (matricula == null) return BadRequest("Erro ao atualizar matricula");

                return Ok(new { message = "Matricula cadastrado com sucesso", matricula = matricula });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Matricula por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("matricula/excluir/{id}")]
        public async Task<IActionResult> ExcluirMatricula(int id)
        {
            try
            {
                return await _matriculaService.Excluir(id) ?
                Ok(new { message = "Matricula excluido com sucesso" }) :
                    BadRequest("Não foi possível excluir o matricula");
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
        [HttpGet("matricula/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var matriculas = await _matriculaService.ObterPeloId(id);
                if (matriculas == null) return NotFound("Nenhum matricula encontrado");

                return Ok(matriculas);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Matricula");
            }
        }
    }
}
