using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaleMais.Repositories;
using FaleMais.Models.Entities;
using FaleMais.Contexts;

namespace FaleMais.Migrations
{
    public class EstadoSeeds
    {
        public void AdicionarOuAtualizar()
        {
            EstadoRepository estadoRepository = new EstadoRepository();
            estadoRepository.InsereOuAtualiza(new Estado { UF = "SP", Nome = "São Paulo" });
        }
    }
}