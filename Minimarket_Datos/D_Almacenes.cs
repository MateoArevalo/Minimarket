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
    public class D_Almacenes
    {
        public DataTable Lista_al(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Listado_al", con);
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

        public string Guardar_al(int nOpcion, E_Almacenes oAlmacenes)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Guardar_al", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                cmd.Parameters.Add("@nCodigo_al", SqlDbType.Int).Value = oAlmacenes.Codigo_al;
                cmd.Parameters.Add("@cDescripcion_al", SqlDbType.VarChar).Value = oAlmacenes.Descripcion_al;
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

        public string Eliminar_al(int codigo_al)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Eliminar_al", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nCodigo_al", SqlDbType.Int).Value = codigo_al;
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
