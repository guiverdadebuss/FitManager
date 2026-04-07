namespace FitManager.Forms
{
    partial class NovoSocio
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
            txtNome = new TextBox();
            txtNif = new TextBox();
            txtTelefone = new TextBox();
            cboPlano = new ComboBox();
            btnGravar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(149, 34);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(261, 27);
            txtNome.TabIndex = 0;
            // 
            // txtNif
            // 
            txtNif.Location = new Point(149, 82);
            txtNif.Name = "txtNif";
            txtNif.Size = new Size(261, 27);
            txtNif.TabIndex = 1;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(149, 134);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(261, 27);
            txtTelefone.TabIndex = 2;
            // 
            // cboPlano
            // 
            cboPlano.FormattingEnabled = true;
            cboPlano.Location = new Point(149, 184);
            cboPlano.Name = "cboPlano";
            cboPlano.Size = new Size(261, 28);
            cboPlano.TabIndex = 3;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(149, 235);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(261, 39);
            btnGravar.TabIndex = 4;
            btnGravar.Text = "Criar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 37);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 5;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 89);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 6;
            label2.Text = "Nif:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 137);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 7;
            label3.Text = "Telefone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 187);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 8;
            label4.Text = "Plano:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(12, 399);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(183, 39);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // NovoSocio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 450);
            Controls.Add(btnCancelar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGravar);
            Controls.Add(cboPlano);
            Controls.Add(txtTelefone);
            Controls.Add(txtNif);
            Controls.Add(txtNome);
            Name = "NovoSocio";
            Text = "NovoSocio";
            Load += NovoSocio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtNif;
        private TextBox txtTelefone;
        private ComboBox cboPlano;
        private Button btnGravar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCancelar;
    }
}