using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class NotaController : Controller
    {
        private readonly INotaService _notaService;
        public NotaController(INotaService notaService)
        {
            _notaService = notaService;
        }

        /// <summary>
        /// Obter todos Notas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("nota")]
        public async Task<IActionResult> ObterTodosNotas()
        {
            try
            {
                var notas = await _notaService.ObterTodos();
                if (notas == null) return NotFound("Nenhum nota encontrado");

                return Ok(notas);
            }
            catch (Exception)
            {

                return BadRequest("Ocorreu um erro ao salvar Nota"); ;
            }
        }


        [HttpPost("nota/inserir")]
        public async Task<IActionResult> Inserir([FromBody]Nota model)
        {
            try
            {

                var nota = await _notaService.Inserir(model);

                if (nota == null) return BadRequest("Erro ao inserir nota");

                return Ok(new { message = "Nota cadastrado com sucesso", nota = nota });
            }
            catch (Exception)
            {

                throw new Exception("Erro ao inserir nota");
            }

        }

        /// <summary>
        /// Editar um Nota.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("nota/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Nota model)
        {
            try
            {
                var nota = await _notaService.Atualizar(id, model);

                if (nota == null) return BadRequest("Erro ao atualizar nota");

                return Ok(new { message = "Nota cadastrado com sucesso", nota = nota });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Nota por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("nota/excluir/{id}")]
        public async Task<IActionResult> ExcluirNota(int id)
        {
            try
            {
                return await _notaService.Excluir(id) ?
                Ok(new { message = "Nota excluido com sucesso" }) :
                    BadRequest("Não foi possível excluir o nota");
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
        [HttpGet("nota/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var notas = await _notaService.ObterPeloId(id);
                if (notas == null) return NotFound("Nenhum nota encontrado");

                return Ok(notas);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Nota");
            }
        }
    }
}
