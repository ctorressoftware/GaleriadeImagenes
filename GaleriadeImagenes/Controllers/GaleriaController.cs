using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GaleriadeImagenes.Controllers
{
    public class GaleriaController : Controller
    {
        // GET: Galeria
        public ActionResult Mostrar()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            return View();
        }
    }
}