namespace Minimarket_Presentacion.Reportes
{
    partial class Frm_Rpt_Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Minimarket = new Minimarket_Presentacion.Reportes.DataSet_Minimarket();
            this.dataSetMinimarketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSPListadoprBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_prTableAdapter = new Minimarket_Presentacion.Reportes.DataSet_MinimarketTableAdapters.USP_Listado_prTableAdapter();
            this.uSPListadoprBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Minimarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMinimarketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadoprBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadoprBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(11, 39);
            this.txt_p1.Margin = new System.Windows.Forms.Padding(2);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(76, 20);
            this.txt_p1.TabIndex = 6;
            this.txt_p1.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPListadoprBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Minimarket_Presentacion.Reportes.Rpt_Productos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 5;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dataSet_Minimarket
            // 
            this.dataSet_Minimarket.DataSetName = "DataSet_Minimarket";
            this.dataSet_Minimarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetMinimarketBindingSource
            // 
            this.dataSetMinimarketBindingSource.DataSource = this.dataSet_Minimarket;
            this.dataSetMinimarketBindingSource.Position = 0;
            // 
            // uSPListadoprBindingSource
            // 
            this.uSPListadoprBindingSource.DataMember = "USP_Listado_pr";
            this.uSPListadoprBindingSource.DataSource = this.dataSetMinimarketBindingSource;
            // 
            // uSP_Listado_prTableAdapter
            // 
            this.uSP_Listado_prTableAdapter.ClearBeforeFill = true;
            // 
            // uSPListadoprBindingSource1
            // 
            this.uSPListadoprBindingSource1.DataMember = "USP_Listado_pr";
            this.uSPListadoprBindingSource1.DataSource = this.dataSet_Minimarket;
            // 
            // Frm_Rpt_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_p1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Rpt_Productos";
            this.Text = "Frm_Rpt_Productos";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Minimarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMinimarketBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadoprBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadoprBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txt_p1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPListadoprBindingSource;
        private System.Windows.Forms.BindingSource dataSetMinimarketBindingSource;
        private DataSet_Minimarket dataSet_Minimarket;
        private DataSet_MinimarketTableAdapters.USP_Listado_prTableAdapter uSP_Listado_prTableAdapter;
        private System.Windows.Forms.BindingSource uSPListadoprBindingSource1;
    }
}