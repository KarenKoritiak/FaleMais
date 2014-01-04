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
    public class DDDRepository
    {
        public void InsereOuAtualiza(DDD ddd)
        {
            using (var db = new FaleMaisContext())
            {
                db.DDDs.AddOrUpdate(d => d.Numero, ddd);
                db.SaveChanges();
            }
        }

        public void InsereOuAtualiza(List<DDD> ddds)
        {
            using (var db = new FaleMaisContext())
            {
                db.DDDs.AddOrUpdate(d => d.Numero, ddds.ToArray());
                db.SaveChanges();
            }
        }

        public DDD RetornaPorCidade(Cidade cidade)
        {
            using (var db = new FaleMaisContext())
            {
                return (from DDD d in db.DDDs
                        where d.Cidades.Contains(cidade)
                        select d).FirstOrDefault();
            }
        }

        public DDD RetornaPorNumero(string numero)
        {
            using (var db = new FaleMaisContext())
            {
                return (from DDD d in db.DDDs
                        where d.Numero == numero
                        select d).FirstOrDefault();
            }
        }
    }
}