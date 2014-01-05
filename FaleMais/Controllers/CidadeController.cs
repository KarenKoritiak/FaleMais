using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaleMais.Contexts;
using FaleMais.Models.Entities;
using FaleMais.Repositories;

namespace FaleMais.Controllers
{
    public class CidadeController : Controller
    {
        private FaleMaisContext DBContext = new FaleMaisContext();

        public JsonResult RetornaAutocomplete(string term)
        {
            CidadeRepository cidadeRepository = new CidadeRepository();
            var cidades = cidadeRepository.RetornaPorTermo(term);

            var itens = from Cidade c in cidades
                        select new { label = c.Nome, 
                                     value = c.DDDNumero };

            return Json(itens, JsonRequestBehavior.AllowGet);
        }

    }
}
