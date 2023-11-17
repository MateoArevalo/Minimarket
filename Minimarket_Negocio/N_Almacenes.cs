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
    public class N_Almacenes
    {
        public static DataTable Lista_al(string cTexto)
        {
            D_Almacenes Datos = new D_Almacenes();
            return Datos.Lista_al(cTexto);
        }

        public static string Guardar_al(int nOpcion, E_Almacenes oAlmacenes)
        {
            D_Almacenes Datos = new D_Almacenes();
            return Datos.Guardar_al(nOpcion, oAlmacenes);
        }

        public static string Eliminar_al(int codigo_al)
        {
            D_Almacenes Datos = new D_Almacenes();
            return Datos.Eliminar_al(codigo_al);
        }
    }
}
