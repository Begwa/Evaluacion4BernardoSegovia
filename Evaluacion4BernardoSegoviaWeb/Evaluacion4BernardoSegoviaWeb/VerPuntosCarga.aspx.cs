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
    public partial class VerPuntosCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPuntosCarga(PuntosCargaDAL.ObtenerPuntosCarga());
                String mensaje = Convert.ToString(Request.QueryString["mensaje"]);
                if (mensaje != string.Empty)
                {
                    lblmensaje.Text = mensaje;
                }
            }
        }

        protected void CargarPuntosCarga(List<PuntoCarga> puntoscarga)
        {
            puntoscargaGrid.DataSource = puntoscarga;
            puntoscargaGrid.DataBind();
        }

        protected void CargarEstaciones()
        {
            List<Estacion> estaciones = EstacionesDAL.ObtenerEstaciones();

        }

        protected void filtropornivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tiposeleccionado = Convert.ToInt32(filtropornivel.SelectedValue);
            if (tiposeleccionado == 1 || tiposeleccionado == 2)
            {
                List<PuntoCarga> filtrados = PuntosCargaDAL.FiltrarPorTipo(tiposeleccionado);
                CargarPuntosCarga(filtrados);
            }
            else
            {
                CargarPuntosCarga(PuntosCargaDAL.ObtenerPuntosCarga());
            }
        }

        protected void puntoscargaGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "actualizar")
            {
                int idpc = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ActualizarPuntoCarga.aspx?idPuntoCarga=" + idpc);
            }
        }
    }
}