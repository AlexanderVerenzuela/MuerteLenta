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
    public class OrdenDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        public List<OrdenBO> findAll()
        {
            List<OrdenBO> lista = new List<OrdenBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarOrdenDetalle";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OrdenBO obj = new OrdenBO();
                    EmpleadoBO objemp = new EmpleadoBO();
                    ClienteBO objcli = new ClienteBO();

                    obj.codigo = Convert.ToInt32(dr["codord"]);
                    obj.fecha = Convert.ToDateTime(dr["fechaord"].ToString());
                    obj.total = Convert.ToDecimal(dr["subtotal"].ToString());
                    obj.estado = Convert.ToBoolean(dr["estord"]);

                    //para las claves foraneas
                    //cliente
                    objcli.nombre = dr["nomcli"].ToString();
                    objcli.apellidopaterno = dr["apepcli"].ToString();
                    objcli.apellidomaterno = dr["apemcli"].ToString();
                    obj.cliente = objcli;

                    //empleado
                    objemp.nombre = dr["nomemp"].ToString();
                    objemp.apellidopaterno = dr["apepemp"].ToString();
                    objemp.apellidomaterno = dr["apememp"].ToString();
                    obj.empleado = objemp;

                    lista.Add(obj);
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
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }
    }
}
