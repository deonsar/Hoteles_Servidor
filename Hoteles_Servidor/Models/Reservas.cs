using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public String Hotel { get; set; }
        public String FechaLlegada { get; set; }
        public String FechaSalida { get; set; }
        public int Habitaciones { get; set; }
        public int Adultos { get; set; }
        public int Ninos { get; set; }
        public double precioTotal { get; set; }

    }
}