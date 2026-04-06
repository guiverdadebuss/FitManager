namespace FitManager.Forms
{
    partial class MainForm
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
            this.lblUsuarioLogado  = new System.Windows.Forms.Label();
            this.lblTotalSocios    = new System.Windows.Forms.Label();
            this.lblTotalEntradas  = new System.Windows.Forms.Label();
            this.btnSocios         = new System.Windows.Forms.Button();
            this.btnPlanos         = new System.Windows.Forms.Button();
            this.btnCheckIn        = new System.Windows.Forms.Button();
            this.dgvAcessos        = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();

            this.lblUsuarioLogado.Name    = "lblUsuarioLogado";
            this.lblUsuarioLogado.Text    = "";
            this.lblUsuarioLogado.Visible = false;

            this.lblTotalSocios.Name    = "lblTotalSocios";
            this.lblTotalSocios.Text    = "---";
            this.lblTotalSocios.Visible = false;

            this.lblTotalEntradas.Name    = "lblTotalEntradas";
            this.lblTotalEntradas.Text    = "---";
            this.lblTotalEntradas.Visible = false;

            this.btnSocios.Name     = "btnSocios";
            this.btnSocios.Text     = "Sócios";
            this.btnSocios.Visible  = false;
            this.btnSocios.Click   += new System.EventHandler(this.btnSocios_Click);

            this.btnPlanos.Name     = "btnPlanos";
            this.btnPlanos.Text     = "Planos Subscrição";
            this.btnPlanos.Visible  = false;
            this.btnPlanos.Click   += new System.EventHandler(this.btnPlanos_Click);

            this.btnCheckIn.Name    = "btnCheckIn";
            this.btnCheckIn.Text    = "Check-In";
            this.btnCheckIn.Visible = false;
            this.btnCheckIn.Click  += new System.EventHandler(this.btnCheckIn_Click);

            this.dgvAcessos.Name    = "dgvAcessos";
            this.dgvAcessos.Visible = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1100, 680);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "MainForm";
            this.Text                = "FitManager";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load               += new System.EventHandler(this.MainForm_Load);

            this.Controls.Add(this.lblUsuarioLogado);
            this.Controls.Add(this.lblTotalSocios);
            this.Controls.Add(this.lblTotalEntradas);
            this.Controls.Add(this.btnSocios);
            this.Controls.Add(this.btnPlanos);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.dgvAcessos);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label         lblUsuarioLogado;
        private System.Windows.Forms.Label         lblTotalSocios;
        private System.Windows.Forms.Label         lblTotalEntradas;
        private System.Windows.Forms.Button        btnSocios;
        private System.Windows.Forms.Button        btnPlanos;
        private System.Windows.Forms.Button        btnCheckIn;
        private System.Windows.Forms.DataGridView  dgvAcessos;
    }
}
