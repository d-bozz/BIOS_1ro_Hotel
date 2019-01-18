using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ConfirmarusodeReserva : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            List<Reserva> lista = LogicaReservas.ListarReservasActivas();
            Session["listaC"] = lista;
            Session["listaS"] = new List<Reserva>();

            GVCompleto.DataSource = lista;
            GVCompleto.DataBind();


        }
        catch (Exception ex)
        { lblestado.Text = ex.Message; }


    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
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
               
                LogicaReservas.Finalizar(res);
                lblestado.Text = ("Se ha eliminado correctamente la reserva: " + res.Id);

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