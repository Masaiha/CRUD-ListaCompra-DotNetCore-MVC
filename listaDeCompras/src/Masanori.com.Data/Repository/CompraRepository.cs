using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Models;
using Masanori.com.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masanori.com.Data.Repository
{
    public class CompraRepository : Repository<Compra>,ICompraRepository
    {
        public CompraRepository(MeuContexto contexto) : base(contexto) { }

        public async Task<IEnumerable<Compra>> ObterTodasComprasEmpresas()
        {
            return await Db.Compras.AsNoTracking()
                            .Include(c => c.Empresa)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Compra>> ObterTodasEmpresas()
        {

            return await Db.Compras.AsNoTracking()
                            .Include(c => c.Empresa)
                            .ToListAsync();
        }

    }
}
