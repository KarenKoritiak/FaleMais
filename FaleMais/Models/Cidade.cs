﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaleMais.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string EstadoUF { get; set; }

        [ForeignKey("EstadoUF")]
        public virtual Estado Estado { get; set; }

        public string DDDNumero { get; set; }

        [ForeignKey("DDDNumero")]
        public virtual DDD DDD { get; set; }
    }
}