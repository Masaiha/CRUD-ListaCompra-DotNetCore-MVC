using System;
using System.Collections.Generic;
using System.Text;

namespace Masanori.com.Business.Models
{
    public class Empresa : Entity
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }

        public List<Compra> Compras { get; set; }
    }
}
