using Masanori.com.Business.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masanori.com.Business.Models
{
    public class Produto : Entity
    {
        public Guid CompraId { get; set; }
        public string Nome{ get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public double Peso { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public Compra Compra { get; set; }
    }
}
