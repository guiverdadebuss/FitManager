namespace FitManager.Forms
{
    partial class SocioForm
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
            btnCriarSocio = new Button();
            btnEditarSocio = new Button();
            btnDetalhes = new Button();
            btnApagarSocio = new Button();
            SuspendLayout();
            // 
            // btnCriarSocio
            // 
            btnCriarSocio.Location = new Point(58, 50);
            btnCriarSocio.Name = "btnCriarSocio";
            btnCriarSocio.Size = new Size(315, 59);
            btnCriarSocio.TabIndex = 0;
            btnCriarSocio.Text = "Criar Socio";
            btnCriarSocio.UseVisualStyleBackColor = true;
            btnCriarSocio.Click += btnCriarSocio_Click;
            // 
            // btnEditarSocio
            // 
            btnEditarSocio.Location = new Point(58, 146);
            btnEditarSocio.Name = "btnEditarSocio";
            btnEditarSocio.Size = new Size(315, 59);
            btnEditarSocio.TabIndex = 1;
            btnEditarSocio.Text = "Editar Socio";
            btnEditarSocio.UseVisualStyleBackColor = true;
            btnEditarSocio.Click += btnEditarSocio_Click;
            // 
            // btnDetalhes
            // 
            btnDetalhes.Location = new Point(58, 246);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Size = new Size(315, 59);
            btnDetalhes.TabIndex = 2;
            btnDetalhes.Text = "Detalhes Socios";
            btnDetalhes.UseVisualStyleBackColor = true;
            btnDetalhes.Click += btnDetalhes_Click;
            // 
            // btnApagarSocio
            // 
            btnApagarSocio.Location = new Point(58, 338);
            btnApagarSocio.Name = "btnApagarSocio";
            btnApagarSocio.Size = new Size(315, 59);
            btnApagarSocio.TabIndex = 3;
            btnApagarSocio.Text = "Deletar Socio";
            btnApagarSocio.UseVisualStyleBackColor = true;
            btnApagarSocio.Click += btnApagarSocio_Click;
            // 
            // SocioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 450);
            Controls.Add(btnApagarSocio);
            Controls.Add(btnDetalhes);
            Controls.Add(btnEditarSocio);
            Controls.Add(btnCriarSocio);
            Name = "SocioForm";
            Text = "SocioForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCriarSocio;
        private Button btnEditarSocio;
        private Button btnDetalhes;
        private Button btnApagarSocio;
    }
}