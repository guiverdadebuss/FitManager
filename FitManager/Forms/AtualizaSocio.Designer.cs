namespace FitManager.Forms
{
    partial class AtualizaSocio
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
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            txtPlanoId = new TextBox();
            txtTelefone = new TextBox();
            txtNome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            txtInputNif = new TextBox();
            btnPesquisar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPlanoId);
            groupBox1.Controls.Add(txtTelefone);
            groupBox1.Controls.Add(txtNome);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(27, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(395, 213);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 158);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 15;
            label4.Text = "Plano ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 101);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 14;
            label3.Text = "Telefone";
            // 
            // txtPlanoId
            // 
            txtPlanoId.Location = new Point(82, 150);
            txtPlanoId.Margin = new Padding(3, 2, 3, 2);
            txtPlanoId.Name = "txtPlanoId";
            txtPlanoId.Size = new Size(280, 23);
            txtPlanoId.TabIndex = 12;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(82, 98);
            txtTelefone.Margin = new Padding(3, 2, 3, 2);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(280, 23);
            txtTelefone.TabIndex = 11;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(82, 52);
            txtNome.Margin = new Padding(3, 2, 3, 2);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(280, 23);
            txtNome.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 55);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 8;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 34);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "NIF:";
            // 
            // button2
            // 
            button2.Location = new Point(347, 310);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Alterar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtInputNif
            // 
            txtInputNif.Location = new Point(69, 31);
            txtInputNif.Name = "txtInputNif";
            txtInputNif.Size = new Size(217, 23);
            txtInputNif.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(347, 30);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 5;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // AtualizaSocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 345);
            Controls.Add(btnPesquisar);
            Controls.Add(txtInputNif);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Name = "AtualizaSocio";
            Text = "AtualizaSocio";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private TextBox txtPlanoId;
        private TextBox txtTelefone;
        private TextBox txtNome;
        private Label label1;
        private Label label2;
        private Button button2;
        private TextBox txtInputNif;
        private Button btnPesquisar;
    }
}