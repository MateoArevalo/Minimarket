using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Minimarket_Entidades;

namespace Minimarket_Datos
{
    public class D_Categorias
    {
        public DataTable Lista_ca(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("UPS_Listado_ca", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                con.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public string Guardar_ca(int nOpcion, E_Categorias oCategoria)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("UPS_Guardar_ca", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nOpcion",SqlDbType.Int).Value = nOpcion;
                cmd.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = oCategoria.Codigo_ca;
                cmd.Parameters.Add("@cDescripcion_ca", SqlDbType.VarChar).Value = oCategoria.Descripcion_ca;
                con.Open();
                resp = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo registrar los datos";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return resp;
        }

        public string Eliminar_ca(int codigo_ca)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Eliminar_ca", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = codigo_ca;
                con.Open();
                resp = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return resp;
        }
    }
}
