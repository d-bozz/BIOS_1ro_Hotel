using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABM_de_Habitaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EstadoInicial();
        }

    }

    private void EstadoInicial()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;

        txtHotel.Enabled = true;
        txtHabitacion.Enabled = true;

        txtPiso.Enabled = false;
        txtHuespedes.Enabled = false;
        txtCostoDiario.Enabled = false;
        txtDescripcion.Enabled = false;

        lblMensaje.Text = "";
        txtHotel.Text = "";
        txtHabitacion.Text = "";
        txtPiso.Text = "";
        txtHuespedes.Text = "";
        txtCostoDiario.Text = "";
        txtDescripcion.Text = "";

        valHotel.Enabled = true;
        valHabitacion.Enabled = true;
        valHabitacionNum.Enabled = true;
        valPiso.Enabled = false;
        valPisoNum.Enabled = false;
        valHuespedes.Enabled = false;
        valHuespedesNum.Enabled = false;
        valCostoDiario.Enabled = false;
        valCostoDiarioNum.Enabled = false;
        valDescripcion.Enabled = false;

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        try
        {
            Hotel hot = LogicaHoteles.Buscar(txtHotel.Text);
            if (hot == null)
                throw new Exception("El hotel no existe en la base de datos");

            Habitacion hab = LogicaHabitaciones.Buscar(hot, Convert.ToInt32(txtHabitacion.Text));

            if (hab == null)
            {
                lblMensaje.Text = ("No se ha encontrado una habitacion con esos datos.");
                HabilitarA();
            }
            else
            {
                HabilitarME();
                txtPiso.Text = hab.Piso.ToString();
                txtHuespedes.Text = hab.CantHuespedes.ToString();
                txtCostoDiario.Text = hab.CostoDiario.ToString();
                txtDescripcion.Text = hab.Descripcion;

            }


        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }


    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        EstadoInicial();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {


            string hotel = txtHotel.Text;
            int nroHabitacion = Convert.ToInt32(txtHabitacion.Text.Trim());

            Hotel hot = LogicaHoteles.Buscar(hotel);
            if (hot == null)
                throw new Exception("El hotel no existe.");

            Habitacion hab = LogicaHabitaciones.Buscar(hot, nroHabitacion);
            if (hab == null)
                throw new Exception("La habitacion no existe.");

            LogicaHabitaciones.Eliminar(hab);
            EstadoInicial();
            lblMensaje.Text = ("Se ha eliminado correctamente la habitacion: " + hab.NroHabitacion + "Con de el hotel: " + hab.Hotel.NombreHotel);
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {

        try
        {

            string hotel = txtHotel.Text;

            int nroHabitacion = Convert.ToInt32(txtHabitacion.Text.Trim());

            int piso = Convert.ToInt32(txtPiso.Text.Trim());

            int huespedes = Convert.ToInt32(txtHuespedes.Text.Trim());

            int costoDiario = Convert.ToInt32(txtCostoDiario.Text.Trim());

            string descripcion = txtDescripcion.Text;

            Hotel hot = LogicaHoteles.Buscar(hotel);

            if (hot == null)
                throw new Exception("El hotel no existe.");

            Habitacion hab = new Habitacion(hot, Convert.ToInt32(txtHabitacion.Text), Convert.ToInt32(txtPiso.Text), Convert.ToInt32(txtHuespedes.Text), Convert.ToInt32(txtCostoDiario.Text), txtDescripcion.Text);
            LogicaHabitaciones.Modificar(hab);
            EstadoInicial();
            lblMensaje.Text = ("Se ha modificado correctamente la habitacion " + nroHabitacion) + "En el hotel: " + hotel;
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        try
        {
            string hotel = txtHotel.Text;

            int nroHabitacion = Convert.ToInt32(txtHabitacion.Text.Trim());

            int piso = Convert.ToInt32(txtPiso.Text.Trim());

            int huespedes = Convert.ToInt32(txtHuespedes.Text.Trim());

            int costoDiario = Convert.ToInt32(txtCostoDiario.Text.Trim());

            string descripcion = txtDescripcion.Text;

            Hotel hot = LogicaHoteles.Buscar(hotel);

            if (hot == null)
                throw new Exception("El hotel no existe.");

            Habitacion hab = new Habitacion(hot, Convert.ToInt32(txtHabitacion.Text), Convert.ToInt32(txtPiso.Text), Convert.ToInt32(txtHuespedes.Text), Convert.ToInt32(txtCostoDiario.Text), txtDescripcion.Text);
            LogicaHabitaciones.Agregar(hab);
            EstadoInicial();
            lblMensaje.Text = ("Se ha agregado correctamente la habitacion " + nroHabitacion) + "En el hotel: " + hotel;
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }


    }

    private void HabilitarA()
    {
        btnAgregar.Enabled = true;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = false;

        txtHotel.Enabled = false;
        txtHabitacion.Enabled = false;

        txtCostoDiario.Enabled = true;
        txtDescripcion.Enabled = true;
        txtHuespedes.Enabled = true;
        txtPiso.Enabled = true;

        valHotel.Enabled = true;
        valHabitacion.Enabled = true;
        valHabitacionNum.Enabled = true;
        valPiso.Enabled = true;
        valPisoNum.Enabled = true;
        valHuespedes.Enabled = true;
        valHuespedesNum.Enabled = true;
        valCostoDiario.Enabled = true;
        valCostoDiarioNum.Enabled = true;
        valDescripcion.Enabled = true;
    }

    private void HabilitarME()
    {

        lblMensaje.Text = "";
        btnAgregar.Enabled = false;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnBuscar.Enabled = false;

        txtHotel.Enabled = false;
        txtHabitacion.Enabled = false;

        txtCostoDiario.Enabled = true;
        txtDescripcion.Enabled = true;
        txtHuespedes.Enabled = true;
        txtPiso.Enabled = true;

        valHotel.Enabled = true;
        valHabitacion.Enabled = true;
        valHabitacionNum.Enabled = true;
        valPiso.Enabled = true;
        valPisoNum.Enabled = true;
        valHuespedes.Enabled = true;
        valHuespedesNum.Enabled = true;
        valCostoDiario.Enabled = true;
        valCostoDiarioNum.Enabled = true;
        valDescripcion.Enabled = true;
    }

}