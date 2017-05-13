using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SGMI.Models
{
    public class ContextoDb : DbContext
    {
        public ContextoDb() : base("Contexto"){}

        public DbSet<MembrosModel> Membros { get; set; }

        public DbSet<CidadeModels> Cidades { get; set; }

        public DbSet<EstadoModels> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            base.OnModelCreating(modelBuilder);
        }

    }
}