using System.Text.Json;
using Nexora.Capas.DAL;
using Nexora.Capas.Entities.Catalogos;
using Nexora.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Capas.BLL
{
    public class BLLProvincia : IBLLProvincia
    {
        public bool Delete(int pId)
        {
            IDALProvincia dalProvincia = new DALProvincia();
            return dalProvincia.Delete(pId);
        }
        public List<Provincia> GetAll()
        {
            IDALProvincia dalProvincia = new DALProvincia();
            return dalProvincia.GetAll();
        }
        public Provincia GetById(int pId)
        {
            IDALProvincia dalProvincia = new DALProvincia();
            return dalProvincia.GetById(pId);
        }
        /// <summary>
        /// Leerlo json de internet acceder https://github.com/lateraluz/Datos y buscar el archivo provincias.json
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        /// <exception cref=""></exception>
        public List<Provincia> GetProvinciaFromInternet()
        {
            Provincia provincia = null;
            string json = "";

            // Leer del App.Config el URL con el Key URLPadron
            string url = ConfigurationManager.AppSettings["URLProvincia"];


            // Creates a GET request to fetch  
            WebRequest request = WebRequest.Create(url);
            // Verb GET
            request.Method = "GET";


            // GetResponse returns a web response containing the response to the request
            using (WebResponse webResponse = request.GetResponse())
            {
                // Reading data
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                json = reader.ReadToEnd();
            }

            // Todas las provincias
            List<Provincia> lista = JsonSerializer.Deserialize<List<Provincia>>(json);


            return lista;

        }
        public Provincia Save(Provincia pProvincia)
        {
            IDALProvincia dalProvincia = new DALProvincia();
            Provincia oProvincia = null;
            if (dalProvincia.GetById(pProvincia.IdProvincia) == null)
                oProvincia = dalProvincia.Save(pProvincia);
            else
                oProvincia = dalProvincia.Update(pProvincia);
            return oProvincia;
        }
    }

}
