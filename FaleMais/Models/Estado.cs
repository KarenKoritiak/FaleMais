using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMais.Models
{
    public class Estado
    {
        [Key]
        public string UF { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual List<Cidade> Cidades { get; set; }
    }
}