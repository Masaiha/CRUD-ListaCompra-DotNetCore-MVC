using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Interfaces.Services;
using Masanori.com.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Masanori.com.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(ICompraRepository compraRepository, IProdutoRepository produtoRepository)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
        }

        public void Dispose()
        {
            _compraRepository?.Dispose();
            _produtoRepository?.Dispose();
        }
    }
}
