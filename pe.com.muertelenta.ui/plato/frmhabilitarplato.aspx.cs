using pe.com.muertelenta.bal;
using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.muertelenta.ui.plato
{
    public partial class frmhabilitarplato : System.Web.UI.Page
    {
        private PlatoBAL bal = new PlatoBAL();
        private PlatoBO obj = new PlatoBO();
        private int cod = 0, indice = -1;
        private bool res = false;

        private void CargarPlato()
        {
            List<PlatoBO> lista = bal.findAll();
            gvPlato.DataSource = lista;
            gvPlato.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlato();
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCodPlat.Text);
            obj.codigo = cod;
            res = bal.enable(cod);
            if (res == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Habilitando Plato", "alert('Se habilito el plato');", true);
                CargarPlato();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Habilitando Plato", "alert('No se habilito el plato');", true);
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCodPlat.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Deshabilitando Plato", "alert('Se deshabilito el plato');", true);
                CargarPlato();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Deshabilitando Plato", "alert('No se deshabilito el plato');", true);
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmplato.aspx");
        }

        protected void gvPlato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvPlato.Rows[index];
                lblCodPlat.Text = selectedRow.Cells[0].Text;

            }
        }
    }
}
