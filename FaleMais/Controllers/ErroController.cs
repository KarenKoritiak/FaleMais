using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaleMais.Controllers
{
    public class ErroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaginaNaoEncontrada()
        {
            return View();
        }
    }
}
