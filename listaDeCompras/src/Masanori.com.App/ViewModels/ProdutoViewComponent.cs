using Masanori.com.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masanori.com.App.ViewModels
{
    public class ProdutoViewComponent
    {
        public Guid Id { get; set; }
        public Guid CompraId { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public double Peso { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public CompraViewComponent Compra { get; set; }

        public IEnumerable<CompraViewComponent> Compras { get; set; }
    }
}
