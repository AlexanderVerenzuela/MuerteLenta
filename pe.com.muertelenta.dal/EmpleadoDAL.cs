using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.dal
{
    public class EmpleadoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        //creamos una funcion para validar el empleado
        public EmpleadoBO login(EmpleadoBO obj)
        {
            EmpleadoBO lista = new EmpleadoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ValidarEmpleado";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a buscar
                cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                cmd.Parameters.AddWithValue("@clave", obj.clave);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO objrol = new RolBO();
                    lista.codigo = Convert.ToInt32(dr["codemp"]);
                    lista.nombre = dr["nomemp"].ToString();
                    lista.apellidopaterno = dr["apepemp"].ToString();
                    lista.apellidomaterno = dr["apememp"].ToString();
                    lista.usuario = dr["usuemp"].ToString();

                    objrol.codigo = Convert.ToInt32(dr["codrol"]);
                    objrol.nombre = dr["nomrol"].ToString();
                    lista.rol = objrol;

                    lista.estado = Convert.ToBoolean(dr["estemp"]);
                }
                return lista;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                //cerramos la conexion 
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }
    }
}
