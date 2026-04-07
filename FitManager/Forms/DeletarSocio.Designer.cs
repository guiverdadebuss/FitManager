namespace FitManager.Forms
{
    partial class DeletarSocio
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
            btnBuscar = new Button();
            label1 = new Label();
            txtBusca = new TextBox();
            lblNomeSocio = new Label();
            lblStatus = new Label();
            btnEliminar = new Button();
            label2 = new Label();
            label3 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(412, 50);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(183, 39);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 59);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 10;
            label1.Text = "Digite Nif ou ID:";
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(180, 56);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(217, 27);
            txtBusca.TabIndex = 9;
            // 
            // lblNomeSocio
            // 
            lblNomeSocio.AutoSize = true;
            lblNomeSocio.Location = new Point(180, 104);
            lblNomeSocio.Name = "lblNomeSocio";
            lblNomeSocio.Size = new Size(27, 20);
            lblNomeSocio.TabIndex = 12;
            lblNomeSocio.Text = "---";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(180, 154);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(27, 20);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "---";
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(412, 95);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(183, 39);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Apagar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 104);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 15;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 154);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 16;
            label3.Text = "Status:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(412, 552);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(183, 39);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // DeletarSocio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 603);
            Controls.Add(btnCancelar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnEliminar);
            Controls.Add(lblStatus);
            Controls.Add(lblNomeSocio);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(txtBusca);
            Name = "DeletarSocio";
            Text = "FitManager - Apagar Socio";
            Load += btnEliminar_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private Label label1;
        private TextBox txtBusca;
        private Label lblNomeSocio;
        private Label lblStatus;
        private Button btnEliminar;
        private Label label2;
        private Label label3;
        private Button btnCancelar;
    }
}