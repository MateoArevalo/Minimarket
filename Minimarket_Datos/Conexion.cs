using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Minimarket_Datos
{
    public class Conexion
    {
        private string baseDatos;
        private string server;
        private string user;
        private string password;
        private bool security;
        private static Conexion con = null;

        private Conexion() 
        {
            this.baseDatos = "DB_Minimarket";
            this.server = "ARTEMISA\\SQLEXPRESS";
            this.user = "sistemas";
            this.password = "admin";
            this.security = false;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = "Server=" + this.server + "; Database=" + this.baseDatos + ";";
                if(this.security) 
                {
                    connection.ConnectionString = connection.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    connection.ConnectionString = connection.ConnectionString + "User Id=" + this.user + "; Password=" + this.password;
                }
            }
            catch (Exception ex)
            {
                connection = null;
                throw ex;
            }
            return connection;
        }

        public static Conexion getInstance()
        {
            if(con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}