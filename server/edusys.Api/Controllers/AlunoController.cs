using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class AlunoController : Controller
    {        
            private readonly IAlunoRepository _AlunoRepository;

            public AlunoController(IAlunoRepository AlunoRepository)
            {
                _AlunoRepository = AlunoRepository;
            }
            /// <summary>
            /// Obter todos Alunos.
            /// </summary>
            /// <returns></returns>
            [HttpGet("Aluno/obterTodos")]
            public async Task<ActionResult<IEnumerable<Aluno>>> ObterTodosAlunos()
            {
                return Ok(await _AlunoRepository.ObterTodos());
            }


            [HttpPost("Aluno/cadastrarAluno")]
            public async Task<ActionResult> CadastrarAluno(Aluno Aluno)
            {
                await _AlunoRepository.Inserir(Aluno);

                if (await _AlunoRepository.SaveAllAsync())
                {
                    return Ok("Aluno cadastrado com sucesso");
                }
                return BadRequest("Ocorreu um erro ao salvar Aluno");
            }

            /// <summary>
            /// Editar um Aluno.
            /// </summary>
            /// <returns></returns>
            [HttpPut("Aluno/editarAluno")]
            public async Task<ActionResult> EditarAluno(Aluno Aluno)
            {
                await _AlunoRepository.Editar(Aluno);

                if (await _AlunoRepository.SaveAllAsync())
                {
                    return Ok("Aluno editada com sucesso");
                }
                return BadRequest("Ocorreu um erro ao alterar Aluno");
            }

            /// <summary>
            /// Excluir um Aluno por Id.
            /// </summary>
            /// <param name="id">int</param>
            /// <returns></returns>
            [HttpDelete("Aluno/excluirAluno/{id}")]
            public async Task<ActionResult> ExcluirAluno(int id)
            {
                var Aluno = await _AlunoRepository.ObterPeloId(id);

                if (Aluno == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                _AlunoRepository.Excluir(Aluno);

                if (await _AlunoRepository.SaveAllAsync())
                {
                    return Ok("Usuário excluído com sucesso");
                }

                return BadRequest("Ocorreu um erro ao excluir um Usuário");
            }

            /// <summary>
            /// Obter Usuário por Id.
            /// </summary>
            /// <param name="id">int</param>
            /// <returns></returns>
            [HttpGet("Aluno/obterPorId/{id}")]
            public async Task<ActionResult> ObterPorId(int id)
            {
                var Aluno = await _AlunoRepository.ObterPeloId(id);

                if (Aluno == null)
                {
                    return NotFound("Empresa não encontrado");
                }

                return Ok(Aluno);
            }
        }    
}
