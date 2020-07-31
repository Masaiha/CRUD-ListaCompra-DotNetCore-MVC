using System;
using System.Collections.Generic;

namespace Masanori.com.App.ViewModels
{
    public class CompraViewComponent
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid EmpresaId { get; set; }
        public DateTime DataCompra { get; }
        public IEnumerable<ProdutoViewComponent> Produtos { get; set; }
        public EmpresaViewComponent Empresa { get; set; }
        public IEnumerable<EmpresaViewComponent> Empresas { get; set; }
    }
}
