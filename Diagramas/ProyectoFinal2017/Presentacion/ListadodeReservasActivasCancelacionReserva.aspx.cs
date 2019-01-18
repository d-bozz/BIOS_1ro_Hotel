using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListadodeReservasActivas_CancelacionReserva : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Usuario u = (Usuario)Session["usuario"];

            if (u is Cliente)
            {
                List<Reserva> lista = LogicaReservas.ListarReservasActivasPorCliente(u);
                Session["listaC"] = lista;
                Session["listaS"] = new List<Reserva>();

                GVCompleto.DataSource = lista;
                GVCompleto.DataBind();

            }
            else
            {
                lblestado.Text = "No hay Reservas realizadas por clientes.";
                btnCancelar.Visible = false;
            }
        }

        catch (Exception ex)
        { lblestado.Text = ex.Message; }


    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            int indice = GVCompleto.SelectedIndex;
            if (indice < 0)
                lblestado.Text = "No hay reservas seleccionadas para eliminar.";
            else
            {
                int id = Convert.ToInt32(GVCompleto.DataKeys[indice].Value);

                Reserva res = LogicaReservas.Buscar(id);

                LogicaReservas.Cancelar(res);
                lblestado.Text = ("Se ha cancelado correctamente la reserva: " + res.Id);

                GVCompleto.SelectedIndex = -1;
                ((List<Reserva>)Session["listaC"]).RemoveAt(indice);
                GVCompleto.DataSource = (List<Reserva>)Session["listaC"];
                GVCompleto.DataBind();

                List<Reserva> listaSeleccion = (List<Reserva>)Session["listaS"];

            }
        }
        catch (Exception ex)
        { lblestado.Text = ex.Message; }
    }


}