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
    public partial class Frm_Unidades_Medidas : Form
    {
        public Frm_Unidades_Medidas()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int estadoGuarda = 0; //Sin ninguna accion
        int codigoUm = 0;
        #endregion

        #region Mis Metodos
        private void Formato_um()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO";
            Dgv_principal.Columns[1].Width = 100;
            Dgv_principal.Columns[1].HeaderText = "ABREVIATURA";
            Dgv_principal.Columns[2].Width = 250;
            Dgv_principal.Columns[2].HeaderText = "MEDIDA";
        }

        private void Listar_um(string cTexto)
        {
            try
            {
                
                DataTable datos = N_Unidades_Medidas.Lista_um(cTexto);
                Console.WriteLine("Filas antes del formato: " + datos.Rows.Count);
                Dgv_principal.DataSource = datos;
                Console.WriteLine("Filas después del formato: " + Dgv_principal.Rows.Count);
                this.Formato_um();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoUm = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                Txt_abreviatura_um.Text = Dgv_principal.CurrentRow.Cells["abreviatura_um"].Value.ToString();
                Txt_descripcion_um.Text = Dgv_principal.CurrentRow.Cells["descripcion_um"].Value.ToString();
            }
        }

        #endregion

        private void Frm_Unidades_Medidas_Load(object sender, EventArgs e)
        {
            this.Listar_um("%");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_abreviatura_um.Text == string.Empty || Txt_descripcion_um.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Procede a registrar la informacion
            {
                E_Unidades_Medidas oUnidadesMedidas = new E_Unidades_Medidas();
                string respuesta = string.Empty;
                oUnidadesMedidas.Codigo_um = this.codigoUm;
                oUnidadesMedidas.Abreviatura_um = Txt_abreviatura_um.Text.Trim();
                oUnidadesMedidas.Descripcion_um = Txt_descripcion_um.Text.Trim();
                respuesta = N_Unidades_Medidas.Guardar_um(estadoGuarda, oUnidadesMedidas);
                if (respuesta == "OK")
                {
                    this.Listar_um("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoGuarda = 0; //Finaliza su accion
                    this.EstadoBotonesPrincipales(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_abreviatura_um.Text = string.Empty;
                    Txt_abreviatura_um.ReadOnly = true;
                    Txt_descripcion_um.Text = string.Empty;
                    Txt_descripcion_um.ReadOnly = true;
                    Tbp_Principal.SelectedIndex = 0;
                    this.codigoUm = 0;
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
            Txt_abreviatura_um.Text = string.Empty;
            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.Text = string.Empty;
            Txt_descripcion_um.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_abreviatura_um.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 2; //Actualizar registro
            this.EstadoBotonesPrincipales(false);
            this.EstadoBotonesProcesos(true);
            this.SeleccionarItem();
            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_abreviatura_um.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 0; //Sin ninguna accion
            this.codigoUm = 0;
            Txt_abreviatura_um.Text = string.Empty;
            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.Text = string.Empty;
            Txt_descripcion_um.ReadOnly = true;
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
            Txt_abreviatura_um.Text = string.Empty;
            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.Text = string.Empty;
            Txt_descripcion_um.ReadOnly = true;
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
            this.codigoUm = 0;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_um"].Value)))
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
                    this.codigoUm = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                    resp = N_Unidades_Medidas.Eliminar_um(this.codigoUm);
                    if(resp.Equals("OK"))
                    {
                        this.Listar_um("%");
                        this.codigoUm = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_um(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Unidades_Medidas oRpt3 = new Reportes.Frm_Rpt_Unidades_Medidas();
            oRpt3.txt_p1.Text = Txt_buscar.Text;
            oRpt3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
