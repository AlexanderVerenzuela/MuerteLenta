using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.muertelenta.dal
{
    public class RolDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        // listar roles
        public List<RolBO> findAll()
        {
            List<RolBO> lista = new List<RolBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarRol";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();
                    obj.codigo = Convert.ToInt32(dr["codrol"]);
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"]);
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
        public RolBO findById(int id)
        {
            RolBO obj = new RolBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarRolXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codrol", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["codrol"]);
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"]);
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

        // registrar rol
        public bool add(RolBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarRol";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nomrol", obj.nombre);
                cmd.Parameters.AddWithValue("@estrol", obj.estado);

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

        // actualizar rol
        public bool update(RolBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarRol";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codrol", id);
                cmd.Parameters.AddWithValue("@nomrol", obj.nombre);
                cmd.Parameters.AddWithValue("@estrol", obj.estado);

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

        // eliminar rol
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarRol";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codrol", id);

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

        // habilitar rol
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarRol";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codrol", id);

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
