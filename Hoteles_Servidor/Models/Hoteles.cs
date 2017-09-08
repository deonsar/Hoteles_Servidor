using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Models
{
    public class Hoteles
    {

        public int Id { get; set; }
        public String Nombre { get; set; }        
        public String Direccion { get; set; }
        public int CodigoPostal { get; set; }
        public String Telefono { get; set; }
        public int Puntuacion { get; set; }
        public double PrecioBase { get; set; }
        
    }
}