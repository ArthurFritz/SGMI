namespace SGMI.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SGMI.Models.ContextoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SGMI.Models.ContextoDb context)
        {
              context.Estados.AddOrUpdate(
                p => p.Id,
                new EstadoModels { Nome = "Acre", Sigla = "AC" },
                new EstadoModels { Nome = "Paraná", Sigla = "PR" },
                new EstadoModels { Nome = "São Paulo", Sigla = "SP" }
              );
            context.SaveChanges();
            
            context.Cidades.AddOrUpdate(
                p => p.Id,
                new CidadeModels { Nome = "Maringá", EstadoId= 2 },
                new CidadeModels { Nome = "Sarandi", EstadoId = 2 },
                new CidadeModels { Nome = "São Paulo", EstadoId = 3 }
              );
            context.SaveChanges();

        }
    }
}
