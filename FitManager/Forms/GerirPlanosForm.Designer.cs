namespace FitManager.Forms
{
    partial class GerirPlanosForm
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
            dgvPlanos = new DataGridView();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDescricao = new TextBox();
            btnGravar = new Button();
            txtPreco = new TextBox();
            txtNome = new TextBox();
            btnNovo = new Button();
            btnRemover = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPlanos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPlanos
            // 
            dgvPlanos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanos.Location = new Point(12, 51);
            dgvPlanos.Name = "dgvPlanos";
            dgvPlanos.RowHeadersWidth = 80;
            dgvPlanos.Size = new Size(911, 232);
            dgvPlanos.TabIndex = 0;
            dgvPlanos.CellClick += dgvPlanos_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRemover);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDescricao);
            groupBox1.Controls.Add(btnGravar);
            groupBox1.Controls.Add(txtPreco);
            groupBox1.Controls.Add(txtNome);
            groupBox1.Controls.Add(btnNovo);
            groupBox1.Location = new Point(12, 289);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(911, 232);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalhes do Plano:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 127);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 7;
            label3.Text = "Descrição:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 84);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 6;
            label2.Text = "Preço:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 41);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 5;
            label1.Text = "Nome:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(124, 124);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(317, 27);
            txtDescricao.TabIndex = 2;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(124, 171);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(153, 37);
            btnGravar.TabIndex = 4;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(124, 81);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(317, 27);
            txtPreco.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(124, 38);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(317, 27);
            txtNome.TabIndex = 0;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(283, 171);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(158, 37);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "Limpar Campos";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(447, 171);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(153, 37);
            btnRemover.TabIndex = 8;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // GerirPlanosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 536);
            Controls.Add(groupBox1);
            Controls.Add(dgvPlanos);
            Name = "GerirPlanosForm";
            Text = "PlanoAdd";
            Load += GerirPlanosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlanos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPlanos;
        private GroupBox groupBox1;
        private TextBox txtDescricao;
        private TextBox txtPreco;
        private TextBox txtNome;
        private Button btnNovo;
        private Button button2;
        private Button btnGravar;
        private Button button4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnRemover;
    }
}