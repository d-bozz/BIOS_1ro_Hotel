using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            Usuario u = LogicaUsuarios.Logueo(user, pass);

            if (u == null)
            {
                lblEstado.Text = "El usuario y/o la contraseña no son correctas.";
                txtUser.Text = "";
                txtPass.Text = "";
            }
            else
            {
                //Cargo el usuario en una SESSION para controlar el acceso en las páginas.
                Session["usuario"] = u;

                //Recordar que solo tengo dos opciones: Administrador y Cliente
                if (u is Administrador)
                    Response.Redirect("Bienvenida.aspx");
                else
                    Response.Redirect("RealizarunaReserva.aspx");
            }
        }
        catch (Exception ex)
        { lblEstado.Text = ex.Message; }
    }

}