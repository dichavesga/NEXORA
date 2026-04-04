using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.Entities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public string IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMetodoPago { get; set; }
        public int? IdBanco { get; set; }
        public string NumeroTarjeta { get; set; }
        public string TipoTarjeta { get; set; }
        public string NumeroTransferencia { get; set; }
        public decimal? TipoCambio { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? IVA { get; set; }
        public decimal? Total { get; set; }
        public byte[] Firma { get; set; }
        public string XMLFactura { get; set; }
        public bool? Estado { get; set; }
    }
}
