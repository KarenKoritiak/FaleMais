using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaleMais.Repositories;
using FaleMais.Models.Entities;

namespace FaleMais.Migrations
{
    public class FaleMaisPlanoSeeds
    {
        public void AdicionarOuAtualizar()
        {
            var faleMaisPlanos = new List<FaleMaisPlano> {
                    new FaleMaisPlano { Nome ="FaleMais 30", Minutos = 30, AcrescimoMinutosExcedentes=10 } ,
                    new FaleMaisPlano { Nome ="FaleMais 60", Minutos = 60, AcrescimoMinutosExcedentes=10 } ,
                    new FaleMaisPlano { Nome ="FaleMais 120", Minutos = 120, AcrescimoMinutosExcedentes=10 } 
            };

            FaleMaisPlanoRepository faleMaisPlanoRepository = new FaleMaisPlanoRepository();
            faleMaisPlanoRepository.InsereOuAtualiza(faleMaisPlanos);
        }
    }
}