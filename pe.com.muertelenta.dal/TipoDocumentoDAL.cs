using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.muertelenta.dal
{
    public class TipoDocumentoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        // listar tipos de documento
        public List<TipoDocumentoBO> findAll()
        {
            List<TipoDocumentoBO> lista = new List<TipoDocumentoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarTipoDocumento";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoDocumentoBO obj = new TipoDocumentoBO();
                    obj.codigo = Convert.ToInt32(dr["codtipdoc"]);
                    obj.nombre = dr["nomtipdoc"].ToString();
                    obj.estado = Convert.ToBoolean(dr["esttipdoc"]);
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
        public TipoDocumentoBO findById(int id)
        {
            TipoDocumentoBO obj = new TipoDocumentoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarTipoDocumentoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codtipdoc", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["codtipdoc"]);
                    obj.nombre = dr["nomtipdoc"].ToString();
                    obj.estado = Convert.ToBoolean(dr["esttipdoc"]);
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

        // registrar tipo documento
        public bool add(TipoDocumentoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarTipoDocumento";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nomtipdoc", obj.nombre);
                cmd.Parameters.AddWithValue("@esttipdoc", obj.estado);

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

        // actualizar tipo documento
        public bool update(TipoDocumentoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarTipoDocumento";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codtipdoc", id);
                cmd.Parameters.AddWithValue("@nomtipdoc", obj.nombre);
                cmd.Parameters.AddWithValue("@esttipdoc", obj.estado);

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

        // eliminar tipo documento
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarTipoDocumento";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codtipdoc", id);

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

        // habilitar tipo documento
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarTipoDocumento";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codtipdoc", id);

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
