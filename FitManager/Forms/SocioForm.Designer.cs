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
            btnCriarSocio.Location = new Point(51, 38);
            btnCriarSocio.Margin = new Padding(3, 2, 3, 2);
            btnCriarSocio.Name = "btnCriarSocio";
            btnCriarSocio.Size = new Size(157, 44);
            btnCriarSocio.TabIndex = 0;
            btnCriarSocio.Text = "Criar Socio";
            btnCriarSocio.UseVisualStyleBackColor = true;
            // 
            // btnEditarSocio
            // 
            btnEditarSocio.Location = new Point(256, 38);
            btnEditarSocio.Margin = new Padding(3, 2, 3, 2);
            btnEditarSocio.Name = "btnEditarSocio";
            btnEditarSocio.Size = new Size(157, 44);
            btnEditarSocio.TabIndex = 1;
            btnEditarSocio.Text = "Editar Socio";
            btnEditarSocio.UseVisualStyleBackColor = true;
            // 
            // btnDetalhes
            // 
            btnDetalhes.Location = new Point(478, 38);
            btnDetalhes.Margin = new Padding(3, 2, 3, 2);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Size = new Size(157, 44);
            btnDetalhes.TabIndex = 2;
            btnDetalhes.Text = "Detalhes Socios";
            btnDetalhes.UseVisualStyleBackColor = true;
            btnDetalhes.Click += btnDetalhes_Click;
            // 
            // btnApagarSocio
            // 
            btnApagarSocio.Location = new Point(703, 38);
            btnApagarSocio.Margin = new Padding(3, 2, 3, 2);
            btnApagarSocio.Name = "btnApagarSocio";
            btnApagarSocio.Size = new Size(157, 44);
            btnApagarSocio.TabIndex = 3;
            btnApagarSocio.Text = "Deletar Socio";
            btnApagarSocio.UseVisualStyleBackColor = true;
            btnApagarSocio.Click += btnApagarSocio_Click;
            // 
            // SocioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 338);
            Controls.Add(btnApagarSocio);
            Controls.Add(btnDetalhes);
            Controls.Add(btnEditarSocio);
            Controls.Add(btnCriarSocio);
            Margin = new Padding(3, 2, 3, 2);
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