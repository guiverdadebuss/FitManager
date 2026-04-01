namespace FitManager.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtUsuario  = new System.Windows.Forms.TextBox();
            this.txtSenha    = new System.Windows.Forms.TextBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.btnVerPasse = new System.Windows.Forms.Button();
            this.label1      = new System.Windows.Forms.Label();
            this.label2      = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtUsuario
            this.txtUsuario.Location  = new System.Drawing.Point(0, 0);
            this.txtUsuario.Name      = "txtUsuario";
            this.txtUsuario.Size      = new System.Drawing.Size(100, 27);
            this.txtUsuario.TabIndex  = 0;
            this.txtUsuario.Visible   = false;

            // txtSenha
            this.txtSenha.Location              = new System.Drawing.Point(0, 0);
            this.txtSenha.Name                  = "txtSenha";
            this.txtSenha.Size                  = new System.Drawing.Size(100, 27);
            this.txtSenha.TabIndex              = 1;
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.Visible               = false;
            this.txtSenha.TextChanged          += new System.EventHandler(this.txtSenha_TextChanged);

            // btnVerPasse
            this.btnVerPasse.Location = new System.Drawing.Point(0, 0);
            this.btnVerPasse.Name     = "btnVerPasse";
            this.btnVerPasse.Size     = new System.Drawing.Size(36, 27);
            this.btnVerPasse.TabIndex = 3;
            this.btnVerPasse.Text     = "";
            this.btnVerPasse.Visible  = false;
            this.btnVerPasse.Click   += new System.EventHandler(this.btnVerPasse_Click);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(0, 0);
            this.btnLogin.Name     = "btnLogin";
            this.btnLogin.Size     = new System.Drawing.Size(100, 44);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text     = "▶   Entrar";
            this.btnLogin.Visible  = false;
            this.btnLogin.Click   += new System.EventHandler(this.btnLogin_Click);

            // label1 / label2
            this.label1.Name    = "label1";
            this.label1.Visible = false;
            this.label2.Name    = "label2";
            this.label2.Visible = false;

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(460, 500);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox         = false;
            this.Name                = "LoginForm";
            this.Text                = "FitManager — Iniciar Sessão";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnVerPasse);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button  btnLogin;
        private System.Windows.Forms.Button  btnVerPasse;
        private System.Windows.Forms.Label   label1;
        private System.Windows.Forms.Label   label2;
    }
}
