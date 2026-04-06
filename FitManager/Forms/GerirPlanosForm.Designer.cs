namespace FitManager.Forms
{
    partial class GerirPlanosForm
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
            this.dgvPlanos = new System.Windows.Forms.DataGridView();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.dgvPlanos.Name = "dgvPlanos";
            this.dgvPlanos.Visible = false;
            this.dgvPlanos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanos_CellClick);

            this.txtNome.Name = "txtNome";
            this.txtNome.Visible = false;

            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Visible = false;

            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Visible = false;

            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Text = "Gravar";
            this.btnGravar.Visible = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);

            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Text = "Limpar Campos";
            this.btnNovo.Visible = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Text = "Remover";
            this.btnRemover.Visible = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GerirPlanosForm";
            this.Text = "FitManager — Planos de Subscrição";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GerirPlanosForm_Load);

            this.Controls.Add(this.dgvPlanos);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnRemover);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanos;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnRemover;
    }
}