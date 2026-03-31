using FitManager.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public class CheckInForm : Form
    {
        private Panel panelCard;
        private Panel panelHeader;
        private Panel panelIcon;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblFieldLabel;
        private TextBox txtSocio;
        private Button btnCheckin;
        private Panel panelMsg;
        private Label lblMsg;

        private readonly string placeholder = "Ex: NIF ou ID do Sócio";

        public CheckInForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Check-in";
            this.Size = new Size(480, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(243, 244, 246);
            this.Font = new Font("Segoe UI", 9.5f);

            panelCard = new Panel();
            panelCard.Size = new Size(340, 300);
            panelCard.Location = new Point(
                (this.ClientSize.Width - 340) / 2,
                (this.ClientSize.Height - 300) / 2
            );
            panelCard.BackColor = Color.White;
            panelCard.Paint += PanelCard_Paint;

            panelHeader = new Panel();
            panelHeader.Size = new Size(300, 48);
            panelHeader.Location = new Point(20, 20);
            panelHeader.BackColor = Color.Transparent;

            panelIcon = new Panel();
            panelIcon.Size = new Size(38, 38);
            panelIcon.Location = new Point(0, 5);
            panelIcon.BackColor = Color.FromArgb(219, 234, 254);
            panelIcon.Paint += PanelIcon_Paint;

            lblTitle = new Label();
            lblTitle.Text = "Check-in";
            lblTitle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(50, 4);
            lblTitle.AutoSize = true;

            lblSubtitle = new Label();
            lblSubtitle.Text = "Ginásio FitManager";
            lblSubtitle.Font = new Font("Segoe UI", 8.5f);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(50, 26);
            lblSubtitle.AutoSize = true;

            panelHeader.Controls.Add(panelIcon);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);

            lblFieldLabel = new Label();
            lblFieldLabel.Text = "NIF ou ID do Sócio";
            lblFieldLabel.Font = new Font("Segoe UI", 8.5f);
            lblFieldLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblFieldLabel.Location = new Point(20, 88);
            lblFieldLabel.AutoSize = true;

            txtSocio = new TextBox();
            txtSocio.Size = new Size(300, 36);
            txtSocio.Location = new Point(20, 108);
            txtSocio.Font = new Font("Segoe UI", 10f);
            txtSocio.ForeColor = Color.FromArgb(156, 163, 175);
            txtSocio.Text = placeholder;
            txtSocio.BorderStyle = BorderStyle.FixedSingle;
            txtSocio.BackColor = Color.FromArgb(249, 250, 251);
            txtSocio.Enter += TxtSocio_Enter;
            txtSocio.Leave += TxtSocio_Leave;

            btnCheckin = new Button();
            btnCheckin.Text = "Fazer Check-in";
            btnCheckin.Size = new Size(300, 40);
            btnCheckin.Location = new Point(20, 164);
            btnCheckin.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnCheckin.ForeColor = Color.White;
            btnCheckin.BackColor = Color.FromArgb(37, 99, 235);
            btnCheckin.FlatStyle = FlatStyle.Flat;
            btnCheckin.FlatAppearance.BorderSize = 0;
            btnCheckin.Cursor = Cursors.Hand;
            btnCheckin.Click += BtnCheckin_Click;
            btnCheckin.MouseEnter += (s, e) => btnCheckin.BackColor = Color.FromArgb(29, 78, 216);
            btnCheckin.MouseLeave += (s, e) => btnCheckin.BackColor = Color.FromArgb(37, 99, 235);

            panelMsg = new Panel();
            panelMsg.Size = new Size(300, 36);
            panelMsg.Location = new Point(20, 220);
            panelMsg.Visible = false;
            panelMsg.Paint += PanelMsg_Paint;

            lblMsg = new Label();
            lblMsg.AutoSize = false;
            lblMsg.Dock = DockStyle.Fill;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblMsg.Font = new Font("Segoe UI", 9f);
            panelMsg.Controls.Add(lblMsg);

            panelCard.Controls.Add(panelHeader);
            panelCard.Controls.Add(lblFieldLabel);
            panelCard.Controls.Add(txtSocio);
            panelCard.Controls.Add(btnCheckin);
            panelCard.Controls.Add(panelMsg);
            this.Controls.Add(panelCard);
        }

        private void BtnCheckin_Click(object sender, EventArgs e)
        {
            string input = txtSocio.Text.Trim();

            if (string.IsNullOrEmpty(input) || input == placeholder)
            {
                MostrarMensagem("Por favor insere o NIF ou ID do sócio.", sucesso: false);
                return;
            }

            try
            {
                var resultado = VerificarSocio(input);

                if (resultado == null)
                {
                    MostrarPopup("Sócio não encontrado", "Nenhum sócio corresponde ao NIF ou ID inserido.", sucesso: false);
                    return;
                }

                if (!resultado.Value.estadoAtivo)
                {
                    MostrarPopup("Acesso negado", $"{resultado.Value.nome} não tem a subscrição ativa.", sucesso: false);
                    return;
                }

                // Regista entrada na tabela RegistoEntrada
                RegistarEntrada(resultado.Value.id);

                MostrarPopup("Bem-vindo!", $"{resultado.Value.nome} entrou com sucesso.", sucesso: true);

                txtSocio.Text = placeholder;
                txtSocio.ForeColor = Color.FromArgb(156, 163, 175);
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro: " + ex.Message, sucesso: false);
            }
        }

        private (int id, string nome, bool estadoAtivo)? VerificarSocio(string input)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            // Tenta primeiro por ID numérico, depois por NIF
            bool isNumeric = int.TryParse(input, out int idParsed);

            string query = isNumeric
                ? "SELECT Id, Nome, EstadoAtivo FROM Socio WHERE Id = @Valor"
                : "SELECT Id, Nome, EstadoAtivo FROM Socio WHERE Nif = @Valor";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Valor", isNumeric ? (object)idParsed : input);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return (
                    id: reader.GetInt32(0),
                    nome: reader.GetString(1),
                    estadoAtivo: reader.GetBoolean(2)
                );
            }

            return null;
        }

        private void RegistarEntrada(int socioId)
        {
            using var sqlConnection = DatabaseConnection.GetConnection();
            sqlConnection.Open();

            string query = "INSERT INTO RegistoEntrada (SocioId) VALUES (@SocioId)";
            using var cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@SocioId", socioId);
            cmd.ExecuteNonQuery();
        }

        private void MostrarPopup(string titulo, string mensagem, bool sucesso)
        {
            using var popup = new Form();
            popup.Text = "";
            popup.Size = new Size(360, 200);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.FormBorderStyle = FormBorderStyle.None;
            popup.BackColor = Color.White;

            // Barra colorida no topo
            var barraTop = new Panel();
            barraTop.Dock = DockStyle.Top;
            barraTop.Height = 6;
            barraTop.BackColor = sucesso
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(220, 38, 38);
            popup.Controls.Add(barraTop);

            // Círculo com ícone
            var painelIcone = new Panel();
            painelIcone.Size = new Size(52, 52);
            painelIcone.Location = new Point((360 - 52) / 2, 24);
            painelIcone.BackColor = sucesso
                ? Color.FromArgb(220, 252, 231)
                : Color.FromArgb(254, 226, 226);
            painelIcone.Paint += (s, ev) =>
            {
                var g = ev.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(painelIcone.BackColor);
                g.FillEllipse(brush, 0, 0, 51, 51);
                using var pen = new Pen(
                    sucesso ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38), 2.5f);
                if (sucesso)
                {
                    // Visto
                    g.DrawLines(pen, new Point[] {
                        new Point(14, 27), new Point(22, 35), new Point(38, 17)
                    });
                }
                else
                {
                    // X
                    g.DrawLine(pen, 16, 16, 36, 36);
                    g.DrawLine(pen, 36, 16, 16, 36);
                }
            };
            popup.Controls.Add(painelIcone);

            var lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitulo.Size = new Size(320, 24);
            lblTitulo.Location = new Point(20, 88);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            popup.Controls.Add(lblTitulo);

            var lblDetalhe = new Label();
            lblDetalhe.Text = mensagem;
            lblDetalhe.Font = new Font("Segoe UI", 9f);
            lblDetalhe.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetalhe.Size = new Size(320, 36);
            lblDetalhe.Location = new Point(20, 116);
            lblDetalhe.TextAlign = ContentAlignment.MiddleCenter;
            popup.Controls.Add(lblDetalhe);

            var btnFechar = new Button();
            btnFechar.Text = "OK";
            btnFechar.Size = new Size(100, 32);
            btnFechar.Location = new Point((360 - 100) / 2, 152);
            btnFechar.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.BackColor = sucesso
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(220, 38, 38);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.Click += (s, ev) => popup.Close();
            popup.Controls.Add(btnFechar);

            // Fechar ao clicar fora
            popup.Deactivate += (s, ev) => popup.Close();

            popup.ShowDialog(this);
        }

        private void MostrarMensagem(string texto, bool sucesso)
        {
            if (sucesso)
            {
                panelMsg.BackColor = Color.FromArgb(220, 252, 231);
                lblMsg.ForeColor = Color.FromArgb(22, 101, 52);
            }
            else
            {
                panelMsg.BackColor = Color.FromArgb(254, 226, 226);
                lblMsg.ForeColor = Color.FromArgb(153, 27, 27);
            }
            lblMsg.Text = texto;
            panelMsg.Visible = true;
            panelMsg.Invalidate();
        }

        private void TxtSocio_Enter(object sender, EventArgs e)
        {
            if (txtSocio.Text == placeholder)
            {
                txtSocio.Text = "";
                txtSocio.ForeColor = Color.FromArgb(17, 24, 39);
            }
        }

        private void TxtSocio_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSocio.Text))
            {
                txtSocio.Text = placeholder;
                txtSocio.ForeColor = Color.FromArgb(156, 163, 175);
            }
        }

        private void PanelCard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panelCard.Width - 1, panelCard.Height - 1);
            using var path = RoundedRect(rect, 12);
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1f);
            g.DrawPath(pen, path);
        }

        private void PanelIcon_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panelIcon.Width - 1, panelIcon.Height - 1);
            using var path = RoundedRect(rect, 19);
            using var brush = new SolidBrush(Color.FromArgb(219, 234, 254));
            g.FillPath(brush, path);
            using var pen = new Pen(Color.FromArgb(37, 99, 235), 1.5f);
            g.DrawEllipse(pen, 12, 5, 14, 14);
            g.DrawArc(pen, 5, 22, 28, 14, 180, 180);
        }

        private void PanelMsg_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panelMsg.Width - 1, panelMsg.Height - 1);
            using var path = RoundedRect(rect, 8);
            using var brush = new SolidBrush(panelMsg.BackColor);
            g.FillPath(brush, path);
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(bounds.Left, bounds.Top, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Top, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

