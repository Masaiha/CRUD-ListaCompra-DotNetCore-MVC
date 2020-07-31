using System.Collections.Generic;

namespace Masanori.com.Business.Models
{
    public class Empresa : Entity
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Compra> Compras { get; set; }
    }
}
