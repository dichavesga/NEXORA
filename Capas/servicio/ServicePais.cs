using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Electronics.Interfaces;
using UTN.Winform.Electronics.Layers.Entities;

namespace UTN.Winform.Electronics.Layers.Servicio
{
    class ServicePais : IServicePais
    {
        private static readonly ILog _MyLogControlEventos = LogManager.GetLogger("MyControlEventos");
       
        public List<Pais> GetAllPais()
        {
            

            HttpClient client = new HttpClient();
            string path = "";
            string json = "";
            try
            {
                path = @"https://restcountries.eu/rest/v2/all";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                json = sr.ReadToEnd();
                List<Pais> lista = JSONGeneric<List<Pais>>.JSonToObject(json);

                return lista;

            }
            catch (Exception er)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(UtilError.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;

            }
        }
    }
}
