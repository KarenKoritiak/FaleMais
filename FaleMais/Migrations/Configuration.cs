namespace FaleMais.Migrations
{
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FaleMais.Contexts;
using FaleMais.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FaleMais.Contexts.FaleMaisContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FaleMais.Contexts.FaleMaisContext context)
        {
            var dddSeeds = new DDDSeeds();
            dddSeeds.AdicionarOuAtualizar();

            var estadoSeeds = new EstadoSeeds();
            estadoSeeds.AdicionarOuAtualizar();

            var cidadeSeeds = new CidadeSeeds();
            cidadeSeeds.AdicionarOuAtualizar();
            
            var tarifaSeeds = new TarifaSeeds();
            tarifaSeeds.AdicionarOuAtualizar();

            var faleMaisPlanoSeeds = new FaleMaisPlanoSeeds();
            faleMaisPlanoSeeds.AdicionarOuAtualizar();
        }
    }
}
