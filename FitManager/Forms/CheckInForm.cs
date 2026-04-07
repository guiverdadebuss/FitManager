using FitManager.Data;
using FitManager.Models;
using FitManager.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class CheckInForm : Form
    {
        private Label lblTitle;
        private Label lblFieldLabel;
        private TextBox txtSocio;
        private Button btnCheckin;
        private readonly string placeholder = "Ex: NIF ou ID do Sócio";

        public CheckInForm()
        {
            InitializeComponent();
            StyleManager.Aplicar(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void InitializeComponent()
        {
            this.Text = "Check-in de Sócio";
            this.Size = new Size(400, 280);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTitle = new Label();
            lblTitle.Text = "Check-in";
            lblTitle.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            lblFieldLabel = new Label();
            lblFieldLabel.Text = "Introduza o NIF ou ID do Sócio:";
            lblFieldLabel.Location = new Point(20, 80);
            lblFieldLabel.AutoSize = true;

            txtSocio = new TextBox();
            txtSocio.Name = "txtSocio";
            txtSocio.Size = new Size(340, 30);
            txtSocio.Location = new Point(20, 105);
            txtSocio.Text = placeholder;
            txtSocio.ForeColor = Color.Gray;
            txtSocio.Enter += TxtSocio_Enter;
            txtSocio.Leave += TxtSocio_Leave;

            btnCheckin = new Button();
            btnCheckin.Name = "btnCheckin";
            btnCheckin.Text = "EFETUAR ENTRADA";
            btnCheckin.Size = new Size(340, 45);
            btnCheckin.Location = new Point(20, 150);
            btnCheckin.Click += BtnCheckin_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblFieldLabel);
            this.Controls.Add(txtSocio);
            this.Controls.Add(btnCheckin);
        }

        private void BtnCheckin_Click(object sender, EventArgs e)
        {
            string input = txtSocio.Text.Trim();

            if (string.IsNullOrEmpty(input) || input == placeholder)
            {
                MessageBox.Show("Por favor, insira o NIF ou ID do sócio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Socio socio = SocioRepository.BuscarSocioPorNifOuId(input);

                if (socio == null)
                {
                    MessageBox.Show("Sócio não encontrado no sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!socio.EstadoAtivo)
                {
                    MessageBox.Show($"ACESSO NEGADO!\n\nO sócio {socio.Nome} está com a subscrição inativa.", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                RegistarEntrada(socio.Id);

                MessageBox.Show($"BEM-VINDO!\n\nCheck-in efetuado com sucesso para:\n{socio.Nome}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSocio.Text = placeholder;
                txtSocio.ForeColor = Color.Gray;
                this.ActiveControl = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar check-in: " + ex.Message, "Erro Técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistarEntrada(int socioId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "INSERT INTO RegistoEntrada (SocioId, DataHora) VALUES (@SocioId, GETDATE())";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SocioId", socioId);
            cmd.ExecuteNonQuery();
        }

        private void TxtSocio_Enter(object sender, EventArgs e)
        {
            if (txtSocio.Text == placeholder)
            {
                txtSocio.Text = "";
                txtSocio.ForeColor = Color.Black;
            }
        }

        private void TxtSocio_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSocio.Text))
            {
                txtSocio.Text = placeholder;
                txtSocio.ForeColor = Color.Gray;
            }
        }
    }
}