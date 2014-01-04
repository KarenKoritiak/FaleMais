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
    public class EstadoRepository
    {
        public void InsereOuAtualiza(Estado estado)
        {
            using (var db = new FaleMaisContext())
            {
                db.Estados.AddOrUpdate(e => e.UF, estado);
                db.SaveChanges();
            }
        }

        public Estado RetornaPorUF(string uf)
        {
            using (var db = new FaleMaisContext())
            {
                return (from Estado e in db.Estados
                        where e.UF == uf
                        select e).FirstOrDefault();
            }
        }
    }
}