using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.muertelenta.dal
{
    public class DistritoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        // listar distritos
        public List<DistritoBO> findAll()
        {
            List<DistritoBO> lista = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistrito";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["coddist"]);
                    obj.nombre = dr["nomdist"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdist"]);
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

        // buscar distrito por código
        public DistritoBO findById(int id)
        {
            DistritoBO obj = new DistritoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarDistritoXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@coddist", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["coddist"]);
                    obj.nombre = dr["nomdist"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdist"]);
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

        // registrar distrito
        public bool add(DistritoBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarDistrito";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nomdist", obj.nombre);
                cmd.Parameters.AddWithValue("@estdist", obj.estado);

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

        // actualizar distrito
        public bool update(DistritoBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarDistrito";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@coddist", id);
                cmd.Parameters.AddWithValue("@nomdist", obj.nombre);
                cmd.Parameters.AddWithValue("@estdist", obj.estado);

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

        // eliminar distrito
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarDistrito";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@coddist", id);

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

        // habilitar distrito
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarDistrito";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@coddist", id);

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

        public List<DistritoBO> findAllCustom()
        {
            throw new NotImplementedException();
        }
    }
}
