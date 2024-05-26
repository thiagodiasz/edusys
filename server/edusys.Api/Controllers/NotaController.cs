using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class NotaController : Controller
    {
        private readonly INotaRepository _notaRepository;

        public NotaController(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }
        /// <summary>
        /// Obter todos Notas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("nota/obterTodos")]
        public async Task<ActionResult<IEnumerable<Nota>>> ObterTodosNotas()
        {
            return Ok(await _notaRepository.ObterTodos());
        }


        [HttpPost("nota/cadastrarNota")]
        public async Task<ActionResult> CadastrarNota(Nota Nota)
        {
            await _notaRepository.Inserir(Nota);

            if (await _notaRepository.SaveAllAsync())
            {
                return Ok("Nota cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Nota");
        }

        /// <summary>
        /// Editar um Nota.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Nota/editarNota")]
        public async Task<ActionResult> EditarNota(Nota Nota)
        {
            await _notaRepository.Editar(Nota);

            if (await _notaRepository.SaveAllAsync())
            {
                return Ok("Nota editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Nota");
        }

        /// <summary>
        /// Excluir um Nota por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("nota/excluirNota/{id}")]
        public async Task<ActionResult> ExcluirNota(int id)
        {
            var nota = await _notaRepository.ObterPeloId(id);

            if (nota == null)
            {
                return NotFound("Nota não encontrado");
            }

            _notaRepository.Excluir(nota);

            if (await _notaRepository.SaveAllAsync())
            {
                return Ok("Nota excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Nota");
        }

        /// <summary>
        /// Obter Nota por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("nota/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var nota = await _notaRepository.ObterPeloId(id);

            if (nota == null)
            {
                return NotFound("Nota não encontrado");
            }

            return Ok(nota);
        }
    }
}
