using System;
using System.Collections.Generic;
using System.Text;

namespace Masanori.com.Business.Models
{
    public abstract class Produto : Entity
    {
        public string Nome{ get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }

        public Compra Compra { get; set; }
    }
}
