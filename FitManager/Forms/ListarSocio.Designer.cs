namespace FitManager.Forms
{
    partial class ListarSocio
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
            btnBusca = new Button();
            txtBusca = new TextBox();
            lblPlano = new Label();
            lblDataInsc = new Label();
            lblTelefone = new Label();
            lblNif = new Label();
            lblNome = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lbl9 = new Label();
            lblId = new Label();
            dgvSocios = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBusca);
            groupBox1.Controls.Add(txtBusca);
            groupBox1.Controls.Add(lblPlano);
            groupBox1.Controls.Add(lblDataInsc);
            groupBox1.Controls.Add(lblTelefone);
            groupBox1.Controls.Add(lblNif);
            groupBox1.Controls.Add(lblNome);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lbl9);
            groupBox1.Controls.Add(lblId);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(444, 302);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalhes";
            // 
            // btnBusca
            // 
            btnBusca.Location = new Point(295, 47);
            btnBusca.Name = "btnBusca";
            btnBusca.Size = new Size(130, 33);
            btnBusca.TabIndex = 13;
            btnBusca.Text = "Procurar";
            btnBusca.UseVisualStyleBackColor = true;
            btnBusca.Click += btnBusca_Click;
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(28, 47);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Digite o NIF ou ID:";
            txtBusca.Size = new Size(169, 27);
            txtBusca.TabIndex = 12;
            // 
            // lblPlano
            // 
            lblPlano.AutoSize = true;
            lblPlano.Location = new Point(143, 256);
            lblPlano.Name = "lblPlano";
            lblPlano.Size = new Size(27, 20);
            lblPlano.TabIndex = 11;
            lblPlano.Text = "---";
            // 
            // lblDataInsc
            // 
            lblDataInsc.AutoSize = true;
            lblDataInsc.Location = new Point(143, 222);
            lblDataInsc.Name = "lblDataInsc";
            lblDataInsc.Size = new Size(27, 20);
            lblDataInsc.TabIndex = 10;
            lblDataInsc.Text = "---";
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(143, 191);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(27, 20);
            lblTelefone.TabIndex = 9;
            lblTelefone.Text = "---";
            // 
            // lblNif
            // 
            lblNif.AutoSize = true;
            lblNif.Location = new Point(143, 161);
            lblNif.Name = "lblNif";
            lblNif.Size = new Size(27, 20);
            lblNif.TabIndex = 8;
            lblNif.Text = "---";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(143, 125);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(27, 20);
            lblNome.TabIndex = 7;
            lblNome.Text = "---";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 256);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 6;
            label6.Text = "Plano:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 222);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 5;
            label5.Text = "Data Inscrição:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 191);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 4;
            label4.Text = "Telefone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 161);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 3;
            label3.Text = "Nif:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 125);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 2;
            label2.Text = "Nome:";
            // 
            // lbl9
            // 
            lbl9.AutoSize = true;
            lbl9.Location = new Point(28, 91);
            lbl9.Name = "lbl9";
            lbl9.Size = new Size(27, 20);
            lbl9.TabIndex = 1;
            lbl9.Text = "ID:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(143, 91);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 20);
            lblId.TabIndex = 0;
            lblId.Text = "---";
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(12, 320);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.RowHeadersWidth = 51;
            dgvSocios.Size = new Size(900, 253);
            dgvSocios.TabIndex = 6;
            dgvSocios.CellContentClick += dgvSocios_CellContentClick;
            // 
            // ListarSocio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 585);
            Controls.Add(dgvSocios);
            Controls.Add(groupBox1);
            Name = "ListarSocio";
            Text = "ListarSocio";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtBusca;
        private Label lblPlano;
        private Label lblDataInsc;
        private Label lblTelefone;
        private Label lblNif;
        private Label lblNome;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lbl9;
        private Label lblId;
        private DataGridView dgvSocios;
        private Button btnBusca;
    }
}