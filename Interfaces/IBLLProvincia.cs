using Nexora.Capas.Entities.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexora.Interfaces
{
    public interface IBLLProvincia
    {
        List<Provincia> GetAll();
        Provincia GetById(int pId);
        Provincia Save(Provincia pProvincia);
        List<Provincia> GetProvinciaFromInternet();
        bool Delete(int pId);
    }

}
