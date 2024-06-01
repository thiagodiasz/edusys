using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        /// <summary>
        /// Obter todos Alunos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("aluno")]
        public async Task<IActionResult> ObterTodosAlunos()
        {
            try
            {
                var alunos = await _alunoService.ObterTodos();
                if (alunos == null) return NotFound("Nenhum aluno encontrado");
                
                return Ok(alunos);
            }
            catch (Exception)
            {
        
                  return BadRequest("Ocorreu um erro ao salvar Aluno"); ;
            }
        }
        
        
        [HttpPost("aluno/inserir")]
        public async Task<IActionResult> Inserir([FromBody] Aluno model)
        {
            try
            {
            
                var aluno = await _alunoService.Inserir(model);

                if (aluno == null) return BadRequest("Erro ao inserir aluno");

                return Ok(new { message = "Aluno cadastrado com sucesso", aluno = aluno });
            }
            catch (Exception)
            {
        
                throw new Exception("Erro ao inserir aluno");
            }
           
        }

        /// <summary>
        /// Editar um Aluno.
        /// <param name="id">int</param>
        /// </summary>
        /// <returns></returns>
        [HttpPut("aluno/atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Aluno model)
        {
            try
            {
                var aluno = await _alunoService.Atualizar(id, model);

                if (aluno == null) return BadRequest("Erro ao atualizar aluno");

                return Ok(new { message = "Aluno cadastrado com sucesso", aluno = aluno });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Excluir um Aluno por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("aluno/excluir/{id}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            try
            {
                return await _alunoService.Excluir(id) ?
                Ok(new { message = "Aluno excluido com sucesso" }) :
                    BadRequest("Não foi possível excluir o aluno");
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
        [HttpGet("aluno/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            try
            {
                var alunos = await _alunoService.ObterPeloId(id);
                if (alunos == null) return NotFound("Nenhum aluno encontrado");
        
                return Ok(alunos);
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar Aluno");
            }
        }
        }    
}
