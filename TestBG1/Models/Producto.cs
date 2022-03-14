using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBG1.Models
{
    public class Producto
    {
        public Producto() { }
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public float Price { get; set; }

        public float mrp { get; set; }

        public float stock { get; set; }

        public Boolean isPublished { get; set; }

    }
}
