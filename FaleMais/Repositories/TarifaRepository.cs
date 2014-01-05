using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using FaleMais.Contexts;
using FaleMais.Models.Entities;

namespace FaleMais.Repositories
{
    public class TarifaRepository
    {
        private FaleMaisContext DBContext { get; set; }

        public TarifaRepository() 
        {
            this.DBContext = new FaleMaisContext();
        }

        public TarifaRepository(FaleMaisContext dbContext)
        {
            this.DBContext = dbContext;
            this.DBContext.Configuration.ProxyCreationEnabled = false;
        }

        public void InsereOuAtualiza(Tarifa tarifa)
        {
            this.DBContext.Tarifas.AddOrUpdate(tarifa);
            this.DBContext.SaveChanges();
        }

        public void InsereOuAtualiza(List<Tarifa> tarifas)
        {
            this.DBContext.Tarifas.AddOrUpdate(tarifas.ToArray());
            this.DBContext.SaveChanges();
        }

        public List<Tarifa> RetornaPorOrigem(string origemNumero)
        {
            return (from Tarifa t in this.DBContext.Tarifas
                    where t.OrigemNumero == origemNumero
                    select t).ToList();
        }

        public Tarifa RetornaPorOrigemEDestino(string origemNumero, string destinoNumero)
        {
            return (from Tarifa t in this.DBContext.Tarifas
                    where t.OrigemNumero == origemNumero
                       && t.DestinoNumero == destinoNumero
                    select t).FirstOrDefault();
        }
    }
}