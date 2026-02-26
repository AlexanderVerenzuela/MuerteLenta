using pe.com.muertelenta.ui.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.muertelenta.ui
{
    public partial class index : System.Web.UI.Page
    {
        //declarando variables
        private string usu = "", cla = "";
        private bool res = false;
        //creamos un metodo para controlar las pruebas
        private void Probar()
        {
            //conexion
            //llamamos al metodo para probar la conexion
            ConexionTest.ProbarConexion();
            //TipoPlato
            TipoPlatoDALTest.findAllTest();
            TipoPlatoDALTest.findAllCustomTest();
            TipoPlatoDALTest.addTest();
            TipoPlatoDALTest.findAllTest();
            TipoPlatoDALTest.findByIdTest();
            TipoPlatoDALTest.updateTest();
            TipoPlatoDALTest.findByIdTest();
            TipoPlatoDALTest.deleteTest();
            TipoPlatoDALTest.findByIdTest();
            TipoPlatoDALTest.enableTest();
            TipoPlatoDALTest.findByIdTest();
            //Plato
            PlatoDALTest.findAllTest();
            PlatoDALTest.findAllCustomTest();
            PlatoDALTest.addTest();
            PlatoDALTest.findAllTest();
            PlatoDALTest.findByIdTest();
            PlatoDALTest.updateTest();
            PlatoDALTest.findByIdTest();
            PlatoDALTest.deleteTest();
            PlatoDALTest.findByIdTest();
            PlatoDALTest.enableTest();
            PlatoDALTest.findByIdTest();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Probar();
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //capturamos valores en controles HTML
            usu = username.Value;
            cla = pass.Value;
            //evaluamos la condicion
            if (usu.ToLower().Equals("mhuapalla") && cla.Equals("123456"))
            {
                res = true;
            }
            else
            {
                res = false;
            }

            //evaluamos el resultado
            if (res)
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
    "Ingreso al Sistema", "alert('Bienvenidos al Sistema'); window.location='menuprincipal.aspx'"
    , true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Ingreso al Sistema", "alert('Usuario o Clave incorrecta'); window.location='index.aspx'"
, true);
            }


        }
    }
}
