using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class ABMdeHoteles : System.Web.UI.Page
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
        txtCalle.Enabled = false;
        txtCiudad.Enabled = false;
        txtFax.Enabled = false;
        txtNroPuerta.Enabled = false;
        txtTelefono.Enabled = false;
        RBEstrellas.Enabled = false;
        RBPiscina.Enabled = false;
        RBPlaya.Enabled = false;
        fileimageFoto.Enabled = false;

        lblMensaje.Text = "";
        txtHotel.Text = "";
        txtCalle.Text = "";
        txtCiudad.Text = "";
        txtFax.Text = "";
        txtNroPuerta.Text = "";
        txtTelefono.Text = "";
        RBEstrellas.ClearSelection();
        RBPiscina.Checked = false;
        RBPlaya.Checked = false;
        img.ImageUrl = "";

        valNombre.Enabled = true;
        valCalle.Enabled = false;
        valPuerta.Enabled = false;
        valNroPuerta.Enabled = false;
        valCiudad.Enabled = false;
        valTelefono.Enabled = false;
        valFax.Enabled = false;
        valEstrellas.Enabled = false;
        valFoto.Enabled = false;

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Hotel hot = LogicaHoteles.Buscar(txtHotel.Text);
            if (hot == null)
            {
                lblMensaje.Text = ("No se ha encontrado un hotel con esos datos.");
                HabilitarA();
            }
            else
            {
                HabilitarME();
                txtCalle.Text = hot.Calle.ToString();
                txtCiudad.Text = hot.Ciudad;
                txtFax.Text = hot.Fax.ToString();
                txtNroPuerta.Text = hot.NroPuerta.ToString();
                txtTelefono.Text = hot.Telefono.ToString();
                RBEstrellas.Text = hot.Estrellas.ToString();
                RBPiscina.Checked = hot.Piscina;
                RBPlaya.Checked = hot.AccesoPlaya;
                img.ImageUrl = hot.Foto.ToString();

            }


        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        EstadoInicial();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (fileimageFoto.FileName == "")
            {
                throw new Exception("No se ha seleccionado ninguna imagen.");
            }
            //Guardo la ruta relativa
            string imagen = "~/Images/" + fileimageFoto.FileName;

            //Para almacenar necesito la ruta ABSOLUTA
            fileimageFoto.SaveAs(Server.MapPath(imagen));


            //Después de guardar, puedo mostrar
            img.ImageUrl = imagen;


            string hotel = txtHotel.Text;

            string calle = txtCalle.Text;

            int puerta = Convert.ToInt32(txtNroPuerta.Text.Trim());

            string ciudad = txtCiudad.Text;

            int telefono = Convert.ToInt32(txtTelefono.Text);

            int fax = Convert.ToInt32(txtFax.Text);

            bool playa = RBPlaya.Checked;

            bool piscina = RBPiscina.Checked;

            int estrellas = Convert.ToInt32(RBEstrellas.SelectedValue);

            Hotel hot = new Hotel(hotel, calle, puerta, ciudad, telefono, fax, playa, piscina, estrellas, imagen);

            LogicaHoteles.Agregar(hot);
            EstadoInicial();
            lblMensaje.Text = "Se agregó correctamente el hotel " + hot.NombreHotel + ".";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }


    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {

        try
        {
            string imagen = "";
            if (fileimageFoto.HasFile)
            {
                //Guardo la ruta relativa
                imagen = "~/Images/" + fileimageFoto.FileName;

                //Para almacenar necesito la ruta ABSOLUTA
                fileimageFoto.SaveAs(Server.MapPath(imagen));


                //Después de guardar, puedo mostrar
                img.ImageUrl = imagen;
            }
            else
                imagen = img.ImageUrl;


            string hotel = txtHotel.Text;

            string calle = txtCalle.Text;

            int puerta = Convert.ToInt32(txtNroPuerta.Text.Trim());

            string ciudad = txtCiudad.Text;

            int telefono = Convert.ToInt32(txtTelefono.Text);

            int fax = Convert.ToInt32(txtFax.Text);

            bool playa = RBPlaya.Checked;

            bool piscina = RBPiscina.Checked;

            int estrellas = Convert.ToInt32(RBEstrellas.SelectedValue);

            Hotel hot = new Hotel(hotel, calle, puerta, ciudad, telefono, fax, playa, piscina, estrellas, imagen);

            LogicaHoteles.Modificar(hot);
            EstadoInicial();
            lblMensaje.Text = "Se modifico correctamente el hotel " + hotel + ".";
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }


    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            string hotel = txtHotel.Text;

            Hotel hot = LogicaHoteles.Buscar(hotel);
            if (hot == null)
                throw new Exception("El hotel no existe.");

            LogicaHoteles.Eliminar(hot);
            EstadoInicial();
            lblMensaje.Text = ("Se ha eliminado correctamente el hotel: " + hot.NombreHotel);
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

        txtCalle.Enabled = true;
        txtCiudad.Enabled = true;
        txtFax.Enabled = true;
        txtNroPuerta.Enabled = true;
        txtTelefono.Enabled = true;
        RBEstrellas.Enabled = true;
        RBPiscina.Enabled = true;
        RBPlaya.Enabled = true;
        fileimageFoto.Enabled = true;

        valNombre.Enabled = true;
        valCalle.Enabled = true;
        valPuerta.Enabled = true;
        valNroPuerta.Enabled = true;
        valCiudad.Enabled = true;
        valTelefono.Enabled = true;
        valFax.Enabled = true;
        valEstrellas.Enabled = true;
        valFoto.Enabled = true;
    }

    private void HabilitarME()
    {

        lblMensaje.Text = "";
        btnAgregar.Enabled = false;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnBuscar.Enabled = false;

        txtHotel.Enabled = false;
        txtCalle.Enabled = true;
        txtCiudad.Enabled = true;
        txtFax.Enabled = true;
        txtNroPuerta.Enabled = true;
        txtTelefono.Enabled = true;
        RBEstrellas.Enabled = true;
        RBPiscina.Enabled = true;
        RBPlaya.Enabled = true;
        fileimageFoto.Enabled = true;

        valNombre.Enabled = true;
        valCalle.Enabled = true;
        valPuerta.Enabled = true;
        valNroPuerta.Enabled = true;
        valCiudad.Enabled = true;
        valTelefono.Enabled = true;
        valFax.Enabled = true;
        valEstrellas.Enabled = true;
        //valFoto.Enabled = true;
    }


}