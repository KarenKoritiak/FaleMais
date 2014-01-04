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
    public class CidadeRepository
    {
        public void Insere(List<Cidade> cidades)
        {
            foreach (var cidade in cidades)
                this.Insere(cidade);
        }

        public void Insere(Cidade cidade)
        {
            if (this.Existente(cidade)) return;

            using (var db = new FaleMaisContext())
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
            }
        }

        public bool Existente(Cidade cidade)
        {
            return this.RetornaPorEstadoENome(cidade.EstadoUF, cidade.Nome) != null;
        }

        public Cidade RetornaPorEstadoENome(string uf, string nome)
        {
            using (var db = new FaleMaisContext())
            {
                return (from Cidade c in db.Cidades
                        where c.EstadoUF == uf && c.Nome == nome
                        select c).FirstOrDefault();
            }
        }

        public List<Cidade> RetornaCidadesSemDDD()
        {
            DDDRepository dddRepository = new DDDRepository();

            using (var db = new FaleMaisContext())
            {
                return (from Cidade c in db.Cidades
                        where db.DDDs.FirstOrDefault(d => d.Cidades.Contains(c)) == null
                        select c).ToList();
            }
        }
    }
}