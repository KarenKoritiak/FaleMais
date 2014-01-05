using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaleMais.Models.Entities
{
    public class DDD
    {
        [Key]
        public string Numero { get; set; }

        public virtual List<Cidade> Cidades { get; set; }
    }
}