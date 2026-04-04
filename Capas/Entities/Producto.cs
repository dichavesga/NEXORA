using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoInterno { get; set; }
        public string CodigoBarras { get; set; }
        public int IdTipoDispositivo { get; set; }
        public int IdMarca { get; set; }
        public string Color { get; set; }
        public string Caracteristicas { get; set; }
        public string Extras { get; set; }
        public decimal Precio { get; set; }
        public int? Stock { get; set; }
        public byte[] Foto { get; set; }
        public byte[] Documento { get; set; }
        public bool? Estado { get; set; }
        public string Modelo { get; set; }
    }
}
