namespace FitManager.Forms
{
    partial class CriarNovoSocio
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
            label1 = new Label();
            txtNome = new TextBox();
            txtNif = new TextBox();
            txtTelefone = new TextBox();
            txtPlanoId = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 70);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(118, 68);
            txtNome.Margin = new Padding(3, 2, 3, 2);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(280, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += txtNome_TextChanged;
            // 
            // txtNif
            // 
            txtNif.Location = new Point(118, 119);
            txtNif.Margin = new Padding(3, 2, 3, 2);
            txtNif.Name = "txtNif";
            txtNif.Size = new Size(280, 23);
            txtNif.TabIndex = 2;
            txtNif.TextChanged += txtNif_TextChanged;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(118, 170);
            txtTelefone.Margin = new Padding(3, 2, 3, 2);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(280, 23);
            txtTelefone.TabIndex = 3;
            txtTelefone.TextChanged += txtTelefone_TextChanged;
            // 
            // txtPlanoId
            // 
            txtPlanoId.Location = new Point(118, 220);
            txtPlanoId.Margin = new Padding(3, 2, 3, 2);
            txtPlanoId.Name = "txtPlanoId";
            txtPlanoId.Size = new Size(280, 23);
            txtPlanoId.TabIndex = 4;
            txtPlanoId.TextChanged += txtPlanoId_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 124);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 5;
            label2.Text = "NIF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 176);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 6;
            label3.Text = "Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 225);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 7;
            label4.Text = "Plano ID";
            // 
            // button1
            // 
            button1.Location = new Point(562, 306);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Criar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CriarNovoSocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 476);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPlanoId);
            Controls.Add(txtTelefone);
            Controls.Add(txtNif);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CriarNovoSocio";
            Text = "CriarNovoSocio";
            Load += CriarNovoSocio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private TextBox txtNif;
        private TextBox txtTelefone;
        private TextBox txtPlanoId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}