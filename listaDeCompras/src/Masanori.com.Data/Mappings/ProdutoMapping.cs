using Masanori.com.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masanori.com.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Marca)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal");
            
            builder.Property(p => p.Peso)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.TipoProduto)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Produtos");
        }
    }
}
