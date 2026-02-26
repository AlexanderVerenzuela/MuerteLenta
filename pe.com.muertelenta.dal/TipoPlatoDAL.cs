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
    public class TipoPlatoDAL
    {
        //creamos un objeto de la clase ConexionDAL
        private ConexionDAL objconexion = new ConexionDAL();

        //objeto SqlCommand -> consultas SQL
        private SqlCommand cmd;

        //objeto SqlDataReader -> resultados de una consulta
        private SqlDataReader dr;

        //creamos una variable para los resultados de la actualizacion (registrar,actualizar y eliminar) de la BD
        private int res = 0;

        //creamos una funcion para mostrar todos los tipos de plato
        public List<TipoPlatoBO> findAll()
        {
            //creamos una lista de TipoPlatoBO
            List<TipoPlatoBO> lista = new List<TipoPlatoBO>();

            //utilizamos un try-catch-finally
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarTipoPlatoTodo";

                //instanciamos la conexion a la BD
                cmd.Connection = objconexion.Conectar();

                //ejecutamos el procedimiento almacenado
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    //creamos un objeto de TipoPlatoBO
                    TipoPlatoBO obj = new TipoPlatoBO();

                    //leemos los datos y lo asignamos al objeto
                    obj.codigo = Convert.ToInt32(dr["codtipp"]);
                    obj.nombre = dr["nomtipp"].ToString();
                    obj.estado = Convert.ToBoolean(dr["esttipp"]);

                    //agregamos el objeto a la lista
                    lista.Add(obj);
                }

                //devolvemos la lista
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

        //funcion para mostrar los tipos de plato habilitados
        public List<TipoPlatoBO> findAllCustom()
        {
            //creamos una lista de TipoPlatoBO
            List<TipoPlatoBO> lista = new List<TipoPlatoBO>();

            //utilizamos un try-catch-finally
            try
            {
                //instanciamos el SqlCommand
                cmd = new SqlCommand();

                //especificamos el tipo de SqlCommand
                cmd.CommandType = CommandType.StoredProcedure;

                //especificamos el nombre del procedimiento almacenado
                cmd.CommandText = "SP_MostrarTipoPlato";

                //instanciamos la conexion a la BD
                cmd.Connection = objconexion.Conectar();

                //ejecutamos el procedimiento almacenado
                dr = cmd.ExecuteReader();

                //cargamos los datos en la lista
                while (dr.Read())
                {
                    //creamos un objeto de TipoPlatoBO
                    TipoPlatoBO obj = new TipoPlatoBO();

                    //leemos los datos y lo asignamos al objeto
                    obj.codigo = Convert.ToInt32(dr["codtipp"]);
                    obj.nombre = dr["nomtipp"].ToString();
                    obj.estado = Convert.ToBoolean(dr["esttipp"]);

                    //agregamos el objeto a la lista
                    lista.Add(obj);
                }

                //devolvemos la lista
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

        //creamos una funcion para registrar los tipos de plato
        public bool add(TipoPlatoBO obj)
        {
            //utilizamos el try-catch-finally
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarTipoPlato";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@estado", obj.estado);

                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();

                //evaluamos los resultados
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        //creamos una funcion para buscar por codigo
        public TipoPlatoBO findById(int id)
        {
            TipoPlatoBO lista = new TipoPlatoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarTipoPlatoXCodigo";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a buscar
                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lista.codigo = Convert.ToInt32(dr["codtipp"]);
                    lista.nombre = dr["nomtipp"].ToString();
                    lista.estado = Convert.ToBoolean(dr["esttipp"]);
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

        //creamos una funcion para actualizar los tipos de plato
        public bool update(TipoPlatoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarTipoPlato";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@estado", obj.estado);

                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        //creamos una funcion para eliminar los tipos de plato
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarTipoPlato";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@codigo", id);

                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        //creamos una funcion para habilitar los tipos de plato
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarTipoPlato";
                cmd.Connection = objconexion.Conectar();

                //pasamos los parametros con los datos a registrar
                cmd.Parameters.AddWithValue("@codigo", id);

                res = cmd.ExecuteNonQuery();
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }

        //creamos una funcion para mostrar el codigo siguiente del tipo de plato
        public int setCode()
        {
            int code = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoTipoPlato";
                cmd.Connection = objconexion.Conectar();
                object res = cmd.ExecuteScalar();

                //evaluamos el valor
                if (res != null)
                {
                    //code = (int)res;
                    code = Convert.ToInt32(res);
                }
                return code;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return 0;
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
