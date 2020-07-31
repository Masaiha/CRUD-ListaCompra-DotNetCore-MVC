using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Models;
using Masanori.com.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Masanori.com.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MeuContexto contexto): base(contexto) { }

        public async Task<Empresa> ObterEmpresaEndereco(Guid EmpresaId)
        {
            return await Db.Empresas.AsNoTracking()
                            .Include(e => e.Endereco)
                            .FirstOrDefaultAsync(e => e.Id == EmpresaId);
        }

        public async Task<Empresa> ObterEmpresaPorCompra(Guid compraId)
        {
            var compraEmpresa = await Db.Compras.AsNoTracking()
                                .FirstOrDefaultAsync(c => c.Id == compraId);

            return await Db.Empresas.AsNoTracking()
                            .FirstOrDefaultAsync(e => e.Id == compraEmpresa.EmpresaId);
        }


    }
}
