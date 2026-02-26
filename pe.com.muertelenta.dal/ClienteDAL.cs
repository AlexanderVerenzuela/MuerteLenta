using pe.com.muertelenta.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace pe.com.muertelenta.dal
{
    public class ClienteDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        private int res = 0;

        // listar clientes
        public List<ClienteBO> findAll()
        {
            List<ClienteBO> lista = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarCliente";
                cmd.Connection = objconexion.Conectar();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClienteBO obj = new ClienteBO();

                    obj.CodCli = Convert.ToInt32(dr["codcli"]);
                    obj.NomCli = dr["nomcli"].ToString();
                    obj.ApeCli = dr["apecli"].ToString();
                    obj.NumDocCli = dr["numdoccli"].ToString();
                    obj.CodTipDoc = Convert.ToInt32(dr["codtipdoc"]);
                    obj.CodSex = Convert.ToInt32(dr["codsex"]);
                    obj.CodDis = Convert.ToInt32(dr["coddist"]);
                    obj.EstCli = Convert.ToBoolean(dr["estcli"]);

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

        // buscar cliente por código
        public ClienteBO findById(int id)
        {
            ClienteBO obj = new ClienteBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarClienteXCodigo";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codcli", id);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.CodCli = Convert.ToInt32(dr["codcli"]);
                    obj.NomCli = dr["nomcli"].ToString();
                    obj.ApeCli = dr["apecli"].ToString();
                    obj.NumDocCli = dr["numdoccli"].ToString();
                    obj.CodTipDoc = Convert.ToInt32(dr["codtipdoc"]);
                    obj.CodSex = Convert.ToInt32(dr["codsex"]);
                    obj.CodDis = Convert.ToInt32(dr["coddist"]);
                    obj.EstCli = Convert.ToBoolean(dr["estcli"]);
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

        // registrar cliente
        public bool add(ClienteBO obj)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarCliente";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@nomcli", obj.NomCli);
                cmd.Parameters.AddWithValue("@apecli", obj.ApeCli);
                cmd.Parameters.AddWithValue("@numdoccli", obj.NumDocCli);
                cmd.Parameters.AddWithValue("@codtipdoc", obj.CodTipDoc);
                cmd.Parameters.AddWithValue("@codsex", obj.CodSex);
                cmd.Parameters.AddWithValue("@coddist", obj.CodDis);
                cmd.Parameters.AddWithValue("@estcli", obj.EstCli);

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

        // actualizar cliente
        public bool update(ClienteBO obj, int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarCliente";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codcli", id);
                cmd.Parameters.AddWithValue("@nomcli", obj.NomCli);
                cmd.Parameters.AddWithValue("@apecli", obj.ApeCli);
                cmd.Parameters.AddWithValue("@numdoccli", obj.NumDocCli);
                cmd.Parameters.AddWithValue("@codtipdoc", obj.CodTipDoc);
                cmd.Parameters.AddWithValue("@codsex", obj.CodSex);
                cmd.Parameters.AddWithValue("@coddist", obj.CodDis);
                cmd.Parameters.AddWithValue("@estcli", obj.EstCli);

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

        // eliminar cliente
        public bool delete(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarCliente";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codcli", id);

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

        // habilitar cliente
        public bool enable(int id)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarCliente";
                cmd.Connection = objconexion.Conectar();

                cmd.Parameters.AddWithValue("@codcli", id);

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
