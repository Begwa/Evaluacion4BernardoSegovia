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
    public partial class AgregarEstacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Region> regiones = new RegionesDAL().ObtenerRegiones();
                region.DataSource = regiones;
                region.DataTextField = "Nombre";
                region.DataValueField = "IdRegion";
                region.DataBind();
                CargarIDEstacion();
            }
        }

        protected void CargarIDEstacion()
        {
            List<Estacion> estaciones = EstacionesDAL.ObtenerEstaciones();
            int nuevoID;
            bool existe = false;
            if (estaciones == null)
            {
                nuevoID = 1;
            }
            else
            {
                nuevoID = estaciones.Count + 1;
                do
                {
                    foreach (Estacion e in estaciones)
                    {
                        if (e.IdEstacion == nuevoID)
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
            idestacion.Text = Convert.ToString(nuevoID);
            idestacion.Enabled = false;
        }

        protected void LimpiarCampos()
        {
            direccion.Text = "";
            region.SelectedValue = Convert.ToString(1);
            diainicio.SelectedValue = Convert.ToString(0);
            diatermino.SelectedValue = Convert.ToString(0);
            horainicio.Text = "";
            horacierre.Text = "";
            capacidad.Text = "";
        }

        protected void ValidarHoraInicio(object source, ServerValidateEventArgs args)
        {
            String horai = horainicio.Text.Trim();
            if (horainicio.Text.Trim() == "")
            {
                validarhorainicio.ErrorMessage = "ERROR: Debe ingresar una hora de inicio de atención.";
                args.IsValid = false;
            }
            else
            {
                String[] hi = horai.Split(':');
                if (hi.Length == 2)
                {
                    if (hi[0].Length == 2)
                    {
                        if (hi[1].Length == 2)
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            validarhorainicio.ErrorMessage = "ERROR: El largo de los minutos debe ser 2 dígitos.";
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        validarhorainicio.ErrorMessage = "ERROR: El largo de las horas debe ser 2 dígitos.";
                        args.IsValid = false;
                    }
                }
                else
                {
                    validarhorainicio.ErrorMessage = "ERROR: El formato de hora no es correcto.";
                    args.IsValid = false;
                }
            }
        }

        protected void ValidarHoraCierre(object source, ServerValidateEventArgs args)
        {
            String horac = horacierre.Text.Trim();
            if (horacierre.Text.Trim() == string.Empty)
            {
                validarhoracierre.ErrorMessage = "ERROR: Debe ingresar una hora de inicio de atención.";
                args.IsValid = false;
            }
            else
            {
                String[] hc = horac.Split(':');
                if (hc.Length == 2)
                {
                    if (hc[0].Length == 2)
                    {
                        if (hc[1].Length == 2)
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            validarhoracierre.ErrorMessage = "ERROR: El largo de los minutos debe ser 2 dígitos.";
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        validarhoracierre.ErrorMessage = "ERROR: El largo de las horas debe ser 2 dígitos.";
                        args.IsValid = false;
                    }
                }
                else
                {
                    validarhoracierre.ErrorMessage = "ERROR: El formato de hora no es correcto.";
                    args.IsValid = false;
                }
            }
        }

        protected void Agregar_BtnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Capturar valores que vienen del formulario
                int idest = Convert.ToInt32(idestacion.Text.Trim());
                String dir = direccion.Text.Trim();
                int idregion = Convert.ToInt32(region.SelectedValue);
                String diai = diainicio.Text.Trim();
                String diaf = diatermino.Text.Trim();
                String horai = horainicio.Text.Trim();
                String horaf = horacierre.Text.Trim();
                String horarioatencion = diai + " a " + diaf + ", de " + horai + " a " + horaf + " hrs.";
                int cap = Convert.ToInt32(capacidad.Text);

                //Creo objeto de la clase Estación
                Estacion estacion = new Estacion
                {
                    IdEstacion = idest,
                    Direccion = dir,
                    IdRegion = idregion,
                    Horario = horarioatencion,
                    CapPtosCarga = cap
                };

                //Guardo el objeto en la lista, muestro mensaje y actualizo campos
                if (EstacionesDAL.AgregarEstacion(estacion))
                {
                    lblmensaje.Text = "ÉXITO: Estación registrada satisfactoriamente";
                    CargarIDEstacion();
                    LimpiarCampos();
                }
                else
                {
                    lblmensaje.Text = "ERROR: La operación falló con éxito";
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int cant = Convert.ToInt32(capacidad.Text);
                if (cant < 0)
                {
                    validarcapacidad.ErrorMessage = "ERROR: La capacidad de puntos de carga tiene que ser superior a 0.";
                    args.IsValid = false;
                }
                else if (cant > 100)
                {
                    validarcapacidad.ErrorMessage = "ERROR: Ningna estación puede abarcar más de 100 puntos de carga.";
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            catch (FormatException ex)
            {
                validarcapacidad.ErrorMessage = "ERROR: La capacidad de puntos de carga debe ser un número.";
                args.IsValid = false;
            }
        }
    }
}