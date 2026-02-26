using pe.com.muertelenta.bal;
using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pe.com.muertelenta.ui.tipoplato
{
    public partial class frmtipoplato : System.Web.UI.Page
    {
        //creamos un objeto de TipoPlatoBAL
        private TipoPlatoBAL bal = new TipoPlatoBAL();
        //creamos un objeto de TipoPlatoBO
        private TipoPlatoBO obj = new TipoPlatoBO();
        //declarando variables
        private int cod = 0, indice = -1;
        private string nom = "";
        private bool est = false, res = false;

        //cremos un procedimiento para cargar el tipo de plato
        private void CargarTipoPlato()
        {
            //creamos una lista para almacenar los valores
            List<TipoPlatoBO> lista = bal.findAllCustom();
            //asignamos los valores al GridView
            gvTipoPlato.DataSource = lista;
            gvTipoPlato.DataBind();
        }

        //creamos un procedimiento para bloquear controles
        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        //creamos un procedimiento para desbloquear
        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtNom.Enabled = true;
            chkEst.Enabled = true;
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        //creamos un procedimiento para limpiar
        private void Limpiar()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            chkEst.Checked = false;
            //agregamos el foco
            txtNom.Focus();
        }

        //creamos un procedimiento para solo lectura
        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cargamos el GridView
                CargarTipoPlato();
                //bloqueamos los controles
                Bloquear();
                //solo lectura
                SoloLectura();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //llamamos al metodo para desbloquear
            Desbloquear();
            //llamamos al metodo para limpiar
            Limpiar();
            //deshabilitamos el boton nuevo
            btnNuevo.Enabled = false;
            //mostramos el codigo
            txtCod.Text = bal.setCode().ToString();

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //controlamos los errores
            try
            {
                //validando controles
                if (txtNom.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
"Registro Tipo Plato", "alert('Ingrese el nombre');", true);
                    txtNom.Focus();
                }
                else
                {
                    //capturando valores
                    nom = txtNom.Text;
                    est = chkEst.Checked;
                    //enviamos los valores al objeto
                    obj.nombre = nom;
                    obj.estado = est;
                    //ejecutamos la funcion
                    res = bal.add(obj);
                    //evaluamos el resultado
                    if (res == true)
                    {
                        //mostrando un mensaje
                        ScriptManager.RegisterStartupScript(this, GetType(),
"Registro Tipo Plato", "alert('Se registro el tipo de plato');", true);
                        //cargamos nuevamente los datos
                        CargarTipoPlato();
                        //limpiamos los controles
                        Limpiar();
                        //Bloqueamos los controles
                        Bloquear();
                        //habilitamos el nuevo
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(),
"Registro Tipo Plato", "alert('No se registro el tipo de plato');", true);
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            nom = txtNom.Text;
            est = chkEst.Checked;
            //enviamos los valores al objeto
            obj.codigo = cod;
            obj.nombre = nom;
            obj.estado = est;
            //ejecutamos la funcion
            res = bal.update(obj, cod);
            //evaluamos el resultado
            if (res == true)
            {
                //mostrando un mensaje
                ScriptManager.RegisterStartupScript(this, GetType(),
"Actualizando Tipo Plato", "alert('Se actualizo el tipo de plato');", true);
                //cargamos nuevamente los datos
                CargarTipoPlato();
                //limpiamos los controles
                Limpiar();
                //Bloqueamos los controles
                Bloquear();
                //habilitamos el nuevo
                btnNuevo.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Actualizando Tipo Plato", "alert('No se Actualizo el tipo de plato');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            //enviamos los valores al objeto
            obj.codigo = cod;
            //ejecutamos la funcion
            res = bal.delete(cod);
            //evaluamos el resultado
            if (res == true)
            {
                //mostrando un mensaje
                ScriptManager.RegisterStartupScript(this, GetType(),
"Eliminando Tipo Plato", "alert('Se elimino el tipo de plato');", true);
                //cargamos nuevamente los datos
                CargarTipoPlato();
                //limpiamos los controles
                Limpiar();
                //Bloqueamos los controles
                Bloquear();
                //habilitamos el nuevo
                btnNuevo.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
"Eliminando Tipo Plato", "alert('No se elimino el tipo de plato');", true);
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmhabilitartipoplato.aspx");
        }

        protected void gvTipoPlato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando seleccionamos una fila de la tabla
            if (e.CommandName == "Seleccionar")
            {
                //desbloqueamos
                Desbloquear();
                //deshabilitamos el boton registrar
                btnRegistrar.Enabled = false;
                //capturamos el indice
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvTipoPlato.Rows[index];
                //asignamos los valores a los controles
                txtCod.Text = selectedRow.Cells[0].Text;
                txtNom.Text = HttpUtility.HtmlDecode(selectedRow.Cells[1].Text);
                //para el checkbox
                if ((selectedRow.Cells[2].Controls[0] as DataBoundLiteralControl).Text.Trim().Equals("Habilitado"))
                {
                    chkEst.Checked = true;
                }
                else
                {
                    chkEst.Checked = false;
                }

            }
        }
    }
}
