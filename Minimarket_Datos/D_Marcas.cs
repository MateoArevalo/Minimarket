using Minimarket_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket_Datos
{
    public class D_Marcas
    {
        public DataTable Lista_ma(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Listado_ma", con);
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

        public string Guardar_ma(int nOpcion, E_Marcas oMarcas)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Guardar_ma", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                cmd.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = oMarcas.Codigo_ma;
                cmd.Parameters.Add("@cDescripcion_ma", SqlDbType.VarChar).Value = oMarcas.Descripcion_ma;
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

        public string Eliminar_ma(int codigo_ma)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Eliminar_ma", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = codigo_ma;
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
