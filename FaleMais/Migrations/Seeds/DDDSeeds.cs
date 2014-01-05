using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaleMais.Repositories;
using FaleMais.Models.Entities;

namespace FaleMais.Migrations
{
    public class DDDSeeds
    {
        public void AdicionarOuAtualizar()
        {
            var ddds = new List<DDD> {
                    new DDD { Numero ="011" } ,
                    new DDD { Numero ="016" } ,
                    new DDD { Numero ="017" } ,
                    new DDD { Numero ="018" } 
            };

            DDDRepository dddRepository = new DDDRepository();
            dddRepository.InsereOuAtualiza(ddds);
        }
    }
}
