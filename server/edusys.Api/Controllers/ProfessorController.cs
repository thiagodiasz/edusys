using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        /// <summary>
        /// Obter todos Professores.
        /// </summary>
        /// <returns></returns>
        [HttpGet("professor")]
        public async Task<IActionResult> ObterTodosProfessores()
        {
            try
            {
                var professores = await _professorService.ObterTodos();
                if (professores == null) return NotFound("Nenhum professor encontrado");

                return Ok(professores);
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao salvar Professor"); ;
            }
        }


        [HttpPost("professor/inserir")]
        public async Task<IActionResult> Inserir([FromBody] Professor model)
        {
            try
            {

                var professor = await _professorService.Inserir(model);

                if (professor == null) return BadRequest("Erro ao inserir professor");

                return Ok(new { message = "Professor cadastrado com sucesso", professor = professor });
            }
            catch (Exception)
            {

                throw new Exception("Erro ao inserir professor");
            }

        }

        /// <summary>
        /// Editar um Professor.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("professor/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Professor model)
        {
            try
            {
                var professor = await _professorService.Atualizar(id, model);

                if (professor == null) return BadRequest("Erro ao atualizar professor");

                return Ok(new { message = "Professor cadastrado com sucesso", professor = professor });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Professor por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("professor/excluir/{id}")]
        public async Task<IActionResult> ExcluirProfessor(int id)
        {
            try
            {
                return await _professorService.Excluir(id) ?
                Ok(new { message = "Professor excluido com sucesso" }) :
                    BadRequest("Não foi possível excluir o professor");
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
        [HttpGet("professor/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var professores = await _professorService.ObterPeloId(id);
                if (professores == null) return NotFound("Nenhum professor encontrado");

                return Ok(professores);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Professor");
            }
        }
    }
}
