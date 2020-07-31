using System;
using System.Collections.Generic;

namespace Masanori.com.Business.Models
{
    public class Compra : Entity
    {
        public Compra()
        {
            DataCompra = DateTime.Now;
        }

        public Guid EmpresaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCompra { get; }

        public IEnumerable<Produto> Produtos;
        public Empresa Empresa { get; set; }
    }
}
