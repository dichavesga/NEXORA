using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool? Estado { get; set; }
        public int IdPerfil { get; set; }
    }
}
