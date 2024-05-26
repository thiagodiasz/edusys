using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace edusys.Api.Controllers
{
    [ApiController]
    public class DisciplinaController : Controller
    {
        private readonly IDisciplinaRepository _disciplinaRepository;

        public DisciplinaController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }
        /// <summary>
        /// Obter todos Disciplinas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("disciplina/obterTodos")]
        public async Task<ActionResult<IEnumerable<Disciplina>>> ObterTodosDisciplinas()
        {
            return Ok(await _disciplinaRepository.ObterTodos());
        }


        [HttpPost("disciplina/cadastrarDisciplina")]
        public async Task<ActionResult> CadastrarDisciplina(Disciplina Disciplina)
        {
            await _disciplinaRepository.Inserir(Disciplina);

            if (await _disciplinaRepository.SaveAllAsync())
            {
                return Ok("Disciplina cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar Disciplina");
        }

        /// <summary>
        /// Editar um Disciplina.
        /// </summary>
        /// <returns></returns>
        [HttpPut("Disciplina/editarDisciplina")]
        public async Task<ActionResult> EditarDisciplina(Disciplina Disciplina)
        {
            await _disciplinaRepository.Editar(Disciplina);

            if (await _disciplinaRepository.SaveAllAsync())
            {
                return Ok("Disciplina editada com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar Disciplina");
        }

        /// <summary>
        /// Excluir um Disciplina por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpDelete("disciplina/excluirDisciplina/{id}")]
        public async Task<ActionResult> ExcluirDisciplina(int id)
        {
            var disciplina = await _disciplinaRepository.ObterPeloId(id);

            if (disciplina == null)
            {
                return NotFound("Disciplina não encontrado");
            }

            _disciplinaRepository.Excluir(disciplina);

            if (await _disciplinaRepository.SaveAllAsync())
            {
                return Ok("Disciplina excluído com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir um Disciplina");
        }

        /// <summary>
        /// Obter Disciplina por Id.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        [HttpGet("disciplina/obterPorId/{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var disciplina = await _disciplinaRepository.ObterPeloId(id);

            if (disciplina == null)
            {
                return NotFound("Disciplina não encontrado");
            }

            return Ok(disciplina);
        }
    }
}
