﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GaleriadeImagenes.Models
{
    public class ImagenComponente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public  Image Imagen { get; set; }
    }
}