using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.bo
{
    public class OrdenBO
    {
        public int codigo { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public bool estado { get; set; }
        public ClienteBO cliente { get; set; }
        public EmpleadoBO empleado { get; set; }
    }
}
