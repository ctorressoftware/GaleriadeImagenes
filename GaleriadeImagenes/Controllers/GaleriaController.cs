using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GaleriadeImagenes.Models;

namespace GaleriadeImagenes.Controllers
{
    public class GaleriaController : Controller
    {
        // GET: Galeria
        public ActionResult Mostrar()
        {
            ImagenMantenimiento im = new ImagenMantenimiento();
            return View(im.ObtenerTodasLasImagenes());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(FormCollection form)
        {

            Imagen imagen = new Imagen
            {
                Nombre = form["nombre"].ToString(),
                ImagenUrl = form["url"].ToString()
            };

            ImagenMantenimiento im = new ImagenMantenimiento();

            im.AgregarImagen(imagen);

            return RedirectToAction("Mostrar", "Galeria");
        }
    }
}