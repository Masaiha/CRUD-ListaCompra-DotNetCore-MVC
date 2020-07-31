using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Masanori.com.App.ViewModels;

namespace Masanori.com.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<Masanori.com.App.ViewModels.EmpresaViewComponent> EmpresaViewComponent { get; set; }
        //public DbSet<Masanori.com.App.ViewModels.CompraViewComponent> CompraViewComponent { get; set; }
        //public DbSet<Masanori.com.App.ViewModels.ProdutoViewComponent> ProdutoViewComponent { get; set; }
    }
}
