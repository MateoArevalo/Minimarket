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
    public partial class Frm_Almacenes : Form
    {
        public Frm_Almacenes()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int estadoGuarda = 0; //Sin ninguna accion
        int codigoAl = 0;
        #endregion

        #region Mis Metodos
        private void Formato_al()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO";
            Dgv_principal.Columns[1].Width = 350;
            Dgv_principal.Columns[1].HeaderText = "ALMACÉN";
        }

        private void Listar_al(string cTexto)
        {
            try
            {
                
                DataTable datos = N_Almacenes.Lista_al(cTexto);
                Console.WriteLine("Filas antes del formato: " + datos.Rows.Count);
                Dgv_principal.DataSource = datos;
                Console.WriteLine("Filas después del formato: " + Dgv_principal.Rows.Count);
                this.Formato_al();
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

        private void SeleccionarItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_al"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoAl = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_al.Text = Dgv_principal.CurrentRow.Cells["descripcion_al"].Value.ToString();
            }
        }

        #endregion

        private void Frm_Almacenes_Load(object sender, EventArgs e)
        {
            this.Listar_al("%");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_al.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Procede a registrar la informacion
            {
                E_Almacenes oAlmacenes = new E_Almacenes();
                string respuesta = string.Empty;
                oAlmacenes.Codigo_al = this.codigoAl;
                oAlmacenes.Descripcion_al = Txt_descripcion_al.Text.Trim();
                respuesta = N_Almacenes.Guardar_al(estadoGuarda, oAlmacenes);
                if (respuesta == "OK")
                {
                    this.Listar_al("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoGuarda = 0; //Finaliza su accion
                    this.EstadoBotonesPrincipales(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_descripcion_al.Text = string.Empty;
                    Txt_descripcion_al.ReadOnly = true;
                    Tbp_Principal.SelectedIndex = 0;
                    this.codigoAl = 0;
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
            Txt_descripcion_al.Text = string.Empty;
            Txt_descripcion_al.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_al.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 2; //Actualizar registro
            this.EstadoBotonesPrincipales(false);
            this.EstadoBotonesProcesos(true);
            this.SeleccionarItem();
            Txt_descripcion_al.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_al.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 0; //Sin ninguna accion
            this.codigoAl = 0;
            Txt_descripcion_al.Text = string.Empty;
            Txt_descripcion_al.ReadOnly = true;
            this.EstadoBotonesPrincipales(true);
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
        }

        private void Dgv_principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItem();
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 1;
        }

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            //estadoGuarda = 0;
            Txt_descripcion_al.Text = string.Empty;
            Txt_descripcion_al.ReadOnly = true;
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
            this.codigoAl = 0;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Estas seguro de eliminar el registro seleccionado?","Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    string resp = String.Empty;
                    this.codigoAl = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                    resp = N_Almacenes.Eliminar_al(this.codigoAl);
                    if(resp.Equals("OK"))
                    {
                        this.Listar_al("%");
                        this.codigoAl = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_al(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Almacenes oRpt4 = new Reportes.Frm_Rpt_Almacenes();
            oRpt4.txt_p1.Text = Txt_buscar.Text;
            oRpt4.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
