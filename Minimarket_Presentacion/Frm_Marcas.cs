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
    public partial class Frm_Marcas : Form
    {
        public Frm_Marcas()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int estadoGuarda = 0; //Sin ninguna accion
        int codigoCa = 0;
        #endregion

        #region Mis Metodos
        private void Formato_ca()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO";
            Dgv_principal.Columns[1].Width = 350;
            Dgv_principal.Columns[1].HeaderText = "MARCA";
        }

        private void Listar_ma(string cTexto)
        {
            try
            {
                
                DataTable datos = N_Marcas.Lista_ma(cTexto);
                Console.WriteLine("Filas antes del formato: " + datos.Rows.Count);
                Dgv_principal.DataSource = datos;
                Console.WriteLine("Filas después del formato: " + Dgv_principal.Rows.Count);
                this.Formato_ca();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoCa = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ma.Text = Dgv_principal.CurrentRow.Cells["descripcion_ca"].Value.ToString();
            }
        }

        #endregion

        private void Frm_Marcas_Load(object sender, EventArgs e)
        {
            this.Listar_ma("%");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ma.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Procede a registrar la informacion
            {
                E_Marcas oMarcas = new E_Marcas();
                string respuesta = string.Empty;
                oMarcas.Codigo_ma = this.codigoCa;
                oMarcas.Descripcion_ma = Txt_descripcion_ma.Text.Trim();
                respuesta = N_Marcas.Guardar_ma(estadoGuarda, oMarcas);
                if (respuesta == "OK")
                {
                    this.Listar_ma("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoGuarda = 0; //Finaliza su accion
                    this.EstadoBotonesPrincipales(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_descripcion_ma.Text = string.Empty;
                    Txt_descripcion_ma.ReadOnly = true;
                    Tbp_Principal.SelectedIndex = 0;
                    this.codigoCa = 0;
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
            Txt_descripcion_ma.Text = string.Empty;
            Txt_descripcion_ma.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_ma.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 2; //Actualizar registro
            this.EstadoBotonesPrincipales(false);
            this.EstadoBotonesProcesos(true);
            this.SeleccionarItem();
            Txt_descripcion_ma.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_ma.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 0; //Sin ninguna accion
            this.codigoCa = 0;
            Txt_descripcion_ma.Text = string.Empty;
            Txt_descripcion_ma.ReadOnly = true;
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
            Txt_descripcion_ma.Text = string.Empty;
            Txt_descripcion_ma.ReadOnly = true;
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
            this.codigoCa = 0;
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
                    this.codigoCa = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                    resp = N_Marcas.Eliminar_ma(this.codigoCa);
                    if(resp.Equals("OK"))
                    {
                        this.Listar_ma("%");
                        this.codigoCa = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_ma(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Marcas oRpt2 = new Reportes.Frm_Rpt_Marcas();
            oRpt2.txt_p1.Text = Txt_buscar.Text;
            oRpt2.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
