using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class UniversidadeController : Controller
    {
        private readonly IUniversidadeService _universidadeService;
        public UniversidadeController(IUniversidadeService universidadeService)
        {
            _universidadeService = universidadeService;
        }

        /// <summary>
        /// Obter todos Universidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet("universidade")]
        public async Task<IActionResult> ObterTodosUniversidades()
        {
            try
            {
                var universidades = await _universidadeService.ObterTodos();
                if (universidades == null) return NotFound("Nenhum universidade encontrado");
                
                return Ok(universidades);
            }
            catch (Exception)
            {
        
                  return BadRequest("Ocorreu um erro ao salvar Universidade"); ;
            }
        }
        
        
        [HttpPost("universidade/inserir")]
        public async Task<IActionResult> Inserir([FromBody] Universidade model)
        {
            try
            {
            
                var universidade = await _universidadeService.Inserir(model);

                if (universidade == null) return BadRequest("Erro ao inserir universidade");

                return Ok(new { message = "Universidade cadastrado com sucesso", universidade = universidade });
            }
            catch (Exception)
            {
        
                throw new Exception("Erro ao inserir universidade");
            }
           
        }

        /// <summary>
        /// Editar um Universidade.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("universidade/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Universidade model)
        {
            try
            {
                var universidade = await _universidadeService.Atualizar(id, model);

                if (universidade == null) return BadRequest("Erro ao atualizar universidade");

                return Ok(new { message = "Universidade cadastrado com sucesso", universidade = universidade });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Universidade por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("universidade/excluir/{id}")]
        public async Task<IActionResult> ExcluirUniversidade(int id)
        {
            try
            {
                return await _universidadeService.Excluir(id) ?
                Ok(new { message = "Universidade excluido com sucesso" }) :
                    BadRequest("Não foi possível excluir o universidade");
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
        [HttpGet("universidade/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var universidades = await _universidadeService.ObterPeloId(id);
                if (universidades == null) return NotFound("Nenhum universidade encontrado");
        
                return Ok(universidades);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Universidade");
            }
        }
        }    
}
