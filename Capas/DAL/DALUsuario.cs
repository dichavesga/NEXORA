using Nexora.Capas.Entities;
using Nexora.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.DAL
{
    public class DALUsuario : IDALUsuario
    {
        public Usuario Login(string pLogin, string pPassword)
        {
            IDbCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;

            command.CommandText = @"SELECT * 
                            FROM Usuario 
                            WHERE Login = @Login AND Clave = @Clave";

            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@Login", pLogin));
            command.Parameters.Add(new SqlParameter("@Clave", pPassword));

            using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
            {
                reader = db.ExecuteReader(command);

                while (reader.Read())
                {
                    oUsuario = new Usuario
                    {
                        IdUsuario = (int)reader["IdUsuario"],
                        Login = reader["Login"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        Estado = reader["Estado"] == DBNull.Value ? (bool?)null : (bool)reader["Estado"],
                        IdPerfil = (int)reader["IdPerfil"]
                    };
                }
            }

            return oUsuario;
        }
    }
}
