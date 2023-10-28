using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Minimarket_Datos;
using Minimarket_Entidades;

namespace Minimarket_Negocio
{
    public class N_Categorias
    {
        public static DataTable Lista_ca(string cTexto)
        {
            D_Categorias Datos = new D_Categorias();
            return Datos.Lista_ca(cTexto);
        }

        public static string Guardar_ca(int nOpcion, E_Categorias oCategoria)
        {
            D_Categorias Datos = new D_Categorias();
            return Datos.Guardar_ca(nOpcion, oCategoria);
        }

        public static string Eliminar_ca(int codigo_ca)
        {
            D_Categorias Datos = new D_Categorias();
            return Datos.Eliminar_ca(codigo_ca);
        }
    }
}
