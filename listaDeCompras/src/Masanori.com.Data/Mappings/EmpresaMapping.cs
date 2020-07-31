using Masanori.com.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masanori.com.Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasOne(em => em.Endereco)
                .WithOne(e => e.Empresa);

            builder.HasMany(e => e.Compras)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId);

            builder.ToTable("Empresas");
        }
    }
}
