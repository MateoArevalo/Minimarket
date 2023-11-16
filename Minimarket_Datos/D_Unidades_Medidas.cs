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
    public class D_Unidades_Medidas
    {
        public DataTable Lista_um(string cTexto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Listado_um", con);
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

        public string Guardar_um(int nOpcion, E_Unidades_Medidas oUnidadesMedidas)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Guardar_um", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                cmd.Parameters.Add("@nCodigo_um", SqlDbType.Int).Value = oUnidadesMedidas.Codigo_um;
                cmd.Parameters.Add("@cAbreviatura_um", SqlDbType.VarChar).Value = oUnidadesMedidas.Abreviatura_um;
                cmd.Parameters.Add("@cDescripcion_um", SqlDbType.VarChar).Value = oUnidadesMedidas.Descripcion_um;
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

        public string Eliminar_um(int codigo_um)
        {
            string resp = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.getInstance().CrearConexion();
                SqlCommand cmd = new SqlCommand("USP_Eliminar_um", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nCodigo_um", SqlDbType.Int).Value = codigo_um;
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
