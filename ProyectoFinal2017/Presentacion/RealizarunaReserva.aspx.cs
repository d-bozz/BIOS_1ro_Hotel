using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class RealizarunaReserva : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            switch (Convert.ToInt32(cboCategorias.SelectedValue))
            {
                case 1:
                    List<Hotel> ListaHoteles1 = LogicaHoteles.ListarHoteles(1);
                    GVHoteles.DataSource = ListaHoteles1;
                    GVHoteles.DataBind();
                    break;
                case 2:
                    List<Hotel> ListaHoteles2 = LogicaHoteles.ListarHoteles(2);
                    GVHoteles.DataSource = ListaHoteles2;
                    GVHoteles.DataBind();
                    break;
                case 3:
                    List<Hotel> ListaHoteles3 = LogicaHoteles.ListarHoteles(3);
                    GVHoteles.DataSource = ListaHoteles3;
                    GVHoteles.DataBind();
                    break;
                case 4:
                    List<Hotel> ListaHoteles4 = LogicaHoteles.ListarHoteles(4);
                    GVHoteles.DataSource = ListaHoteles4;
                    GVHoteles.DataBind();
                    break;
                case 5:
                    List<Hotel> ListaHoteles5 = LogicaHoteles.ListarHoteles(5);
                    GVHoteles.DataSource = ListaHoteles5;
                    GVHoteles.DataBind();
                    break;
            }
            if (!IsPostBack)
            {
                EstadoInicial();
                btnSeleccionarHab.Enabled = false;
            }
            if (((List<Hotel>)GVHoteles.DataSource).Count == 0)
            {
                btnSeleccionarHab.Enabled = false;
                btnSeleccionarhot.Enabled = false;
                GVHabitaciones.DataSource = null;
                GVHabitaciones.DataBind();
                EstadoInicial();
            }
            else btnSeleccionarhot.Enabled = true;
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnSeleccionarhot_Click(object sender, EventArgs e)
    {
        try
        {
            EstadoInicial();
            if (GVHoteles.SelectedIndex != -1)
            {
                int indice = GVHoteles.SelectedIndex;
                Hotel hotel = LogicaHoteles.Buscar(GVHoteles.Rows[GVHoteles.SelectedIndex].Cells[1].Text);
                List<Habitacion> ListaHab = LogicaHabitaciones.ListarHabitaciones(hotel);
                GVHabitaciones.DataBind();
                if (ListaHab.Count > 0)
                {
                    GVHabitaciones.DataSource = ListaHab;
                    GVHabitaciones.DataBind();
                    btnSeleccionarHab.Enabled = true;
                }
                else
                {
                    GVHabitaciones.DataSource = null;
                    GVHabitaciones.DataBind();
                    btnSeleccionarHab.Enabled = false;
                    lblMensaje.Text = "El hotel no tiene habitaciones";
                }
            }
            else
                lblMensaje.Text = "Seleccione un hotel primero.";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void cboHoteles_SelectedIndexChanged(object sender, EventArgs e)
    {
        EstadoInicial();
        GVHabitaciones.DataSource = null;
        GVHabitaciones.DataBind();
    }

    protected void btnReservar_Click(object sender, EventArgs e)
    {
        try
        {
            Hotel hot = LogicaHoteles.Buscar(GVHoteles.Rows[GVHoteles.SelectedIndex].Cells[1].Text);
            Habitacion hab = LogicaHabitaciones.Buscar(hot, Convert.ToInt32(GVHabitaciones.Rows[GVHabitaciones.SelectedIndex].Cells[1].Text));
            Reserva r = new Reserva(hab, (Cliente)Session["usuario"], cldFechaInicio.SelectedDate, cldFechaFin.SelectedDate, "Activa", 1);
            LogicaReservas.RealizarRes(r);
            EstadoInicial();
            lblMensaje.Text = "Se ha realizado la reseva con exito";            
            GVHoteles.DataSource = null;
            GVHoteles.DataBind();
            GVHabitaciones.DataSource = null;
            GVHabitaciones.DataBind();
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    protected void btnSeleccionarHab_Click(object sender, EventArgs e)
    {
        try
        {
            if (GVHabitaciones.SelectedIndex != -1)
            {
                Hotel hot = LogicaHoteles.Buscar(GVHoteles.Rows[GVHoteles.SelectedIndex].Cells[1].Text);
                Habitacion hab = LogicaHabitaciones.Buscar(hot, Convert.ToInt32(GVHabitaciones.Rows[GVHabitaciones.SelectedIndex].Cells[1].Text));
                lblHabitacion.Text = "Seleccion: " + hab.ToString();
                btnCalcularCosto.Enabled = true;
                btnReservar.Enabled = false;
            }
            lblMensaje.Text = "Seleccione una habitacion primero.";

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    protected void btnCalcularCosto_Click(object sender, EventArgs e)
    {
        try
        {
            lblCostoTotal.Text = "";
            lblMensaje.Text = "";
            int dias = Convert.ToInt32((cldFechaFin.SelectedDate - cldFechaInicio.SelectedDate).TotalDays);            
            if (GVHoteles.SelectedIndex != -1 && GVHabitaciones.SelectedIndex != -1)
            {
                Hotel hot = LogicaHoteles.Buscar(GVHoteles.Rows[GVHoteles.SelectedIndex].Cells[1].Text);
                Habitacion hab = LogicaHabitaciones.Buscar(hot, Convert.ToInt32(GVHabitaciones.Rows[GVHabitaciones.SelectedIndex].Cells[1].Text));
                Reserva r = new Reserva(hab, (Cliente)Session["usuario"], cldFechaInicio.SelectedDate, cldFechaFin.SelectedDate, "Activa", -1);
                lblCostoTotal.Text = "$" + (hab.CostoDiario * dias).ToString();
                btnReservar.Enabled = true;
            }
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    public void EstadoInicial()
    {
        lblMensaje.Text = "";
        lblHabitacion.Text = "";
        lblCostoTotal.Text = "";
        btnCalcularCosto.Enabled = false;
        btnReservar.Enabled = false;
    }
    protected void cldFechaInicio_SelectionChanged(object sender, EventArgs e)
    {
        btnReservar.Enabled = false;
        lblCostoTotal.Text = "";
    }
    protected void cldFechaFin_SelectionChanged(object sender, EventArgs e)
    {
        btnReservar.Enabled = false;
        lblCostoTotal.Text = "";
    }
}