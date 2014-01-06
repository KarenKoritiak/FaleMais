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
    public class FaleMaisPlanoTest
    {
        private Tarifa tarifa = new Tarifa { OrigemNumero = "011", DestinoNumero = "017", ValorPorMinuto = 1.70m };
        private FaleMaisPlano plano = new FaleMaisPlano { Nome = "FaleMais 60", Minutos = 60, AcrescimoMinutosExcedentes = 10 };

        [Test]
        public void CalculaTarifaDentroDoPlano()
        {
            var valorLigacao = this.plano.CalculaTarifa(this.tarifa, 20);

            Assert.AreEqual(0, valorLigacao);
        }

        [Test]
        public void CalculaTarifaExcedente()
        {
            var valorLigacao = this.plano.CalculaTarifa(this.tarifa, 80);

            Assert.AreEqual(37.4m, valorLigacao);
        }
    }
}
