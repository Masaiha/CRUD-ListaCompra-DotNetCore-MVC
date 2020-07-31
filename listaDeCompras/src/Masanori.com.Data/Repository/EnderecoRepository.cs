using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Models;
using Masanori.com.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Masanori.com.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuContexto contexto) : base(contexto)
        {

        }
        public async Task<Endereco> ObterEnderecoPorEmpresa(Guid EmpresaId)
        {
            return await Db.Enderecos.AsNoTracking()
                                .FirstOrDefaultAsync(e => e.EmpresaId == EmpresaId);

        }
    }
}
