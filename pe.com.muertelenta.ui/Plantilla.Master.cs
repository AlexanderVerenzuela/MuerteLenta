using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.muertelenta.ui
{
    public partial class Plantilla : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmpleadoBO empleado = (EmpleadoBO)Session["EmpleadoLogueado"];
                if (empleado != null)
                {
                    lblUsuEmp.Text = empleado.usuario; ;
                    lblNombre.Text = empleado.nombre + " " + empleado.apellidopaterno + " " + empleado.apellidomaterno;
                }
                else
                {
                    Response.Redirect(ResolveUrl("~/index.aspx"));
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //eliminar la sesion de empleado
            Session.Remove("EmpleadoLogueado");
            //limpiamos toda la sesion
            Session.Clear();
            //redirigimos al login
            Response.Redirect(ResolveUrl("~/index.aspx"));
        }
    }
}
