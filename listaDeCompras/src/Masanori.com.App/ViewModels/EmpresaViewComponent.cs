using System;
using System.Collections.Generic;

namespace Masanori.com.App.ViewModels
{
    public class EmpresaViewComponent
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public EnderecoViewComponent Endereco { get; set; }
        public List<CompraViewComponent> Compras { get; set; }
        public CompraViewComponent Compra { get; set; }
        public Guid CompraId { get; set; }
    }
}
