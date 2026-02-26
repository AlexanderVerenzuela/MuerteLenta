using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace pe.com.muertelenta.ui.test
{
    public class ConexionTest
    {
        public static void ProbarConexion()
        {
            var conexion = new ConexionDAL();
            SqlConnection xcon = null;
            try
            {
                xcon = conexion.Conectar();
                if (xcon != null && xcon.State == ConnectionState.Open)
                {
                    Debug.WriteLine("Conexion exitosa");
                }
                else
                {
                    Debug.WriteLine("No se pudo conectar");
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (xcon != null)
                {
                    conexion.CerrarConexion();
                }
            }
        }

    }
}