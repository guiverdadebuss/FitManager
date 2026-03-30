
namespace FitManager.Forms
{
    partial class ListarSociosForm
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
            dgvSocios = new DataGridView();
            txtPesquisa = new TextBox();
            labelPesquisarSocio = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // dgvSocios
            // 
            dgvSocios.Location = new Point(269, 149);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(240, 150);
            dgvSocios.TabIndex = 3;
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(301, 28);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(100, 23);
            txtPesquisa.TabIndex = 1;
            // 
            // labelPesquisarSocio
            // 
            labelPesquisarSocio.AutoSize = true;
            labelPesquisarSocio.Location = new Point(143, 31);
            labelPesquisarSocio.Name = "labelPesquisarSocio";
            labelPesquisarSocio.Size = new Size(142, 15);
            labelPesquisarSocio.TabIndex = 2;
            labelPesquisarSocio.Text = "Pesquisar (Nome ou NIF):";
            labelPesquisarSocio.Click += labelPesquisarSocio_Click;
            // 
            // ListarSociosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelPesquisarSocio);
            Controls.Add(txtPesquisa);
            Controls.Add(dgvSocios);
            Name = "ListarSociosForm";
            Text = "ListarSociosForm";
            Load += ListarSociosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void labelPesquisarSocio_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

        private DataGridView dgvSocios;
        private TextBox txtPesquisa;
        private Label labelPesquisarSocio;
    }
}