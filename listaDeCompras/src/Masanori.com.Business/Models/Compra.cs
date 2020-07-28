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

        protected static DateTime DataCompra;
        protected static List<Produto> ListaProdutos;

        public static List<Produto> GetProdutos()
        {
            return ListaProdutos;
        }

        public static void AdicinaProduto(Produto produto)
        {
            ListaProdutos.Add(produto);
        }

    }
}
