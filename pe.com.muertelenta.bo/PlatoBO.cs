using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.bo
{
    public class PlatoBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio {  get; set; }
        public int cantidad {  get; set; }
        public DateTime fechaingreso { get; set; }
        public DateTime fechacaducidad { get; set; }
        public bool estado { get; set; }
        public TipoPlatoBO tipoplato { get; set; }
        public RefrigerablePlatoBO refrigerableplato { get; set; }
    }
}
