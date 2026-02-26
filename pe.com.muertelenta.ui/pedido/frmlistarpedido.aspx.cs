using pe.com.muertelenta.bal;
using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.muertelenta.ui.pedido
{
    public partial class frmlistarpedido : System.Web.UI.Page
    {
        private OrdenBAL bal = new OrdenBAL();
        private OrdenBO obj = new OrdenBO();
        private int cod = 0, indice = -1;
        private bool res = false;

        private void CargarOrden()
        {
            List<OrdenBO> lista = bal.findAll();
            gvOrdenPedido.DataSource = lista;
            gvOrdenPedido.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOrden();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmregistrarpedido.aspx");
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void gvOrdenPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}
