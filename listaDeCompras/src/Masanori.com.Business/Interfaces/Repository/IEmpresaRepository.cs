using Masanori.com.Business.Models;
using System;
using System.Threading.Tasks;

namespace Masanori.com.Business.Interfaces.Repository
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Empresa> ObterEmpresaEndereco(Guid EmpresaId);
        Task<Empresa> ObterEmpresaPorCompra(Guid compraId);
    }
}
