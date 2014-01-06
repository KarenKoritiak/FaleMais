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
    public class EstadoRepository
    {
        private FaleMaisContext DBContext { get; set; }

        public EstadoRepository() 
        {
            this.DBContext = new FaleMaisContext();
        }

        public EstadoRepository(FaleMaisContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public void InsereOuAtualiza(Estado estado)
        {
            this.DBContext.Estados.AddOrUpdate(e => e.UF, estado);
            this.DBContext.SaveChanges();
        }

        public Estado RetornaPorUF(string uf)
        {
            return (from Estado e in this.DBContext.Estados
                    where e.UF == uf
                    select e).FirstOrDefault();
        }
    }
}