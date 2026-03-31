namespace FitManager.Forms
{
    partial class CheckInForm
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
            txtBusca = new TextBox();
            lblMensagem = new Label();
            btnCheckIn = new Button();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(30, 70);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Digite NIF ou ID do Socio";
            txtBusca.Size = new Size(219, 27);
            txtBusca.TabIndex = 0;
            txtBusca.TextChanged += txtBusca_TextChanged;
            // 
            // lblMensagem
            // 
            lblMensagem.AutoSize = true;
            lblMensagem.Location = new Point(30, 187);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(82, 20);
            lblMensagem.TabIndex = 1;
            lblMensagem.Text = "Mensagem";
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(30, 117);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(219, 46);
            btnCheckIn.TabIndex = 2;
            btnCheckIn.Text = "CheckIn";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // CheckInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 450);
            Controls.Add(btnCheckIn);
            Controls.Add(lblMensagem);
            Controls.Add(txtBusca);
            Name = "CheckInForm";
            Text = "CheckInForm";
            Load += CheckInForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBusca;
        private Label lblMensagem;
        private Button btnCheckIn;
    }
}