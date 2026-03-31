namespace FitManager.Forms
{
    partial class MainForm
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
            lblUsuarioLogado = new Label();
            btnSocios = new Button();
            btnCheckIn = new Button();
            btnPlanos = new Button();
            lblTotalSocios = new Label();
            label1 = new Label();
            label2 = new Label();
            lblTotalEntradas = new Label();
            SuspendLayout();
            // 
            // lblUsuarioLogado
            // 
            lblUsuarioLogado.AutoSize = true;
            lblUsuarioLogado.Location = new Point(12, 20);
            lblUsuarioLogado.Name = "lblUsuarioLogado";
            lblUsuarioLogado.Size = new Size(0, 20);
            lblUsuarioLogado.TabIndex = 0;
            // 
            // btnSocios
            // 
            btnSocios.Location = new Point(12, 119);
            btnSocios.Name = "btnSocios";
            btnSocios.Size = new Size(190, 71);
            btnSocios.TabIndex = 1;
            btnSocios.Text = "Sócios";
            btnSocios.UseVisualStyleBackColor = true;
            btnSocios.Click += btnSocios_Click;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(12, 273);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(190, 71);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "Check-In";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnPlanos
            // 
            btnPlanos.Location = new Point(12, 196);
            btnPlanos.Name = "btnPlanos";
            btnPlanos.Size = new Size(190, 71);
            btnPlanos.TabIndex = 3;
            btnPlanos.Text = "Planos Subscrição";
            btnPlanos.UseVisualStyleBackColor = true;
            btnPlanos.Click += btnPlanos_Click;
            // 
            // lblTotalSocios
            // 
            lblTotalSocios.AutoSize = true;
            lblTotalSocios.Location = new Point(358, 36);
            lblTotalSocios.Name = "lblTotalSocios";
            lblTotalSocios.Size = new Size(27, 20);
            lblTotalSocios.TabIndex = 4;
            lblTotalSocios.Text = "---";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(252, 36);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 5;
            label1.Text = "Socios Ativos:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(474, 36);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 6;
            label2.Text = "CheckIns: ";
            // 
            // lblTotalEntradas
            // 
            lblTotalEntradas.AutoSize = true;
            lblTotalEntradas.Location = new Point(553, 36);
            lblTotalEntradas.Name = "lblTotalEntradas";
            lblTotalEntradas.Size = new Size(27, 20);
            lblTotalEntradas.TabIndex = 7;
            lblTotalEntradas.Text = "---";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 356);
            Controls.Add(lblTotalEntradas);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTotalSocios);
            Controls.Add(btnPlanos);
            Controls.Add(btnCheckIn);
            Controls.Add(btnSocios);
            Controls.Add(lblUsuarioLogado);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuarioLogado;
        private Button btnSocios;
        private Button btnCheckIn;
        private Button btnPlanos;
        private Label lblTotalSocios;
        private Label label1;
        private Label label2;
        private Label lblTotalEntradas;
    }
}