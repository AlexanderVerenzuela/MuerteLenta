
using pe.com.muertelenta.bal;
using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.muertelenta.ui.tipoplato
{
    public partial class frmhabilitartipoplato : System.Web.UI.Page
    {
        private TipoPlatoBAL bal = new TipoPlatoBAL();
        private TipoPlatoBO obj = new TipoPlatoBO();
        private int cod = 0, indice = -1;
        private bool res = false;

        private void CargarTipoPlato()
        {
            List<TipoPlatoBO> lista = bal.findAll();
            gvTipoPlato.DataSource = lista;
            gvTipoPlato.DataBind();
        }

        private void BindPager()
        {
            int totalPages = (int)Math.Ceiling((double)bal.findAllCustom().Count / gvTipoPlato.PageSize);
            List<int> pageNumbers = new List<int>();

            for (int i = 1; i <= totalPages; i++)
            {
                pageNumbers.Add(i);
            }

            rptPager.DataSource = pageNumbers;
            rptPager.DataBind();

            foreach (RepeaterItem item in rptPager.Items)
            {
                LinkButton lnkPage = item.FindControl("lnkPage") as LinkButton;
                if (lnkPage != null)
                {
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lnkPage);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoPlato();
                BindPager();
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCodTipp.Text);
            obj.codigo = cod;
            res = bal.enable(cod);
            if (res == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Habilitando Tipo Plato", "alert('Se habilito el tipo de plato');", true);
                CargarTipoPlato();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Habilitando Tipo Plato", "alert('No se habilito el tipo de plato');", true);
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cod = Convert.ToInt32(lblCodTipp.Text);
            obj.codigo = cod;
            res = bal.delete(cod);
            if (res == true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Deshabilitando Tipo Plato", "alert('Se deshabilito el tipo de plato');", true);
                CargarTipoPlato();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Deshabilitando Tipo Plato", "alert('No se deshabilito el tipo de plato');", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmtipoplato.aspx");
        }

        protected void gvTipoPlato_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTipoPlato.PageIndex = e.NewPageIndex;
            CargarTipoPlato();
            BindPager();
        }

        protected void rptPager_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                int pageIndex = Convert.ToInt32(e.CommandArgument) - 1;
                gvTipoPlato.PageIndex = pageIndex;
                CargarTipoPlato();
                BindPager();
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (gvTipoPlato.PageIndex > 0)
            {
                gvTipoPlato.PageIndex -= 1;
                CargarTipoPlato();
                BindPager();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (gvTipoPlato.PageIndex < gvTipoPlato.PageCount - 1)
            {
                gvTipoPlato.PageIndex += 1;
                CargarTipoPlato();
                BindPager();
            }
        }

        protected void gvTipoPlato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvTipoPlato.Rows[index];
                lblCodTipp.Text = selectedRow.Cells[0].Text;
            }
        }
    }
}
