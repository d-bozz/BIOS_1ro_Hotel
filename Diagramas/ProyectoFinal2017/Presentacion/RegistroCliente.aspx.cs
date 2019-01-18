using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class RegistroCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EstadoInicial()
    {
        lblmensaje.Text = "";
        txtDireccion.Text = "";
        txtNombre.Text = "";
        txtContra.Text = "";
        txtContra2.Text = "";
        txttarjeta.Text = "";
        lstTel.Items.Clear();
        txtUser.Text = "";
        txtTelefonoExtra.Text = "";
    }

    protected void AgregadoOK()
    {
        txtDireccion.Text = "";
        txtNombre.Text = "";
        txtContra.Text = "";
        txtContra2.Text = "";
        txttarjeta.Text = "";
        lstTel.Items.Clear();
        txtUser.Text = "";
        txtTelefonoExtra.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string usuario = txtUser.Text.Trim();

            string nombre = txtNombre.Text.Trim();

            string contraseña = txtContra.Text.Trim();

            string direccion = txtDireccion.Text.Trim();

            string tarjeta = txttarjeta.Text.Trim();



            if (lstTel.Items.Count == 0)
                throw new Exception("Debe cargar al menos un telefono.");

            List<int> ListaTel = new List<int>();
            for (int i = 0; lstTel.Items.Count > i; i++)
            {
                int telefono = 0;
                if (!int.TryParse(lstTel.Items[i].Value, out telefono))
                    throw new Exception("El telefono no tiene forma numerica.");

                if (telefono < 0)
                    throw new Exception("El telefono debe ser un numero positivo");

                ListaTel.Add(telefono);
            }

            Cliente cli = new Cliente(usuario, txtContra.Text, txtNombre.Text, txttarjeta.Text, txtDireccion.Text, ListaTel);

            LogicaUsuarios.Agregar(cli);
            lblmensaje.Text = ("Se ha agregado correctamente el cliente con el usuario " + usuario);
            AgregadoOK();
            Session["cli"] = cli; //cargo el cliente en la session para usarlo mas tarde
        }
        catch (Exception ex)
        { lblmensaje.Text = ex.Message; }
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        EstadoInicial();
    }



    protected void btnAgregarTel_Click(object sender, EventArgs e)
    {
        try
        {
            int telefono = 0;
            if (!int.TryParse(txtTelefonoExtra.Text, out telefono))
            {
                txtTelefonoExtra.Text = "";
                throw new Exception("El telefono no tiene forma numerica.");
            }
            if (telefono < 0)
            {
                txtTelefonoExtra.Text = "";
                throw new Exception("El telefono debe ser un numero positivo");
            }
            for (int i = 0; i < lstTel.Items.Count; i++)
            {
                if (txtTelefonoExtra.Text == lstTel.Items[i].Value)
                {
                    txtTelefonoExtra.Text = "";
                    throw new Exception("Telefono repetido.");
                }
            }
            lstTel.Items.Add(txtTelefonoExtra.Text);
            txtTelefonoExtra.Text = "";
            lblmensaje.Text = "";
        }
        catch (Exception ex)
        { lblmensaje.Text = ex.Message; }
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        lstTel.Items.Remove(lstTel.SelectedItem);
    }
}