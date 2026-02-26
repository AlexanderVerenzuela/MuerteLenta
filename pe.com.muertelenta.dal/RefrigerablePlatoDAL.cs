using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.muertelenta.dal
{
    public class RefrigerablePlatoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        // listar refrigerables
        public List<RefrigerablePlatoBO> findAll()
        {
            List<RefrigerablePlatoBO> lista = new List<RefrigerablePlatoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarRefrigerablePlato";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RefrigerablePlatoBO obj = new RefrigerablePlatoBO();
                    obj.codigo = Convert.ToInt32(dr["codref"]);
                    obj.nombre = dr["nomref"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estref"]);
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
                if (dr != null) dr.Close();
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        // buscar por código
        public RefrigerablePlatoBO findById(int id)
        {
            RefrigerablePlatoBO obj = new RefrigerablePlatoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarRefrigerablePlatoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codref", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["codref"]);
                    obj.nombre = dr["nomref"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estref"]);
                }
                return obj;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                if (dr != null) dr.Close();
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        // registrar
        public bool add(RefrigerablePlatoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarRefrigerablePlato";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nomref", obj.nombre);
                cmd.Parameters.AddWithValue("@estref", obj.estado);

                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        // actualizar
        public bool update(RefrigerablePlatoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarRefrigerablePlato";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codref", id);
                cmd.Parameters.AddWithValue("@nomref", obj.nombre);
                cmd.Parameters.AddWithValue("@estref", obj.estado);

                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        // eliminar
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarRefrigerablePlato";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codref", id);

                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }

        // habilitar
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarRefrigerablePlato";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codref", id);

                res = cmd.ExecuteNonQuery();
                return res == 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (objconexion != null) objconexion.CerrarConexion();
            }
        }
    }
}
