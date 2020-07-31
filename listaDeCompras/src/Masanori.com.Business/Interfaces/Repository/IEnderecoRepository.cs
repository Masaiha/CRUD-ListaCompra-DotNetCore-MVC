using Masanori.com.Business.Models;
using System;
using System.Threading.Tasks;

namespace Masanori.com.Business.Interfaces.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorEmpresa(Guid EmpresaId);
    }
}
