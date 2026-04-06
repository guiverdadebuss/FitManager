namespace FitManager.Forms
{
    partial class SocioForm
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
            this.btnCriarSocio    = new System.Windows.Forms.Button();
            this.btnEditarSocio   = new System.Windows.Forms.Button();
            this.btnDetalhes      = new System.Windows.Forms.Button();
            this.btnApagarSocio   = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.btnCriarSocio.Name    = "btnCriarSocio";
            this.btnCriarSocio.Text    = "Criar Socio";
            this.btnCriarSocio.Visible = false;

            this.btnEditarSocio.Name    = "btnEditarSocio";
            this.btnEditarSocio.Text    = "Editar Socio";
            this.btnEditarSocio.Visible = false;

            this.btnDetalhes.Name    = "btnDetalhes";
            this.btnDetalhes.Text    = "Detalhes Socios";
            this.btnDetalhes.Visible = false;
            this.btnDetalhes.Click  += new System.EventHandler(this.btnDetalhes_Click);

            this.btnApagarSocio.Name    = "btnApagarSocio";
            this.btnApagarSocio.Text    = "Deletar Socio";
            this.btnApagarSocio.Visible = false;
            this.btnApagarSocio.Click  += new System.EventHandler(this.btnApagarSocio_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(900, 500);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "SocioForm";
            this.Text                = "FitManager — Sócios";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.btnCriarSocio);
            this.Controls.Add(this.btnEditarSocio);
            this.Controls.Add(this.btnDetalhes);
            this.Controls.Add(this.btnApagarSocio);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnCriarSocio;
        private System.Windows.Forms.Button btnEditarSocio;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.Button btnApagarSocio;
    }
}
