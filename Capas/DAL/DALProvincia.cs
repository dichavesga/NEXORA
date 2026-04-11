using Nexora.Capas.Entities.Catalogos;
using Nexora.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.DAL
{
    public class DALProvincia : IDALProvincia
    {
        //private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public bool Delete(int pId)
        {
            throw new Exception("Ud debe desarrollarlo!");
        }
        public List<Provincia> GetAll()
        {
            string msg = "";
            IDataReader reader = null;
            List<Provincia> lista = new List<Provincia>();
            SqlCommand command = new SqlCommand();
            string sql = @" select * from  Provincia WITH (NOLOCK)  ";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);
                    while (reader.Read())
                    {
                        // Mapping 
                        Provincia oProvincia = new Provincia();
                        oProvincia.IdProvincia = int.Parse(reader["IdProvincia"].ToString());
                        oProvincia.Descripcion = reader["Descripcion"].ToString();
                        lista.Add(oProvincia);
                    }
                }
                return lista;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Provincia GetById(int pId)
        {
            string msg = "";
            IDataReader reader = null;
            Provincia oProvincia = null;
            SqlCommand command = new SqlCommand();
            string sql = @" select * from  Provincia WITH (NOLOCK)  where IdProvincia = @IdProvincia ";
            command.Parameters.AddWithValue("@IdProvincia", pId);
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);
                    while (reader.Read())
                    {
                        // Mapping 
                        oProvincia = new Provincia();
                        oProvincia.IdProvincia = int.Parse(reader["IdProvincia"].ToString());
                        oProvincia.Descripcion = reader["Descripcion"].ToString();
                    }
                }
                return oProvincia;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
        public Provincia Save(Provincia pProvincia)
        {
            throw new Exception("Ud debe desarrollarlo!");
        }
        public Provincia Update(Provincia pProvincia)
        {
            throw new Exception("Ud debe desarrollarlo!");
        }
    }

}
