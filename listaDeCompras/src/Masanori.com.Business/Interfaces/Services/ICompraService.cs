using Masanori.com.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masanori.com.Business.Interfaces.Services
{
    public interface ICompraService : IDisposable
    {
        Task<IEnumerable<Empresa>> ListaEmpresas();
    }
}
