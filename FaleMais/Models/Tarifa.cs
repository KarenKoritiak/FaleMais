﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaleMais.Models
{
    public class Tarifa
    {
        public int Id { get; set; }

        public string OrigemNumero { get; set; }

        [ForeignKey("OrigemNumero"), Column(Order = 0)]
        public virtual DDD Origem { get; set; }

        public string DestinoNumero { get; set; }

        [ForeignKey("DestinoNumero"), Column(Order = 1)]
        public virtual DDD Destino { get; set; }

        [Required]
        public decimal ValorPorMinuto { get; set; }
    }
}