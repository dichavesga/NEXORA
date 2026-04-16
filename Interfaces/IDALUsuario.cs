using Nexora.Capas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Interfaces
{
    public interface IDALUsuario
    {
        Usuario Login(string pLogin, string pPassword);
    }
}
