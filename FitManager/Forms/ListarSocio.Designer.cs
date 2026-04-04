namespace FitManager.Forms
{
    partial class ListarSocio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtBusca      = new System.Windows.Forms.TextBox();
            this.btnBusca      = new System.Windows.Forms.Button();
            this.dgvSocios     = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblId         = new System.Windows.Forms.Label();
            this.lblNome       = new System.Windows.Forms.Label();
            this.lblNif        = new System.Windows.Forms.Label();
            this.lblTelefone   = new System.Windows.Forms.Label();
            this.lblDataInsc   = new System.Windows.Forms.Label();
            this.lblPlano      = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtBusca.Location  = new System.Drawing.Point(0, 0);
            this.txtBusca.Name      = "txtBusca";
            this.txtBusca.Size      = new System.Drawing.Size(100, 27);
            this.txtBusca.TabIndex  = 0;
            this.txtBusca.Visible   = false;

            this.btnBusca.Location = new System.Drawing.Point(0, 0);
            this.btnBusca.Name     = "btnBusca";
            this.btnBusca.Size     = new System.Drawing.Size(80, 30);
            this.btnBusca.TabIndex = 1;
            this.btnBusca.Text     = "Pesquisar";
            this.btnBusca.Visible  = false;
            this.btnBusca.Click   += new System.EventHandler(this.btnBusca_Click);

            this.dgvSocios.Location = new System.Drawing.Point(0, 0);
            this.dgvSocios.Name     = "dgvSocios";
            this.dgvSocios.Size     = new System.Drawing.Size(100, 100);
            this.dgvSocios.Visible  = false;
            this.dgvSocios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSocios_CellContentClick);

            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name     = "dataGridView1";
            this.dataGridView1.Size     = new System.Drawing.Size(100, 100);
            this.dataGridView1.Visible  = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            this.lblId.Name       = "lblId";       this.lblId.Visible       = false;
            this.lblNome.Name     = "lblNome";     this.lblNome.Visible     = false;
            this.lblNif.Name      = "lblNif";      this.lblNif.Visible      = false;
            this.lblTelefone.Name = "lblTelefone"; this.lblTelefone.Visible = false;
            this.lblDataInsc.Name = "lblDataInsc"; this.lblDataInsc.Visible = false;
            this.lblPlano.Name    = "lblPlano";    this.lblPlano.Visible    = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(900, 620);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "ListarSocio";
            this.Text                = "FitManager — Sócios";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load               += new System.EventHandler(this.ListarSocio_Load);

            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.dgvSocios);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblNif);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.lblDataInsc);
            this.Controls.Add(this.lblPlano);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox           txtBusca;
        private System.Windows.Forms.Button            btnBusca;
        private System.Windows.Forms.DataGridView      dgvSocios;
        private System.Windows.Forms.DataGridView      dataGridView1;
        private System.Windows.Forms.Label             lblId;
        private System.Windows.Forms.Label             lblNome;
        private System.Windows.Forms.Label             lblNif;
        private System.Windows.Forms.Label             lblTelefone;
        private System.Windows.Forms.Label             lblDataInsc;
        private System.Windows.Forms.Label             lblPlano;
    }
}
