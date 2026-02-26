using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.dal
{
    public class ConexionDAL
    {
        //cadena de conexion -> clase que te permite conectarte al servidor SQL Server
        //Tipos de Conecion
        //Existen 2 tipos de conexiones: Autentificacion de Windows y Autenficacion SQL

        //Autenticacion Windows
        //SQL Server Standard, Profesional o Enterprise
        //private string cadena = "Data Source=.; Initial Catalog=bdmuertelenta20260; Integrated Security=True; TrustServerCertificate=True;";
        //SQL Express
        //private string cadena = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=bdmuertelenta20260; Integrated Security=True; TrustServerCertificate=True;";
        //Data Source: es el nombre del servidor SQL Server
        //Initial Catalog: es el nombre de la base de datos donde me quiero conectar
        //Integrated Security: autenticacion que se realiza con las credenciales
        //TrustServerCertificate: es una opcion de seguridad donde se aceptan o no el certificado de seguridad

        //Autenticacion SQL
        //SQL Server Standard, Profesional o Enterprise
        //private string cadena = "Data Source=.; Initial Catalog=bdmuertelenta20260; User ID=sa; Password=sql; TrustServerCertificate=True;";
        //SQL Express
        //private string cadena = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=bdmuertelenta20260; User ID=sa; Password=sql; TrustServerCertificate=True;";
        //Data Source: es el nombre del servidor SQL Server
        //Initial Catalog: es el nombre de la base de datos donde me quiero conectar
        //User ID: es el usuario SQL, previamente creado
        //Password: es la clave del usuario SQL que se esta utilizando para la conexion
        //TrustServerCertificate: es una opcion de seguridad donde se aceptan o no el certificado de seguridad

        //Proveedores para poder conectarse a SQL Server mediante ADO.NET
        //System.data.SqlClient: proveedor clasico
        //Microsoft.Data.SQLClient: proveedor modernos y recomencado

        //cadena de conexion
        private string cadena = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=bdmuertelenta20260; Integrated Security=True; TrustServerCertificate=True;";

        //creamos un objeto de tipo SqlConnection
        private SqlConnection xcon;

        //creamos una funcion para poder conectarnos
        public SqlConnection Conectar()
        {
            try
            {
                //instanciamos la cadena de conexion
                xcon = new SqlConnection(cadena);
                //abrimos la conexion
                xcon.Open();
                //devolvemos la conexion abierta
                return xcon;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        //creamos un procedimiento para cerrar la cadena de conexion
        public void CerrarConexion()
        {
            //cerramos la cadena de conexion
            xcon.Close();
            //liberamos los recursos
            xcon.Dispose();
        }

    }
}
