using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FaleMais.Models.Entities;

namespace FaleMais.Tests.Models
{
    [TestFixture]
    public class TarifaTest
    {
        private Tarifa tarifa = new Tarifa { OrigemNumero = "011", DestinoNumero = "017", ValorPorMinuto = 1.70m };

        [Test]
        public void CalculaValorLigacao()
        {
            var valorLigacao = tarifa.CalculaValor(80);
            Assert.AreEqual(136m, valorLigacao);
        }
    }
}
