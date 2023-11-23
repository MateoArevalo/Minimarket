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
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int estadoGuarda = 0; //Sin ninguna accion
        int codigoPr = 0;
        int codigoMa = 0;
        int codigoUm = 0;
        int codigoCa = 0;
        #endregion

        #region Mis Metodos
        private void Formato_pr()
        {
            Dgv_principal.Columns[0].Width = 70;
            Dgv_principal.Columns[0].HeaderText = "CÓDIGO";
            Dgv_principal.Columns[1].Width = 250;
            Dgv_principal.Columns[1].HeaderText = "PRODUCTO";
            Dgv_principal.Columns[2].Width = 150;
            Dgv_principal.Columns[2].HeaderText = "MARCA";
            Dgv_principal.Columns[3].Width = 100;
            Dgv_principal.Columns[3].HeaderText = "U.MEDIDA";
            Dgv_principal.Columns[4].Width = 150;
            Dgv_principal.Columns[4].HeaderText = "CATEGORÍA";
            Dgv_principal.Columns[5].Width = 70;
            Dgv_principal.Columns[5].HeaderText = "STOCK MIN";
            Dgv_principal.Columns[6].Width = 70;
            Dgv_principal.Columns[6].HeaderText = "STOCK MAX";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
        }

        private void Listar_pr(string cTexto)
        {
            try
            {
                
                DataTable datos = N_Productos.Lista_pr(cTexto);
                Console.WriteLine("Filas antes del formato: " + datos.Rows.Count);
                Dgv_principal.DataSource = datos;
                Console.WriteLine("Filas después del formato: " + Dgv_principal.Rows.Count);
                this.Formato_pr();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoPr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value);
                Txt_descripcion_pr.Text = Dgv_principal.CurrentRow.Cells["descripcion_pr"].Value.ToString();

            }
        }

        private void Formato_ma_pr()
        {
            Dgv_marcas.Columns[0].Width = 230;
            Dgv_marcas.Columns[0].HeaderText = "MARCA";
            Dgv_marcas.Columns[1].Visible = false;
        }

        private void Listar_ma_pr(string cTexto)
        {
            try
            {

                DataTable datos = N_Productos.Lista_ma_pr(cTexto);
                Console.WriteLine("Filas antes del formato: " + datos.Rows.Count);
                Dgv_marcas.DataSource = datos;
                Console.WriteLine("Filas después del formato: " + Dgv_marcas.Rows.Count);
                this.Formato_ma_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarItem_ma_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoMa = Convert.ToInt32(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value);
                Txt_marca_pr.Text = Dgv_marcas.CurrentRow.Cells["descripcion_ma"].Value.ToString();

            }
        }

        #endregion

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.Listar_pr("%");
            this.Listar_ma_pr("%");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_pr.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Procede a registrar la informacion
            {
                E_Productos oProductos = new E_Productos();
                string respuesta = string.Empty;
                oProductos.Codigo_pr = this.codigoPr;
                oProductos.Descripcion_pr = Txt_descripcion_pr.Text.Trim();
                respuesta = N_Productos.Guardar_pr(estadoGuarda, oProductos);
                if (respuesta == "OK")
                {
                    this.Listar_pr("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoGuarda = 0; //Finaliza su accion
                    this.EstadoBotonesPrincipales(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_descripcion_pr.Text = string.Empty;
                    Txt_descripcion_pr.ReadOnly = true;
                    Tbp_Principal.SelectedIndex = 0;
                    this.codigoPr = 0;
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
            Txt_descripcion_pr.Text = string.Empty;
            Txt_descripcion_pr.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_pr.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 2; //Actualizar registro
            this.EstadoBotonesPrincipales(false);
            this.EstadoBotonesProcesos(true);
            this.SeleccionarItem();
            Txt_descripcion_pr.ReadOnly = false;
            Tbp_Principal.SelectedIndex = 1;
            Txt_descripcion_pr.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 0; //Sin ninguna accion
            this.codigoPr = 0;
            Txt_descripcion_pr.Text = string.Empty;
            Txt_descripcion_pr.ReadOnly = true;
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
            Txt_descripcion_pr.Text = string.Empty;
            Txt_descripcion_pr.ReadOnly = true;
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
            this.codigoPr = 0;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
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
                    this.codigoPr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                    resp = N_Productos.Eliminar_pr(this.codigoPr);
                    if(resp.Equals("OK"))
                    {
                        this.Listar_pr("%");
                        this.codigoPr = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_pr(Txt_buscar.Text.Trim());
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            //Reportes.Frm_Rpt_Productos oRpt5 = new Reportes.Frm_Rpt_Productos();
            //oRpt5.txt_p1.Text = Txt_buscar.Text;
            //oRpt5.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ma.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ma.Visible = true;
        }

        private void Dgv_marcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItem_ma_pr();
            this.Pnl_Listado_ma.Visible = false;
        }
    }
}
