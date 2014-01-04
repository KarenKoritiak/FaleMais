using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using FaleMais.Contexts;
using FaleMais.Models;

namespace FaleMais.Repositories
{
    public class FaleMaisPlanoRepository
    {
        public void InsereOuAtualiza(FaleMaisPlano faleMaisPlano)
        {
            using (var db = new FaleMaisContext())
            {
                db.FaleMaisPlanos.AddOrUpdate(f => f.Nome, faleMaisPlano);
                db.SaveChanges();
            }
        }

        public void InsereOuAtualiza(List<FaleMaisPlano> faleMaisPlanos)
        {
            using (var db = new FaleMaisContext())
            {
                db.FaleMaisPlanos.AddOrUpdate(f => f.Nome, faleMaisPlanos.ToArray());
                db.SaveChanges();
            }
        }
    }
}