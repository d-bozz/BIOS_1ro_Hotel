using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMdeAdministradores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            EstadoInicial();

    }
    
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario user = LogicaUsuarios.Buscar(txtuser.Text);
            if (user == null)
            {
                lblMensaje.Text = ("No se ha encontrado un administrador con ese usuario.");
                HabilitarA();
            }
            else if (user is Administrador)
            {
                HabilitarME();
                txtpass.Text = user.Contraseña;//despues del postback se borra igual porque el textbox esta clasificado como pw
                txtnombre.Text = user.NombreCompleto;
                ddlCargos.SelectedValue = ((Administrador)user).Cargo;   
            }
            else
                lblMensaje.Text = ("El usuario " + user.Name + " corresponde a un CLIENTE");

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        EstadoInicial();
        lblMensaje.Text = "";
    }
    
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Administrador admin = new Administrador(txtuser.Text, "ejemplo", "ejemplo", ddlCargos.SelectedValue);
            if (admin.Name.ToLower() == ((Usuario)Session["usuario"]).Name.ToLower())
                throw new Exception("No se puede eliminar a si mismo.");
            LogicaUsuarios.Eliminar(admin);
            EstadoInicial();
            lblMensaje.Text = ("Se ha eliminado correctamente el administrador con usurio " + admin.Name);
        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string usuario = txtuser.Text.Trim();
            string contraseña = txtpass.Text.Trim();
            string nombre = txtnombre.Text.Trim();
            string cargo = ddlCargos.SelectedValue;

            Administrador admin = new Administrador(usuario, txtpass.Text, txtnombre.Text, ddlCargos.SelectedValue);
            LogicaUsuarios.Modificar(admin);

            //Si lo que modifico es el usuario activo, modifico la sesion.
            if (admin.Name.ToLower() == ((Usuario)Session["usuario"]).Name.ToLower())
                Session["usuario"] = admin;

            EstadoInicial();
            lblMensaje.Text = ("Se ha modificado correctamente el administrador con el usuario " + usuario);

        }
        catch (Exception ex)
        { lblMensaje.Text = ex.Message; }
    }
    
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string usuario = txtuser.Text.Trim();
            string contraseña = txtpass.Text.Trim();
            string nombre = txtnombre.Text.Trim();
            string cargo = ddlCargos.SelectedValue;
            
            Administrador admin = new Administrador(usuario, txtpass.Text, txtnombre.Text, ddlCargos.SelectedValue);
            LogicaUsuarios.Agregar(admin);
            EstadoInicial();
            lblMensaje.Text = ("Se ha Agregado correctamente el administrador con el usuario " + usuario);
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

        txtuser.Enabled = false;
        txtpass.Enabled = true;
        txtnombre.Enabled = true;
        ddlCargos.Enabled = true;
    }

    private void HabilitarME()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnBuscar.Enabled = false;

        txtuser.Enabled = false;
        txtpass.Enabled = true;
        txtnombre.Enabled = true;
        ddlCargos.Enabled = true;
    }

    private void EstadoInicial()
    {
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;

        txtuser.Enabled = true;
        txtpass.Enabled = false;
        txtnombre.Enabled = false;
        ddlCargos.Enabled = false;


        lblMensaje.Text = "";
        txtuser.Text = "";
        txtpass.Text = "";
        txtnombre.Text = "";
    }


}