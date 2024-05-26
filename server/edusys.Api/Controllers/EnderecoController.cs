using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        /// <summary>
        /// Obter todos Enderecos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("endereco/obterTodos")]
        public async Task<ActionResult<IEnumerable<Endereco>>> ObterTodosEnderecos()
        {
            return Ok(await _enderecoRepository.ObterTodos());
        }


        [HttpPost("endereco/cadastrarEndereco")]
        public async Task<ActionResult> CadastrarEndereco(Endereco Endereco)
        {
            await _enderecoRepository.Inserir(Endereco);

            if (await _enderecoRepository.SaveAllAsync())
            {
                return Ok("Endereco cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Endereco");
        }

        /// <summary>
        /// Editar um Endereco.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Endereco/editarEndereco")]
        public async Task<ActionResult> EditarEndereco(Endereco Endereco)
        {
            await _enderecoRepository.Editar(Endereco);

            if (await _enderecoRepository.SaveAllAsync())
            {
                return Ok("Endereco editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Endereco");
        }

        /// <summary>
        /// Excluir um Endereco por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("endereco/excluirEndereco/{id}")]
        public async Task<ActionResult> ExcluirEndereco(int id)
        {
            var endereco = await _enderecoRepository.ObterPeloId(id);

            if (endereco == null)
            {
                return NotFound("Endereco não encontrado");
            }

            _enderecoRepository.Excluir(endereco);

            if (await _enderecoRepository.SaveAllAsync())
            {
                return Ok("Endereco excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Endereco");
        }

        /// <summary>
        /// Obter Endereco por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("endereco/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var endereco = await _enderecoRepository.ObterPeloId(id);

            if (endereco == null)
            {
                return NotFound("Endereco não encontrado");
            }

            return Ok(endereco);
        }
    }
}
