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
    public class N_Unidades_Medidas
    {
        public static DataTable Lista_um(string cTexto)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Lista_um(cTexto);
        }

        public static string Guardar_um(int nOpcion, E_Unidades_Medidas oUnidadesMedidas)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Guardar_um(nOpcion, oUnidadesMedidas);
        }

        public static string Eliminar_um(int codigo_um)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Eliminar_um(codigo_um);
        }
    }
}
