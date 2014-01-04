using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaleMais.Repositories;
using FaleMais.Models;

namespace FaleMais.Migrations
{
    public class TarifaSeeds
    {
        public void AdicionarOuAtualizar()
        {
            DDDRepository dddRepository = new DDDRepository();
            var ddd011 = dddRepository.RetornaPorNumero("011");
            var ddd016 = dddRepository.RetornaPorNumero("016");
            var ddd017 = dddRepository.RetornaPorNumero("017");
            var ddd018 = dddRepository.RetornaPorNumero("018");

            var tarifas = new List<Tarifa> {
                    new Tarifa { OrigemNumero = ddd011.Numero, DestinoNumero = ddd016.Numero, ValorPorMinuto = 1.90m },
                    new Tarifa { OrigemNumero= ddd016.Numero, DestinoNumero = ddd011.Numero, ValorPorMinuto = 2.90m },
                    new Tarifa { OrigemNumero= ddd011.Numero, DestinoNumero= ddd017.Numero, ValorPorMinuto = 1.70m },
                    new Tarifa { OrigemNumero= ddd017.Numero, DestinoNumero= ddd011.Numero, ValorPorMinuto = 2.70m },
                    new Tarifa { OrigemNumero= ddd011.Numero, DestinoNumero= ddd018.Numero, ValorPorMinuto = 0.90m },
                    new Tarifa { OrigemNumero = ddd018.Numero, DestinoNumero= ddd011.Numero, ValorPorMinuto = 1.90m } 
            };

            TarifaRepository tarifaRepository = new TarifaRepository();
            tarifaRepository.InsereOuAtualiza(tarifas);
        }
    }
}