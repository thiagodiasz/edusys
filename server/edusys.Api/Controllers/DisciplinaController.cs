using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class DisciplinaController : Controller
    {
        private readonly IDisciplinaService _disciplinaService;
        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        /// <summary>
        /// Obter todos Disciplinas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("disciplina")]
        public async Task<IActionResult> ObterTodosDisciplinas()
        {
            try
            {
                var disciplinas = await _disciplinaService.ObterTodos();
                if (disciplinas == null) return NotFound("Nenhum disciplina encontrado");

                return Ok(disciplinas);
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao salvar Disciplina"); ;
            }
        }


        [HttpPost("disciplina/inserir")]
        public async Task<IActionResult> Inserir([FromBody] Disciplina model)
        {
            try
            {

                var disciplina = await _disciplinaService.Inserir(model);

                if (disciplina == null) return BadRequest("Erro ao inserir disciplina");

                return Ok(new { message = "Disciplina cadastrado com sucesso", disciplina = disciplina });
            }
            catch (Exception)
            {

                throw new Exception("Erro ao inserir disciplina");
            }

        }

        /// <summary>
        /// Editar um Disciplina.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("disciplina/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Disciplina model)
        {
            try
            {
                var disciplina = await _disciplinaService.Atualizar(id, model);

                if (disciplina == null) return BadRequest("Erro ao atualizar disciplina");

                return Ok(new { message = "Disciplina cadastrado com sucesso", disciplina = disciplina });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Disciplina por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("disciplina/excluir/{id}")]
        public async Task<IActionResult> ExcluirDisciplina(int id)
        {
            try
            {
                return await _disciplinaService.Excluir(id) ?
                Ok(new { message = "Disciplina excluido com sucesso" }) :
                    BadRequest("Não foi possível excluir o disciplina");
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
        [HttpGet("disciplina/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var disciplinas = await _disciplinaService.ObterPeloId(id);
                if (disciplinas == null) return NotFound("Nenhum disciplina encontrado");

                return Ok(disciplinas);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Disciplina");
            }
        }
    }
}
