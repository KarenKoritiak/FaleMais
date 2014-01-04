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
    public class TarifaRepository
    {
        public void InsereOuAtualiza(Tarifa tarifa)
        {
            using (var db = new FaleMaisContext())
            {
                db.Tarifas.AddOrUpdate(tarifa);
                db.SaveChanges();
            }
        }

        public void InsereOuAtualiza(List<Tarifa> tarifas)
        {
            using (var db = new FaleMaisContext())
            {
                db.Tarifas.AddOrUpdate(tarifas.ToArray());
                db.SaveChanges();
            }
        }
    }
}