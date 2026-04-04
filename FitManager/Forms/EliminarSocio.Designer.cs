namespace FitManager.Forms
{
    partial class EliminarSocio
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
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panelDetalhes = new System.Windows.Forms.Panel();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblNif = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Controlos invisíveis — posicionados no code-behind
            this.txtPesquisa.Location = new System.Drawing.Point(0, 0);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(100, 27);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.Visible = false;

            this.btnPesquisar.Location = new System.Drawing.Point(0, 0);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 30);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Visible = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(0, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 44);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar Sócio";
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.panelDetalhes.Location = new System.Drawing.Point(0, 0);
            this.panelDetalhes.Name = "panelDetalhes";
            this.panelDetalhes.Size = new System.Drawing.Size(100, 100);
            this.panelDetalhes.Visible = false;

            this.lblNome.Name = "lblNome"; this.lblNome.AutoSize = true;
            this.lblNif.Name = "lblNif"; this.lblNif.AutoSize = true;
            this.lblTelefone.Name = "lblTelefone"; this.lblTelefone.AutoSize = true;
            this.lblEstado.Name = "lblEstado"; this.lblEstado.AutoSize = true;
            this.lblData.Name = "lblData"; this.lblData.AutoSize = true;
            this.label1.Name = "label1"; this.label1.Visible = false;

            this.panelDetalhes.Controls.Add(this.lblNome);
            this.panelDetalhes.Controls.Add(this.lblNif);
            this.panelDetalhes.Controls.Add(this.lblTelefone);
            this.panelDetalhes.Controls.Add(this.lblEstado);
            this.panelDetalhes.Controls.Add(this.lblData);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EliminarSocio";
            this.Text = "FitManager — Eliminar Sócio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EliminarSocio_Load);

            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panelDetalhes);
            this.Controls.Add(this.label1);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panelDetalhes;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblNif;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label1;
    }
}