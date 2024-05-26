using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class EstadoController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoController(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
        /// <summary>
        /// Obter todos Estados.
        /// </summary>
        /// <returns></returns>
        [HttpGet("estado/obterTodos")]
        public async Task<ActionResult<IEnumerable<Estado>>> ObterTodosEstados()
        {
            return Ok(await _estadoRepository.ObterTodos());
        }


        [HttpPost("estado/cadastrarEstado")]
        public async Task<ActionResult> CadastrarEstado(Estado Estado)
        {
            await _estadoRepository.Inserir(Estado);

            if (await _estadoRepository.SaveAllAsync())
            {
                return Ok("Estado cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Estado");
        }

        /// <summary>
        /// Editar um Estado.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Estado/editarEstado")]
        public async Task<ActionResult> EditarEstado(Estado Estado)
        {
            await _estadoRepository.Editar(Estado);

            if (await _estadoRepository.SaveAllAsync())
            {
                return Ok("Estado editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Estado");
        }

        /// <summary>
        /// Excluir um Estado por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("estado/excluirEstado/{id}")]
        public async Task<ActionResult> ExcluirEstado(int id)
        {
            var estado = await _estadoRepository.ObterPeloId(id);

            if (estado == null)
            {
                return NotFound("Estado não encontrado");
            }

            _estadoRepository.Excluir(estado);

            if (await _estadoRepository.SaveAllAsync())
            {
                return Ok("Estado excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Estado");
        }

        /// <summary>
        /// Obter Estado por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("estado/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var estado = await _estadoRepository.ObterPeloId(id);

            if (estado == null)
            {
                return NotFound("Estado não encontrado");
            }

            return Ok(estado);
        }
    }
}
