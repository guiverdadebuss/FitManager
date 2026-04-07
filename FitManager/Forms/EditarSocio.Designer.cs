namespace FitManager.Forms
{
    partial class EditarSocio
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
            txtNome = new TextBox();
            txtTelefone = new TextBox();
            txtPlanoId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnBuscar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(188, 35);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(217, 27);
            txtBusca.TabIndex = 0;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(188, 90);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(217, 27);
            txtNome.TabIndex = 1;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(188, 142);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(217, 27);
            txtTelefone.TabIndex = 2;
            // 
            // txtPlanoId
            // 
            txtPlanoId.Location = new Point(188, 199);
            txtPlanoId.Name = "txtPlanoId";
            txtPlanoId.Size = new Size(217, 27);
            txtPlanoId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 38);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 4;
            label1.Text = "Digite Nif ou ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 93);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 5;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 145);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 6;
            label3.Text = "Telefone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 202);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 7;
            label4.Text = "Plano:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(420, 27);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(95, 42);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(65, 251);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(183, 42);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(65, 321);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(183, 39);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EditarSocio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 372);
            Controls.Add(btnCancelar);
            Controls.Add(btnEditar);
            Controls.Add(btnBuscar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPlanoId);
            Controls.Add(txtTelefone);
            Controls.Add(txtNome);
            Controls.Add(txtBusca);
            Name = "EditarSocio";
            Text = "EditarSocio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBusca;
        private TextBox txtNome;
        private TextBox txtTelefone;
        private TextBox txtPlanoId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnBuscar;
        private Button btnEditar;
        private Button btnCancelar;
    }
}