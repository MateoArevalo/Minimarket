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
    public class D_Productos
    {
        public DataTable Lista_pr(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Listado_pr", con);
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

        public DataTable Lista_ma_pr(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Listado_ma_pr", con);
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

        public DataTable Lista_um_pr(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Listado_um_pr", con);
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

        public string Guardar_pr(int nOpcion, E_Productos oProductos)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Guardar_pr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                cmd.Parameters.Add("@nCodigo_pr", SqlDbType.Int).Value = oProductos.Codigo_pr;
                cmd.Parameters.Add("@cDescripcion_pr", SqlDbType.VarChar).Value = oProductos.Descripcion_pr;
                cmd.Parameters.Add("@nCodigo_ma", SqlDbType.Int).Value = oProductos.Codigo_ma;
                cmd.Parameters.Add("@nCodigo_um", SqlDbType.Int).Value = oProductos.Codigo_um;
                cmd.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = oProductos.Codigo_ca;
                cmd.Parameters.Add("@nStock_min", SqlDbType.Int).Value = oProductos.Stock_min;
                cmd.Parameters.Add("@nStock_max", SqlDbType.Int).Value = oProductos.Stock_max;
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

        public string Eliminar_pr(int codigo_pr)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Eliminar_pr", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nCodigo_pr", SqlDbType.Int).Value = codigo_pr;
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
