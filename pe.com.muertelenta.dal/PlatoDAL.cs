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
    public class PlatoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        //creamos una funcion para mostrar todos los platos
        public List<PlatoBO> findAll()
        {
            List<PlatoBO> lista = new List<PlatoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarPlatoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PlatoBO obj = new PlatoBO();
                    TipoPlatoBO objtp = new TipoPlatoBO();
                    RefrigerablePlatoBO objrtp = new RefrigerablePlatoBO();

                    obj.codigo = Convert.ToInt32(dr["codplat"]);
                    obj.nombre = dr["nomplat"].ToString();
                    obj.descripcion = dr["desplat"].ToString();
                    obj.precio = Convert.ToDouble(dr["preplat"]);
                    obj.cantidad = Convert.ToInt32(dr["canplat"]);
                    obj.fechaingreso = Convert.ToDateTime(dr["fecplat"]);
                    obj.fechacaducidad = Convert.ToDateTime(dr["cadplat"]);
                    obj.estado = Convert.ToBoolean(dr["esttipp"]);

                    //para las claves foraneas
                    //tipo plato
                    objtp.nombre = dr["nomtipp"].ToString();
                    obj.tipoplato = objtp;

                    //refrigerable tipo plato
                    objrtp.nombre = dr["nomrefp"].ToString();
                    obj.refrigerableplato = objrtp;

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

        //funcion para mostrar los plato habilitados
        public List<PlatoBO> findAllCustom()
        {
            List<PlatoBO> lista = new List<PlatoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarPlato";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PlatoBO obj = new PlatoBO();
                    TipoPlatoBO objtp = new TipoPlatoBO();
                    RefrigerablePlatoBO objrtp = new RefrigerablePlatoBO();

                    obj.codigo = Convert.ToInt32(dr["codplat"]);
                    obj.nombre = dr["nomplat"].ToString();
                    obj.descripcion = dr["desplat"].ToString();
                    obj.precio = Convert.ToDouble(dr["preplat"]);
                    obj.cantidad = Convert.ToInt32(dr["canplat"]);
                    obj.fechaingreso = Convert.ToDateTime(dr["fecplat"]);
                    obj.fechacaducidad = Convert.ToDateTime(dr["cadplat"]);
                    obj.estado = Convert.ToBoolean(dr["esttipp"]);

                    //para las claves foraneas
                    //tipo plato
                    objtp.nombre = dr["nomtipp"].ToString();
                    obj.tipoplato = objtp;

                    //refrigerable tipo plato
                    objrtp.nombre = dr["nomrefp"].ToString();
                    obj.refrigerableplato = objrtp;

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

        //creamos una funcion para registrar los tipos de plato
        public bool add(PlatoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarPlato";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@precio", obj.precio);
                cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                cmd.Parameters.AddWithValue("@fecha", obj.fechaingreso);
                cmd.Parameters.AddWithValue("@caducidad", obj.fechacaducidad);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@codtipp", obj.tipoplato.codigo);
                cmd.Parameters.AddWithValue("@codrefp", obj.refrigerableplato.codigo);

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

        //creamos una funcion para buscar por codigo
        public PlatoBO findById(int id)
        {
            PlatoBO lista = new PlatoBO();
            TipoPlatoBO objtp = new TipoPlatoBO();
            RefrigerablePlatoBO objrtp = new RefrigerablePlatoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarPlatoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lista.codigo = Convert.ToInt32(dr["codplat"]);
                    lista.nombre = dr["nomplat"].ToString();
                    lista.descripcion = dr["desplat"].ToString();
                    lista.precio = Convert.ToDouble(dr["preplat"]);
                    lista.cantidad = Convert.ToInt32(dr["canplat"]);
                    lista.fechaingreso = Convert.ToDateTime(dr["fecplat"]);
                    lista.fechacaducidad = Convert.ToDateTime(dr["cadplat"]);
                    lista.estado = Convert.ToBoolean(dr["esttipp"]);

                    //para las claves foraneas
                    //tipo plato
                    objtp.nombre = dr["nomtipp"].ToString();
                    lista.tipoplato = objtp;

                    //refrigerable tipo plato
                    objrtp.nombre = dr["nomrefp"].ToString();
                    lista.refrigerableplato = objrtp;
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

        //creamos una funcion para actualizar los platos
        public bool update(PlatoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarPlato";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codigo", id);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@precio", obj.precio);
                cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);
                cmd.Parameters.AddWithValue("@fecha", obj.fechaingreso);
                cmd.Parameters.AddWithValue("@caducidad", obj.fechacaducidad);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@codtipp", obj.tipoplato.codigo);
                cmd.Parameters.AddWithValue("@codrefp", obj.refrigerableplato.codigo);


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

        //creamos una funcion para eliminar los platos
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarPlato";
                cmd.Connection = objconexion.Conectar();

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

        //creamos una funcion para habilitar los platos
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarPlato";
                cmd.Connection = objconexion.Conectar();

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
                cmd.CommandText = "SP_CodigoPlato";
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
                if (objconexion != null) objconexion.CerrarConexion();
                if (dr != null) dr.Close();
            }
        }
    }

}
