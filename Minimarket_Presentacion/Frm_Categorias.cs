using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimarket_Entidades;
using Minimarket_Negocio;

namespace Minimarket_Presentacion
{
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int estadoGuarda = 0; //Sin ninguna accion
        #endregion

        #region Mis Metodos
        private void Formato_ca()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "Codigo";
            Dgv_principal.Columns[1].Width = 300;
            Dgv_principal.Columns[1].HeaderText = "Categoria";
        }

        private void Listar_ca(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Categorias.Lista_ca(cTexto);
            }
            catch ( Exception ex )
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void EstadoBotonesPrincipales(bool lEstado)
        {
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_salir.Enabled = lEstado;
        }

        private void EstadoBotonesProcesos(bool lEstado)
        {
            this.Btn_Guardar.Visible = lEstado;
            this.Btn_Cancelar.Visible = lEstado;
            this.Btn_Retornar.Visible = !lEstado;
        }

        #endregion

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {
            this.Listar_ca("%");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ca.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Procede a registrar la informacion
            {
                E_Categorias oCategoria = new E_Categorias();
                string respuesta = string.Empty;
                oCategoria.Codigo_ca = 0;
                oCategoria.Descripcion_ca = Txt_descripcion_ca.Text.Trim();
                respuesta = N_Categorias.Guardar_ca(estadoGuarda, oCategoria);
                if (respuesta == "OK")
                {
                    this.Listar_ca("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoGuarda = 0; //Finaliza su accion
                    this.EstadoBotonesPrincipales(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_descripcion_ca.Text = string.Empty;
                    Txt_descripcion_ca.ReadOnly = true;
                    Tbp_Principal.SelectedIndex = 0;                    
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            estadoGuarda = 1; //Nuevo registro
            this.EstadoBotonesPrincipales(false);
            this.EstadoBotonesProcesos(true);
            Txt_descripcion_ca.Text = string.Empty;
            Txt_descripcion_ca.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_ca.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 2; //Actualizar registro
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 0; //Sin ninguna accion
            Txt_descripcion_ca.Text = string.Empty;
            Txt_descripcion_ca.ReadOnly = true;
            this.EstadoBotonesPrincipales(true);
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
        }
    }
}
