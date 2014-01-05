﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaleMais.Contexts;
using FaleMais.Models.Entities;
using FaleMais.Models.Values;
using FaleMais.Repositories;

namespace FaleMais.Controllers
{
    public class TarifaController : Controller
    {
        private FaleMaisContext DBContext = new FaleMaisContext();

        public ActionResult Index()
        {
            var facade = this.CriaFacade();
            return View(facade);
        }

        private TarifaFacade CriaFacade(TarifaFacade facade = null)
        {
            if (facade == null)
                facade = new TarifaFacade();

            FaleMaisPlanoRepository faleMaisPlanoRepository = new FaleMaisPlanoRepository(this.DBContext);
            var planos = faleMaisPlanoRepository.RetornaTodos();

            DDDRepository dddRepository = new DDDRepository(this.DBContext);
            var origens = dddRepository.RetornaTodos();
            var destinos = dddRepository.RetornaDestinosPossiveis(facade.Tarifa == null ? origens.First().Numero : facade.Tarifa.OrigemNumero);

            return new TarifaFacade(planos, origens, destinos, facade.Tarifa, facade.Plano, facade.Minutos);
        }

        public JsonResult RetornaDestinos(string origemNumero)
        {
            DDDRepository dddRepository = new DDDRepository(this.DBContext);
            var destinos = dddRepository.RetornaDestinosPossiveis(origemNumero);

            return Json(destinos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Calcula(TarifaFacade facade)
        {
            if (!string.IsNullOrEmpty(facade.Tarifa.OrigemNumero) && !string.IsNullOrEmpty(facade.Tarifa.DestinoNumero))
            {

                TarifaRepository tarifaRepository = new TarifaRepository(this.DBContext);
                var tarifa = tarifaRepository.RetornaPorOrigemEDestino(facade.Tarifa.OrigemNumero, facade.Tarifa.DestinoNumero);

                FaleMaisPlanoRepository faleMaisPlanoRepository = new FaleMaisPlanoRepository();
                var plano = faleMaisPlanoRepository.RetornaPorId(facade.Plano.Id);

                ViewBag.FaleMaisValor = plano.CalculaTarifa(tarifa, facade.Minutos);
                ViewBag.TarifaComumValor = tarifa.CalculaValor(facade.Minutos);
            }

            return PartialView("Resultados");
        }
    }
}
