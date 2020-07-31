using Masanori.com.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masanori.com.Business.Interfaces.Repository
{
    public interface ICompraRepository : IRepository<Compra> {

        Task<IEnumerable<Compra>> ObterTodasComprasEmpresas();
    }
}
