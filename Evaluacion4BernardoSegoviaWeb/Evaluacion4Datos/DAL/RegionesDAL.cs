using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion4Datos.DAL
{
    public class RegionesDAL
    {
        public GestionEstacionesEntities dbEntites = new GestionEstacionesEntities();

        public List<Region> GetAll()
        {
            return dbEntites.Region.ToList();
        }
    }
}
