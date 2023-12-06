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
    public class N_Productos
    {
        public static DataTable Lista_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Lista_pr(cTexto);
        }

        public static DataTable Lista_ma_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Lista_ma_pr(cTexto);
        }

        public static DataTable Lista_um_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Lista_um_pr(cTexto);
        }

        public static DataTable Lista_ca_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Lista_ca_pr(cTexto);
        }

        public static DataTable Ver_Stock_actual_ProductoXAlmacene(int nCodigo_pr)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Ver_Stock_actual_ProductoXAlmacenes(nCodigo_pr);
        }

        public static string Guardar_pr(int nOpcion, E_Productos oProductos)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Guardar_pr(nOpcion, oProductos);
        }

        public static string Eliminar_pr(int codigo_pr)
        {
            D_Productos Datos = new D_Productos();
            return Datos.Eliminar_pr(codigo_pr);
        }
    }
}
