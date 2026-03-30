namespace FitManager.Forms
{
    partial class AtivarRemoverSocioForm
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
            lblNome = new Label();
            btnDesativar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(346, 25);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(38, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "label1";
            // 
            // btnDesativar
            // 
            btnDesativar.Location = new Point(322, 189);
            btnDesativar.Name = "btnDesativar";
            btnDesativar.Size = new Size(75, 23);
            btnDesativar.TabIndex = 1;
            btnDesativar.Text = "Eliminar";
            btnDesativar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(322, 132);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Desativar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(672, 334);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // AtivarRemoverSocioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnDesativar);
            Controls.Add(lblNome);
            Name = "AtivarRemoverSocioForm";
            Text = "AtivarRemoverSocioForm";
            Load += AtivarRemoverSocioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Button btnDesativar;
        private Button btnEliminar;
        private Button btnCancelar;
    }
}