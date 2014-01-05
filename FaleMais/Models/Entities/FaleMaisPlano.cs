using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMais.Models.Entities
{
    public class FaleMaisPlano
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required]
        public int Minutos { get; set; }

        //Eventualmente o cliente pode decidir em mudar a porcentagem do acrescimo conforme o plano
        [Required]
        public int AcrescimoMinutosExcedentes { get; set; }

        /// <summary>
        /// Calcula o valor de uma ligação no plano, com base na tarifa de um DDD de origem para um DDD de destino
        /// </summary>
        /// <param name="tarifa">Objeto da tarifa do DDD de origem e DDD de destino</param>
        /// <param name="minutos">Minutos da ligação</param>
        /// <returns>Valor a ser pago pela ligação</returns>
        public decimal CalculaTarifa(Tarifa tarifa, int minutos)
        {
            var minutosExcedentes = minutos - this.Minutos;
            if (minutosExcedentes <= 0) return 0;

            return minutosExcedentes * (tarifa.ValorPorMinuto * (this.AcrescimoMinutosExcedentes / 100m + 1));
        }
    }
}