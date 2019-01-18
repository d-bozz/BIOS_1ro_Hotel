using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using EntidadesCompartidas;

public partial class ListadodeHabitacionesyReservas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            lblMensaje.Text = "";
            if (!IsPostBack)
            {
                Session["ListaHoteles"] = LogicaHoteles.ListarHoteles();
                if (((List<Hotel>)Session["ListaHoteles"]).Count != 0)
                {
                    cboHoteles.DataSource = (List<Hotel>)Session["ListaHoteles"];
                    cboHoteles.DataTextField = "NombreHotel";
                    cboHoteles.DataValueField = "NombreHotel";
                    cboHoteles.DataBind();
                }
                else
                    lblMensaje.Text = "No hay hoteles en la base de datos.";
            }

            //Muestro las Habitaciones para el Hotel Seleccionado.
            if (((List<Hotel>)Session["ListaHoteles"]).Count != 0)
            {
                Session["ListaHabitaciones"] = LogicaHabitaciones.ListarHabitaciones(LogicaHoteles.Buscar(cboHoteles.SelectedValue));
                if (((List<Habitacion>)Session["ListaHabitaciones"]).Count != 0)
                {
                    GVCompleto.DataSource = (List<Habitacion>)Session["ListaHabitaciones"];
                    GVCompleto.DataBind();
                    btnSeleccionar.Enabled = true;
                }
                else
                {
                    lblMensaje.Text = "No hay habitaciones en este hotel.";
                    GVCompleto.DataSource = null;
                    GVCompleto.DataBind();
                    Session["ListaHabitaciones"] = null;
                    GVSeleccion.DataSource = null;
                    GVSeleccion.DataBind();
                    btnSeleccionar.Enabled = false;
                }

                
            }

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }

    }

    protected void btnSeleccionar_Click(object sender, EventArgs e) 
    {
        try
        {
            //Muestro las reservas para la Habitacion seleccionada.
            if (GVCompleto.SelectedIndex != -1)
            {
                List<Habitacion> ListaH = (List<Habitacion>)Session["ListaHabitaciones"];
                List<Reserva> ListaRTodas = LogicaReservas.ListarReservasPorHabitacion(ListaH[GVCompleto.SelectedIndex]);
                List<Reserva> ListaRActivas = new List<Reserva>();
                List<Reserva> ListaRCanceladas = new List<Reserva>();
                List<Reserva> ListaRFinalizadas = new List<Reserva>();
                foreach (Reserva r in ListaRTodas)
                {
                    if (r.EstadoActual.ToLower() == "activa")
                        ListaRActivas.Add(r);
                    else if (r.EstadoActual.ToLower() == "cancelada")
                        ListaRCanceladas.Add(r);
                    else if (r.EstadoActual.ToLower() == "finalizada")
                        ListaRFinalizadas.Add(r);
                }

                switch (ddlReservas.SelectedValue.ToString())
                {
                    case "Todas":
                        if (ListaRTodas.Count != 0)
                        {
                            GVSeleccion.DataSource = ListaRTodas;
                            GVSeleccion.DataBind();
                        }
                        else
                        {
                            lblMensaje.Text = "No hay reservas asignadas a esta habitacion.";
                            GVSeleccion.DataSource = null;
                            GVSeleccion.DataBind();
                        }
                        break;
                    case "Activa":
                        if (ListaRActivas.Count != 0)
                        {
                            GVSeleccion.DataSource = ListaRActivas;
                            GVSeleccion.DataBind();
                        }
                        else
                        {
                            lblMensaje.Text = "No hay reservas activas asignadas a esta habitacion.";
                            GVSeleccion.DataSource = null;
                            GVSeleccion.DataBind();
                        }
                        break;
                    case "Cancelada":
                        if (ListaRCanceladas.Count != 0)
                        {
                            GVSeleccion.DataSource = ListaRCanceladas;
                            GVSeleccion.DataBind();
                        }
                        else
                        {
                            lblMensaje.Text = "No hay reservas canceladas asignadas a esta habitacion.";
                            GVSeleccion.DataSource = null;
                            GVSeleccion.DataBind();
                        }
                        break;
                    case "Finalizada":
                        if (ListaRFinalizadas.Count != 0)
                        {
                            GVSeleccion.DataSource = ListaRFinalizadas;
                            GVSeleccion.DataBind();
                        }
                        else
                        {
                            lblMensaje.Text = "No hay reservas finalizadas asignadas a esta habitacion.";
                            GVSeleccion.DataSource = null;
                            GVSeleccion.DataBind();
                        }
                        break;
                }
            }
            else
                lblMensaje.Text = "No se ha seleccionado una habitacion.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
}