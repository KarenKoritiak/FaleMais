using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMais.Models
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
    }
}