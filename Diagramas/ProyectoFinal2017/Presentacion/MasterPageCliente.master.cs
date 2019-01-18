using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class MasterPageCliente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario u = (Usuario)Session["usuario"];
        if (u != null)
        {
            if (u is Cliente)
                lblUser.Text = u.Name.ToString();
            else
                Response.Redirect("Bienvenida.aspx");
        }
        else
            Response.Redirect("Logueo.aspx");
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Logueo.aspx");
        }
    }
}
