using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.Entities
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? IVA { get; set; }
        public decimal? TotalLinea { get; set; }
    }
}
