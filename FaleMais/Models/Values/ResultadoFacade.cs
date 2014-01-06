using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMais.Models.Values
{
    public class ResultadoFacade
    {
        public ResultadoFacade() 
        {
            this.Erros = new List<ValidationResult>();
        }

        public decimal FaleMaisValor { get; set; }
        public decimal TarifaComumValor { get; set; }
        public List<ValidationResult> Erros { get; set; }

        public bool Valido
        {
            get
            {
                return this.Erros.Count() == 0;
            }
        }

        public bool TarifaNaoEncontrada
        {
            get
            {
                return this.FaleMaisValor == 0 && this.TarifaComumValor == 0;
            }
        }
    }
}