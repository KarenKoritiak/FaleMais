﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FaleMais.Models.Entities;
using FaleMais.Resources;

namespace FaleMais.Models.Values
{
    public class TarifaFacade
    {
        public TarifaFacade() { }

        public TarifaFacade(List<FaleMaisPlano> planos, List<DDD> origens, List<DDD> destinos, Tarifa tarifa, FaleMaisPlano plano, int minutos)
        {
            this.Planos = planos;
            this.Origens = origens;
            this.Destinos = destinos;

            if (tarifa == null)
                tarifa = new Tarifa { OrigemNumero = origens.First().Numero, DestinoNumero = destinos.First().Numero };
            this.Tarifa = tarifa;

            if (plano == null)
                plano = new FaleMaisPlano { Id = planos.First().Id };
            this.Plano = plano;

            if (minutos == 0)
                minutos = 1;
            this.Minutos = minutos;
        }

        public List<FaleMaisPlano> Planos { get; set; }
        public List<DDD> Origens { get; set; }
        public List<DDD> Destinos { get; set; }

        public Tarifa Tarifa { get; set; }
        public FaleMaisPlano Plano { get; set; }
        public int Minutos { get; set; }

        public bool Valido
        {
            get
            {
                return this.RetornaErrosDeValidacao().Count() == 0;
            }
        }

        public IEnumerable<ValidationResult> RetornaErrosDeValidacao()
        {
            if (string.IsNullOrEmpty(this.Tarifa.OrigemNumero))
                yield return new ValidationResult(string.Format(Mensagens.CampoObrigatorio, "origem da ligação"), new string[] { "Tarifa.OrigemNumero" }) ;

            if (string.IsNullOrEmpty(this.Tarifa.OrigemNumero))
                yield return new ValidationResult(string.Format(Mensagens.CampoObrigatorio, "destino da ligação"), new string[] { "Tarifa.DestinoNumero" }) ;

            yield break;
        }
    }
}