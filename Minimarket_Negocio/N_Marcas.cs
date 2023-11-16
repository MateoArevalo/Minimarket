using Minimarket_Datos;
using Minimarket_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket_Negocio
{
    public class N_Marcas
    {
        public static DataTable Lista_ma(string cTexto)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Lista_ma(cTexto);
        }

        public static string Guardar_ma(int nOpcion, E_Marcas oMarcas)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Guardar_ma(nOpcion, oMarcas);
        }

        public static string Eliminar_ma(int codigo_ma)
        {
            D_Marcas Datos = new D_Marcas();
            return Datos.Eliminar_ma(codigo_ma);
        }
    }
}
