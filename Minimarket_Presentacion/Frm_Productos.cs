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
                Dgv_principal.DataSource = datos;
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
                this.codigoMa = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ma"].Value);
                Txt_marca_pr.Text = Dgv_principal.CurrentRow.Cells["descripcion_ma"].Value.ToString();
                this.codigoUm = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                Txt_medida_pr.Text = Dgv_principal.CurrentRow.Cells["descripcion_um"].Value.ToString();
                this.codigoCa = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                Txt_categoria_pr.Text = Dgv_principal.CurrentRow.Cells["descripcion_ca"].Value.ToString();
                Txt_stockMax_pr.Text = Dgv_principal.CurrentRow.Cells["stock_max"].Value.ToString();
                Txt_stockMin_pr.Text = Dgv_principal.CurrentRow.Cells["stock_min"].Value.ToString();
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
                Dgv_marcas.DataSource = datos;
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

        private void Formato_um_pr()
        {
            Dgv_unidades_medida.Columns[0].Width = 230;
            Dgv_unidades_medida.Columns[0].HeaderText = "MEDIDAS";
            Dgv_unidades_medida.Columns[1].Visible = false;
        }

        private void Listar_um_pr(string cTexto)
        {
            try
            {

                DataTable datos = N_Productos.Lista_um_pr(cTexto);
                Dgv_unidades_medida.DataSource = datos;
                this.Formato_um_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarItem_um_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_unidades_medida.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoUm = Convert.ToInt32(Dgv_unidades_medida.CurrentRow.Cells["codigo_um"].Value);
                Txt_medida_pr.Text = Dgv_unidades_medida.CurrentRow.Cells["descripcion_um"].Value.ToString();

            }
        }

        private void Formato_ca_pr()
        {
            Dgv_categorias.Columns[0].Width = 230;
            Dgv_categorias.Columns[0].HeaderText = "CATEGORIAS";
            Dgv_categorias.Columns[1].Visible = false;
        }

        private void Listar_ca_pr(string cTexto)
        {
            try
            {

                DataTable datos = N_Productos.Lista_ca_pr(cTexto);
                Dgv_categorias.DataSource = datos;
                this.Formato_ca_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarItem_ca_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene informacion para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigoCa = Convert.ToInt32(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value);
                Txt_categoria_pr.Text = Dgv_categorias.CurrentRow.Cells["descripcion_ca"].Value.ToString();

            }
        }

        private void Formato_stock_actual()
        {
            Dgv_Stock_actual.Columns[0].Width = 200;
            Dgv_Stock_actual.Columns[0].HeaderText = "ALMACÉN";
            Dgv_Stock_actual.Columns[1].Width = 150;
            Dgv_Stock_actual.Columns[1].HeaderText = "STOCK ACTUAL";
            Dgv_Stock_actual.Columns[2].Width = 150;
            Dgv_Stock_actual.Columns[2].HeaderText = "P.U COMPRA";
        }

        private void Listar_stock_actual(int nCodigo_pr)
        {
            try
            {

                DataTable datos = N_Productos.Ver_Stock_actual_ProductoXAlmacene(nCodigo_pr);
                Dgv_Stock_actual.DataSource = datos;
                this.Formato_stock_actual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.Listar_pr("%");
            this.Listar_ma_pr("%");
            this.Listar_um_pr("%");
            this.Listar_ca_pr("%");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_pr.Text == string.Empty || 
                Txt_marca_pr.Text == string.Empty ||
                Txt_medida_pr.Text == string.Empty ||
                Txt_categoria_pr.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Procede a registrar la informacion
            {
                E_Productos oProductos = new E_Productos();
                string respuesta = string.Empty;
                oProductos.Codigo_pr = this.codigoPr;
                oProductos.Descripcion_pr = Txt_descripcion_pr.Text.Trim();
                oProductos.Codigo_ma = this.codigoMa;
                oProductos.Codigo_um = this.codigoUm;
                oProductos.Codigo_ca = this.codigoCa;
                oProductos.Stock_max = Convert.ToDecimal(this.Txt_stockMax_pr.Text.Trim());
                oProductos.Stock_min = Convert.ToDecimal(this.Txt_stockMin_pr.Text.Trim());
                respuesta = N_Productos.Guardar_pr(estadoGuarda, oProductos);
                if (respuesta == "OK")
                {
                    this.Listar_pr("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoGuarda = 0; //Finaliza su accion
                    this.EstadoBotonesPrincipales(true);
                    this.EstadoBotonesProcesos(false);
                    Txt_descripcion_pr.Text = string.Empty;
                    Txt_stockMax_pr.Text = "0";
                    Txt_stockMin_pr.Text = "0";
                    Txt_descripcion_pr.ReadOnly = true;
                    Txt_stockMax_pr.ReadOnly = true;
                    Txt_stockMin_pr.ReadOnly = true;
                    Tbp_Principal.SelectedIndex = 0;
                    this.codigoPr = 0;
                    this.Gbx_detalle.Visible = false;
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
            this.Gbx_detalle.Visible = false;
            this.EstadoBotonesPrincipales(false);
            this.EstadoBotonesProcesos(true);
            Txt_descripcion_pr.Text = string.Empty;
            Txt_stockMin_pr.Text = "0";
            Txt_stockMax_pr.Text = "0";
            Txt_descripcion_pr.ReadOnly = false;
            Txt_stockMin_pr.ReadOnly = false;
            Txt_stockMax_pr.ReadOnly = false;
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
            this.Gbx_detalle.Visible = false;
            Txt_descripcion_pr.Text = string.Empty;
            Txt_stockMax_pr.Text = "0";
            Txt_stockMin_pr.Text = "0";
            Txt_descripcion_pr.ReadOnly = true;
            Txt_stockMax_pr.ReadOnly = true;
            Txt_stockMin_pr.ReadOnly = true;
            this.EstadoBotonesPrincipales(true);
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
        }

        private void Dgv_principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItem();
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 1;
            this.Listar_stock_actual(this.codigoPr);
            Gbx_detalle.Visible = true;
        }

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            //estadoGuarda = 0;
            Txt_descripcion_pr.Text = string.Empty;
            Txt_descripcion_pr.ReadOnly = true;
            this.EstadoBotonesProcesos(false);
            Tbp_Principal.SelectedIndex = 0;
            this.codigoPr = 0;
            this.Gbx_detalle.Visible = false;
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
            Reportes.Frm_Rpt_Productos oRpt5 = new Reportes.Frm_Rpt_Productos();
            oRpt5.txt_p1.Text = Txt_buscar.Text;
            oRpt5.ShowDialog();
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
            this.Txt_buscar1.Text = string.Empty;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_um.Location = Btn_lupa1.Location;
            this.Pnl_Listado_um.Visible = true;
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listar_ma_pr(Txt_buscar1.Text);
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            this.Listar_um_pr(Txt_buscar2.Text);
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ma.Visible = false;
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_um.Visible = false;
        }

        private void Dgv_unidades_medida_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItem_um_pr();
            this.Pnl_Listado_um.Visible = false;
            this.Txt_buscar2.Text = string.Empty;
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            this.Listar_ca_pr(Txt_buscar3.Text);
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ca.Visible = false;
        }

        private void Dgv_categorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SeleccionarItem_ca_pr();
            this.Pnl_Listado_ca.Visible = false;
            this.Txt_buscar3.Text = string.Empty;
        }

        private void Btn_lupa3_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ca.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ca.Visible = true;
        }
    }
}
