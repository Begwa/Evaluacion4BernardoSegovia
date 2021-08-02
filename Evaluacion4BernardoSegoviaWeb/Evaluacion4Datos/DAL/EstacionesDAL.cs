using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion4Datos.DAL
{
    public class EstacionesDAL
    {
        public GestionEstacionesEntities dbEntites = new GestionEstacionesEntities();

        public List<Estacion> GetAll()
        {
            return dbEntites.Estacion.ToList();
        }

        public void Add(Estacion e)
        {
            dbEntites.Estacion.Add(e);
            dbEntites.SaveChanges();
        }

        public void Remove(int IdEstacion)
        {
            Estacion e = dbEntites.Estacion.Find(IdEstacion);

            dbEntites.Estacion.Remove(e);

            dbEntites.SaveChanges();
        }
    }
}
