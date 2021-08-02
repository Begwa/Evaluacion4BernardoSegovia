using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion4Datos.DAL
{
    public class PuntosCargaDAL
    {
        public GestionEstacionesEntities dbEntites = new GestionEstacionesEntities();

        public List<PuntoCarga> GetAll()
        {
            return dbEntites.PuntoCarga.ToList();
        }

        public void Add(PuntoCarga p)
        {
            dbEntites.PuntoCarga.Add(p);
            dbEntites.SaveChanges();
        }

        public void Remove(int IdPtoCarga)
        {
            PuntoCarga p = dbEntites.PuntoCarga.Find(IdPtoCarga);

            dbEntites.PuntoCarga.Remove(p);

            dbEntites.SaveChanges();
        }

        public List<PuntoCarga> GetAll(int tipo)
        {
            var query = from p in dbEntites.PuntoCarga
                        where p.Tipo == tipo
                        select p;

            return query.ToList();
        }
    }
}
