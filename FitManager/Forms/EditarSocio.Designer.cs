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
            chkAtivo = new CheckBox();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(176, 43);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(217, 27);
            txtBusca.TabIndex = 0;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(176, 98);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(217, 27);
            txtNome.TabIndex = 1;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(176, 150);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(217, 27);
            txtTelefone.TabIndex = 2;
            // 
            // txtPlanoId
            // 
            txtPlanoId.Location = new Point(176, 207);
            txtPlanoId.Name = "txtPlanoId";
            txtPlanoId.Size = new Size(217, 27);
            txtPlanoId.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 46);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 4;
            label1.Text = "Digite Nif ou ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 101);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 5;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 153);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 6;
            label3.Text = "Telefone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 210);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 7;
            label4.Text = "Plano:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(412, 35);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(183, 42);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(411, 83);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(183, 42);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(412, 552);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(183, 39);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // chkAtivo
            // 
            chkAtivo.AutoSize = true;
            chkAtivo.Location = new Point(53, 260);
            chkAtivo.Name = "chkAtivo";
            chkAtivo.Size = new Size(107, 24);
            chkAtivo.TabIndex = 11;
            chkAtivo.Text = "Socio Ativo";
            chkAtivo.UseVisualStyleBackColor = true;
            // 
            // EditarSocio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 603);
            Controls.Add(chkAtivo);
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
            Text = "FitManager - Editar Socio";
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
        private CheckBox chkAtivo;
    }
}