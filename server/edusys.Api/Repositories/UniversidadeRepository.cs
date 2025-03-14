using edusys.Api.Entities;
using edusys.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace edusys.Api.Repositories
{
    public class UniversidadeRepository : IUniversidadeRepository
    {
        private readonly Context _context;
        public UniversidadeRepository(Context context)
        {
            _context = context;
        }
      
        public async Task<Universidade> ObterPeloId(int universidadeId)
        {
            var universidade = await _context.Universidade
                           .AsNoTracking()
                            .Include(a => a.Endereco)
                                .ThenInclude(e => e.Estado)
                            .Include(a => a.Telefone)
                           .FirstOrDefaultAsync(a => a.Id == universidadeId);

            return universidade;
        }

        public async Task<Universidade[]> ObterTodos()
        {

            IQueryable<Universidade> consulta = _context.Universidade.AsNoTracking();

            consulta = consulta
                 .Include(a => a.Endereco)
                 .ThenInclude(e => e.Estado)
                 .Include(a => a.Telefone).OrderBy(x => x.Id);
            return await consulta.ToArrayAsync();
        }      
    }
}
