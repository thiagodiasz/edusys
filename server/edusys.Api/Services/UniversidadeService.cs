using edusys.Api.Entities;
using edusys.Api.Repositories;
using edusys.Api.Repositories.Interfaces;
using edusys.Api.Services.Interfaces;

namespace edusys.Api.Services
{
    public class UniversidadeService : IUniversidadeService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IUniversidadeRepository _universidadeRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public UniversidadeService(IBaseRepository baseRepository, IUniversidadeRepository universidadeRepository, IEstadoRepository estadoRepository, IEnderecoRepository enderecoRepository)
        {
            _baseRepository = baseRepository;
            _universidadeRepository = universidadeRepository;
            _estadoRepository = estadoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Universidade> Inserir(Universidade model)
        {
            try
            {
                var estadoExistente = await _estadoRepository.ObterPeloId(model.Endereco.EstadoId);

                if (estadoExistente == null)
                {
                    throw new Exception("Estado não encontrado.");
                }

                var enderecoExistente = await _enderecoRepository.ObterPeloId(model.EnderecoId);


                if (enderecoExistente != null)
                {
                    model.Endereco = enderecoExistente;
                }
                _baseRepository.Add<Universidade>(model);
                if(await _baseRepository.SaveChangesAsync())
                {
                    return await _universidadeRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Universidade> Atualizar(int universidadeId, Universidade model)
        {
            try
            {
                var universidade = await _universidadeRepository.ObterPeloId(universidadeId);
                if (universidade == null) return null;

                model.Id = universidade.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return await _universidadeRepository.ObterPeloId(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Excluir(int universidadeId)
        {
            try
            {
                
                var universidade = await _universidadeRepository.ObterPeloId(universidadeId);
                if (universidade == null) throw new Exception("Universidade não encontrado");


                _baseRepository.Delete<Universidade>(universidade);
                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Universidade> ObterPeloId(int universidadeId)
        {
            try
            {
                var universidades = await _universidadeRepository.ObterPeloId(universidadeId);
                if (universidades == null) return null;

                return universidades;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Universidade[]> ObterTodos()
        {
            try
            {
                var universidades = await _universidadeRepository.ObterTodos();
                if (universidades == null) return null;

                return universidades;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }            
        }
    }
}
