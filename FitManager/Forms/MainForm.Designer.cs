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
            SuspendLayout();
            // 
            // lblUsuarioLogado
            // 
            lblUsuarioLogado.AutoSize = true;
            lblUsuarioLogado.Location = new Point(122, 132);
            lblUsuarioLogado.Name = "lblUsuarioLogado";
            lblUsuarioLogado.Size = new Size(0, 20);
            lblUsuarioLogado.TabIndex = 0;
            // 
            // btnSocios
            // 
            btnSocios.Location = new Point(12, 213);
            btnSocios.Name = "btnSocios";
            btnSocios.Size = new Size(190, 71);
            btnSocios.TabIndex = 1;
            btnSocios.Text = "Sócios";
            btnSocios.UseVisualStyleBackColor = true;
            btnSocios.Click += btnSocios_Click;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(12, 367);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(190, 71);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "Check-In";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnPlanos
            // 
            btnPlanos.Location = new Point(12, 290);
            btnPlanos.Name = "btnPlanos";
            btnPlanos.Size = new Size(190, 71);
            btnPlanos.TabIndex = 3;
            btnPlanos.Text = "Planos Subscrição";
            btnPlanos.UseVisualStyleBackColor = true;
            btnPlanos.Click += btnPlanos_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}