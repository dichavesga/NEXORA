using Nexora.Capas.DAL;
using Nexora.Capas.Entities;
using Nexora.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Nexora.Capas.BLL
{
    public class BLLUsuario : IBLLUsuario
    {
        public Usuario Login(string pLogin, string pPassword)
        {
            IDALUsuario dalUsuario = new DALUsuario();

            // Encriptar la contraseña antes de enviarla al DAL
            //string cryptPasswd = Cryptography.EncrypthAES(pPassword);

            Usuario usuario = dalUsuario.Login(pLogin, pPassword);

            // Validación adicional (opcional pero recomendada)
            if (usuario != null && usuario.Estado == true)
            {
                return usuario;
            }

            return null;
        }

    }
}
