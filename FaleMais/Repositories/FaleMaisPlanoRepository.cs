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
    public class FaleMaisPlanoRepository
    {
        private FaleMaisContext DBContext { get; set; }

        public FaleMaisPlanoRepository() 
        {
            this.DBContext = new FaleMaisContext();
        }

        public FaleMaisPlanoRepository(FaleMaisContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public List<FaleMaisPlano> RetornaTodos()
        {
            return (from FaleMaisPlano f in this.DBContext.FaleMaisPlanos
                    orderby f.Id
                    select f).ToList();
        }

        public FaleMaisPlano RetornaPorId(int id)
        {
            return (from FaleMaisPlano f in this.DBContext.FaleMaisPlanos
                    where f.Id == id
                    select f).FirstOrDefault();
        }

        public void InsereOuAtualiza(FaleMaisPlano faleMaisPlano)
        {
            this.DBContext.FaleMaisPlanos.AddOrUpdate(f => f.Nome, faleMaisPlano);
            this.DBContext.SaveChanges();
        }

        public void InsereOuAtualiza(List<FaleMaisPlano> faleMaisPlanos)
        {
            this.DBContext.FaleMaisPlanos.AddOrUpdate(f => f.Nome, faleMaisPlanos.ToArray());
            this.DBContext.SaveChanges();
        }
    }
}