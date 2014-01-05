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
    public class DDDRepository
    {
        private FaleMaisContext DBContext { get; set; }

        public DDDRepository() 
        {
            this.DBContext = new FaleMaisContext();
        }

        public DDDRepository(FaleMaisContext dbContext)
        {
            this.DBContext = dbContext;
            this.DBContext.Configuration.ProxyCreationEnabled = false;
        }

        public void InsereOuAtualiza(DDD ddd)
        {
            this.DBContext.DDDs.AddOrUpdate(d => d.Numero, ddd);
            this.DBContext.SaveChanges();
        }

        public void InsereOuAtualiza(List<DDD> ddds)
        {
            this.DBContext.DDDs.AddOrUpdate(d => d.Numero, ddds.ToArray());
            this.DBContext.SaveChanges();
        }

        public DDD RetornaPorCidade(Cidade cidade)
        {
            return (from DDD d in this.DBContext.DDDs
                    where d.Cidades.Contains(cidade)
                    select d).FirstOrDefault();
        }

        public DDD RetornaPorNumero(string numero)
        {
            return (from DDD d in this.DBContext.DDDs
                    where d.Numero == numero
                    select d).FirstOrDefault();
        }

        public List<DDD> RetornaDestinosPossiveis(string origemNumero)
        {
            return (from Tarifa t in this.DBContext.Tarifas
                    where t.OrigemNumero == origemNumero
                    select t).Select(d => d.Destino).Distinct().OrderBy(d => d.Numero).ToList();
        }

        public List<DDD> RetornaTodos()
        {
            return (from DDD d in this.DBContext.DDDs
                    orderby d.Numero
                    select d).ToList();
        }
    }
}