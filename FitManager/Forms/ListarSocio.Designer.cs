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
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(388, 226);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalhes";
            // 
            // btnBusca
            // 
            btnBusca.Location = new Point(258, 35);
            btnBusca.Margin = new Padding(3, 2, 3, 2);
            btnBusca.Name = "btnBusca";
            btnBusca.Size = new Size(114, 25);
            btnBusca.TabIndex = 13;
            btnBusca.Text = "Procurar";
            btnBusca.UseVisualStyleBackColor = true;
            btnBusca.Click += btnBusca_Click;
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(24, 35);
            txtBusca.Margin = new Padding(3, 2, 3, 2);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Digite o NIF ou ID:";
            txtBusca.Size = new Size(148, 23);
            txtBusca.TabIndex = 12;
            // 
            // lblPlano
            // 
            lblPlano.AutoSize = true;
            lblPlano.Location = new Point(125, 192);
            lblPlano.Name = "lblPlano";
            lblPlano.Size = new Size(22, 15);
            lblPlano.TabIndex = 11;
            lblPlano.Text = "---";
            // 
            // lblDataInsc
            // 
            lblDataInsc.AutoSize = true;
            lblDataInsc.Location = new Point(125, 166);
            lblDataInsc.Name = "lblDataInsc";
            lblDataInsc.Size = new Size(22, 15);
            lblDataInsc.TabIndex = 10;
            lblDataInsc.Text = "---";
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(125, 143);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(22, 15);
            lblTelefone.TabIndex = 9;
            lblTelefone.Text = "---";
            // 
            // lblNif
            // 
            lblNif.AutoSize = true;
            lblNif.Location = new Point(125, 121);
            lblNif.Name = "lblNif";
            lblNif.Size = new Size(22, 15);
            lblNif.TabIndex = 8;
            lblNif.Text = "---";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(125, 94);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(22, 15);
            lblNome.TabIndex = 7;
            lblNome.Text = "---";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 192);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 6;
            label6.Text = "Plano:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 166);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 5;
            label5.Text = "Data Inscrição:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 143);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 4;
            label4.Text = "Telefone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 121);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 3;
            label3.Text = "Nif:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 94);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Nome:";
            // 
            // lbl9
            // 
            lbl9.AutoSize = true;
            lbl9.Location = new Point(24, 68);
            lbl9.Name = "lbl9";
            lbl9.Size = new Size(21, 15);
            lbl9.TabIndex = 1;
            lbl9.Text = "ID:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(125, 68);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 15);
            lblId.TabIndex = 0;
            lblId.Text = "---";
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(10, 240);
            dgvSocios.Margin = new Padding(3, 2, 3, 2);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.RowHeadersWidth = 51;
            dgvSocios.Size = new Size(788, 190);
            dgvSocios.TabIndex = 6;
            dgvSocios.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ListarSocio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 439);
            Controls.Add(dgvSocios);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListarSocio";
            Text = "ListarSocio";
            Load += ListarSocio_Load;
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