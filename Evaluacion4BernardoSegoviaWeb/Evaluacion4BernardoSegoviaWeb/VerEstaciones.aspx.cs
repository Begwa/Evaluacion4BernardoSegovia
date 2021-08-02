using System;
using Evaluacion4BernardoSegoviaWeb;
using Evaluacion4Datos;
using Evaluacion4Datos.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evaluacion4BernardoSegoviaWeb
{
    public partial class VerEstaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTablaEstaciones(EstacionesDAL.ObtenerEstaciones());
            }
        }

        protected void CargarTablaEstaciones(List<Estacion> estaciones)
        {
            estacionesGrid.DataSource = estaciones;
            estacionesGrid.DataBind();
        }

        protected void estacionesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                int ideliminar = Convert.ToInt32(e.CommandArgument);
                EstacionesDAL.EliminarEstacion(ideliminar);
                CargarTablaEstaciones(EstacionesDAL.ObtenerEstaciones());
            }
        }
    }
}