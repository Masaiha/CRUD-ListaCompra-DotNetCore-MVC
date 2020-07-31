using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Interfaces.Services;
using Masanori.com.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Masanori.com.Business.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public CompraService(ICompraRepository compraRepository, IEmpresaRepository empresaRepository)
        {
            _compraRepository = compraRepository;
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<Empresa>> ListaEmpresas()
        {
            return await _empresaRepository.ObterTodos();   
        }

        public Task<Empresa> ObterEmpresaCompra(Guid CompraId)
        {
            var empresa = _empresaRepository.ObterEmpresaPorCompra(CompraId);
            return empresa;
        }

        public void Dispose()
        {
            _compraRepository?.Dispose();
            _empresaRepository?.Dispose();
        }
    }
}
