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
    public class CidadeRepository
    {
        private FaleMaisContext DBContext { get; set; }

        public CidadeRepository() 
        {
            this.DBContext = new FaleMaisContext();
        }

        public CidadeRepository(FaleMaisContext dbContext)
        {
            this.DBContext = dbContext;
        }

        public void Insere(List<Cidade> cidades)
        {
            foreach (var cidade in cidades)
                this.Insere(cidade);
        }

        public void Insere(Cidade cidade)
        {
            if (this.Existente(cidade)) return;

            this.DBContext.Cidades.Add(cidade);
            this.DBContext.SaveChanges();
        }

        public bool Existente(Cidade cidade)
        {
            return this.RetornaPorEstadoENome(cidade.EstadoUF, cidade.Nome) != null;
        }

        public Cidade RetornaPorEstadoENome(string uf, string nome)
        {
            return (from Cidade c in this.DBContext.Cidades
                    where c.EstadoUF == uf && c.Nome == nome
                    select c).FirstOrDefault();
        }

        public List<Cidade> RetornaPorTermo(string termo)
        {
            termo = termo.ToLower();

            return (from Cidade c in this.DBContext.Cidades
                    where c.Nome.ToLower().StartsWith(termo)
                    orderby c.Nome
                    select c).ToList();
        }

        public List<Cidade> RetornaCidadesSemDDD()
        {
            return (from Cidade c in this.DBContext.Cidades
                    where this.DBContext.DDDs.FirstOrDefault(d => d.Cidades.Contains(c)) == null
                    select c).ToList();
        }
    }
}