using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoteles_Servidor.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public String FechaSalida { get; set; }
        public String FechaLlegada { get; set; }
        public String Hoteles { get; set; }
        public int Habitaciones { get; set; }
        public int Adultos { get; set; }
        public int Ninos { get; set; }
        public double PrecioTotal { get; set; }

    }
}