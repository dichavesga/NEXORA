using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.Entities.Catalogos
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string Descripcion { get; set; }
        public override string ToString() => IdProvincia + " " + Descripcion;
    }
}
