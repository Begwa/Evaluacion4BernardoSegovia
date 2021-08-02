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
    public partial class AgregarPuntoCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Estacion> estaciones = EstacionesDAL.ObtenerEstaciones();
                estaciondesignada.DataSource = estaciones;
                estaciondesignada.DataTextField = "direccion";
                estaciondesignada.DataValueField = "idEstacion";
                estaciondesignada.DataBind();
                CargarIDPuntoCarga();
            }
        }

        protected void CargarIDPuntoCarga()
        {
            List<PuntoCarga> puntoscarga = PuntosCargaDAL.ObtenerPuntosCarga();
            int nuevoID;
            bool existe = false;
            if (puntoscarga == null)
            {
                nuevoID = 1;
            }
            else
            {
                nuevoID = puntoscarga.Count + 1;
                do
                {
                    foreach (PuntoCarga pc in puntoscarga)
                    {
                        if (pc.IdPtoCarga == nuevoID)
                        {
                            ++nuevoID;
                            existe = true;
                            break;
                        }
                        else
                        {
                            existe = false;
                        }
                    }
                } while (existe);
            }
            idpuntocarga.Text = Convert.ToString(nuevoID);
            idpuntocarga.Enabled = false;
        }

        protected void LimpiarCampos()
        {
            tipopunto.SelectedValue = Convert.ToString(1);
            capmaximaautos.Text = "";
            vidautil.Text = "";
        }

        protected void Agregar_BtnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int idpc = Convert.ToInt32(idpuntocarga.Text);
                int tpc = Convert.ToInt32(tipopunto.SelectedValue);
                int cvpc = Convert.ToInt32(capmaximaautos.Text);
                int idest = Convert.ToInt32(estaciondesignada.SelectedValue);
                String vupc = vidautil.Text;
                PuntoCarga puntocarga = new PuntoCarga();
                puntocarga.IdPtoCarga = idpc;
                puntocarga.Tipo = tpc;
                puntocarga.CapMaxAutos = cvpc;
                puntocarga.IdEstacion = idest;
                puntocarga.VidaUtil = vupc;
                if (PuntosCargaDAL.AgregarPuntoCarga(puntocarga))
                {
                    lblmensaje.Text = "ÉXITO: Punto de Carga registrado satisfactoriamente";
                    CargarIDPuntoCarga();
                    LimpiarCampos();
                }
                else
                {
                    lblmensaje.Text = "ERROR: La operación falló con éxito";
                }
            }
        }

        protected void validarvidautil_ServerValidate(object source, ServerValidateEventArgs args)
        {
            String vidau = vidautil.Text.Trim();
            if (vidau == string.Empty)
            {
                validarvidautil.ErrorMessage = "ERROR: Debe ingresar una fecha de finalización de vida útil.";
                args.IsValid = false;
            }
            else
            {
                String[] arreglovidautil = vidau.Split('-');
                if (arreglovidautil.Length == 3)
                {
                    if (arreglovidautil[0].Length == 2)
                    {
                        if (arreglovidautil[1].Length == 2)
                        {
                            if (arreglovidautil[2].Length == 4)
                            {
                                args.IsValid = true;
                            }
                            else
                            {
                                validarvidautil.ErrorMessage = "ERROR: El largo del año debe tener 4 dígitos.";
                                args.IsValid = false;
                            }
                        }
                        else
                        {
                            validarvidautil.ErrorMessage = "ERROR: El largo de los meses debe tener 2 dígitos.";
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        validarvidautil.ErrorMessage = "ERROR: El largo de los días debe tener 2 dígitos.";
                        args.IsValid = false;
                    }
                }
                else
                {
                    validarvidautil.ErrorMessage = "ERROR: El formato de fecha para vida útil no es correcto.";
                    args.IsValid = false;
                }
            }
        }

        protected void validarcapacidadautos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int capmax = Convert.ToInt32(capmaximaautos.Text);
                if (capmax < 1)
                {
                    validarcapacidadautos.ErrorMessage = "ERROR: La cantidad mínima de vehículos tiene que ser superior a 1.";
                    args.IsValid = false;
                }
                else if (capmax > 50)
                {
                    validarcapacidadautos.ErrorMessage = "ERROR: Ningún punto de carga puede atender a más de 50 vehículos.";
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            catch (FormatException ex)
            {
                validarcapacidadautos.ErrorMessage = "ERROR: La cantidad de vehículos debe ser un número.";
                args.IsValid = false;
            }
        }
    }
}