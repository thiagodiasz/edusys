using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        /// <summary>
        /// Obter todos Professors.
        /// </summary>
        /// <returns></returns>
        [HttpGet("professor/obterTodos")]
        public async Task<ActionResult<IEnumerable<Professor>>> ObterTodosProfessors()
        {
            return Ok(await _professorRepository.ObterTodos());
        }


        [HttpPost("professor/cadastrarProfessor")]
        public async Task<ActionResult> CadastrarProfessor(Professor Professor)
        {
            await _professorRepository.Inserir(Professor);

            if (await _professorRepository.SaveAllAsync())
            {
                return Ok("Professor cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Professor");
        }

        /// <summary>
        /// Editar um Professor.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Professor/editarProfessor")]
        public async Task<ActionResult> EditarProfessor(Professor Professor)
        {
            await _professorRepository.Editar(Professor);

            if (await _professorRepository.SaveAllAsync())
            {
                return Ok("Professor editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Professor");
        }

        /// <summary>
        /// Excluir um Professor por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("professor/excluirProfessor/{id}")]
        public async Task<ActionResult> ExcluirProfessor(int id)
        {
            var professor = await _professorRepository.ObterPeloId(id);

            if (professor == null)
            {
                return NotFound("Professor não encontrado");
            }

            _professorRepository.Excluir(professor);

            if (await _professorRepository.SaveAllAsync())
            {
                return Ok("Professor excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Professor");
        }

        /// <summary>
        /// Obter Professor por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("professor/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var professor = await _professorRepository.ObterPeloId(id);

            if (professor == null)
            {
                return NotFound("Professor não encontrado");
            }

            return Ok(professor);
        }
    }
}
