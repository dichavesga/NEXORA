using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.Entities
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public int IdProvincia { get; set; }
        public bool? Estado { get; set; }
    }
}
