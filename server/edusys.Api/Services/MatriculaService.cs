using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace edusys.Api.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        private readonly IBaseRepository _baseRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IBaseRepository baseRepository, IMatriculaRepository matriculaRepository, Context context, IConfiguration configuration)
        {
            _baseRepository = baseRepository;
            _matriculaRepository = matriculaRepository;
            _context = context;
            _configuration = configuration;
        }

        public async Task Inserir(int alunoId, int cursoId)
        {
            try
            {

                string connection = _configuration.GetConnectionString("DefaultConnection");


                using (NpgsqlConnection npgsql = new NpgsqlConnection(connection))
                {
                    using (var cmd = new NpgsqlCommand("CALL inserir_aluno_com_matricula(:p_aluno_id, :p_curso_id)", npgsql))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("p_aluno_id", NpgsqlDbType.Integer, alunoId);
                        cmd.Parameters.AddWithValue("p_curso_id", NpgsqlDbType.Integer, cursoId);

                        npgsql.Open();
                        cmd.ExecuteNonQuery();
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Matricula> Atualizar(int matriculaId, Matricula model)
        {
            try
            {
                var matricula = await _matriculaRepository.ObterPeloId(matriculaId);
                if (matricula == null) return null;

                model.Id = matricula.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _matriculaRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int matriculaId)
        {
            try
            {

                var matricula = await _matriculaRepository.ObterPeloId(matriculaId);
                if (matricula == null) throw new Exception("Matricula não encontrado");


                _baseRepository.Delete<Matricula>(matricula);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Matricula> ObterPeloId(int matriculaId)
        {
            try
            {
                var matriculas = await _matriculaRepository.ObterPeloId(matriculaId);
                if (matriculas == null) return null;

                return matriculas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Matricula[]> ObterTodos()
        {
            try
            {
                var matriculas = await _matriculaRepository.ObterTodos();
                if (matriculas == null) return null;

                return matriculas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Matricula> ObterUltimaMatriculaInserida()
        {
            try
            {
                var query = "SELECT * FROM public.\"Matricula\" ORDER BY \"Id\" DESC LIMIT 1";

                // Executar a consulta usando o contexto do banco de dados
                var ultimaMatricula = await _context.Matricula.FromSqlRaw(query)
                    .Include(e => e.Aluno)
                    .Include(e => e.Curso)
                    .FirstOrDefaultAsync();

                return ultimaMatricula;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter a última matrícula inserida: " + ex.Message);
            }
        }
    }
}
