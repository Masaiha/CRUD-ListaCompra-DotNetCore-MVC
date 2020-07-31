using Masanori.com.Business.Interfaces.Repository;
using Masanori.com.Business.Models;
using Masanori.com.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masanori.com.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuContexto contexto) : base(contexto) { }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCompra(Guid compraId)
        {
            return Db.Produtos.AsNoTracking()
                        .Include(p => p.Compra)
                        .Where(c => c.CompraId == compraId);
        }
    }
}
