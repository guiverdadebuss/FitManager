using FitManager.Data;
using FitManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
        private readonly string placeholder = "Ex: 123456789";
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

            // Card central
            panelCard = new Panel();
            panelCard.Size = new Size(340, 300);
            panelCard.Location = new Point(
                (this.ClientSize.Width - 340) / 2,
                (this.ClientSize.Height - 300) / 2
            );
            panelCard.BackColor = Color.White;
            panelCard.Paint += PanelCard_Paint;

            // Header (ícone + título)
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

            // Label do campo
            lblFieldLabel = new Label();
            lblFieldLabel.Text = "NIF ou ID do Sócio";
            lblFieldLabel.Font = new Font("Segoe UI", 8.5f);
            lblFieldLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblFieldLabel.Location = new Point(20, 88);
            lblFieldLabel.AutoSize = true;

            // TextBox
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

            // Botão
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

            // Painel de mensagem
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

            // Montar tudo
            panelCard.Controls.Add(panelHeader);
            panelCard.Controls.Add(lblFieldLabel);
            panelCard.Controls.Add(txtSocio);
            panelCard.Controls.Add(btnCheckin);
            panelCard.Controls.Add(panelMsg);
            this.Controls.Add(panelCard);
        }

        // Borda arredondada no card
        private void PanelCard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panelCard.Width - 1, panelCard.Height - 1);
            using var path = RoundedRect(rect, 12);
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1f);
            g.DrawPath(pen, path);
        }

        // Ícone de utilizador no header
        private void PanelIcon_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panelIcon.Width - 1, panelIcon.Height - 1);
            using var path = RoundedRect(rect, 19);
            using var brush = new SolidBrush(Color.FromArgb(219, 234, 254));
            g.FillPath(brush, path);
            using var pen = new Pen(Color.FromArgb(37, 99, 235), 1.5f);
            // Cabeça
            g.DrawEllipse(pen, 12, 5, 14, 14);
            // Corpo
            g.DrawArc(pen, 5, 22, 28, 14, 180, 180);
        }

        // Borda arredondada no painel de mensagem
        private void PanelMsg_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panelMsg.Width - 1, panelMsg.Height - 1);
            using var path = RoundedRect(rect, 8);
            using var brush = new SolidBrush(panelMsg.BackColor);
            g.FillPath(brush, path);
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

        private void BtnCheckin_Click(object sender, EventArgs e)
        {
            string input = txtSocio.Text.Trim();

            if (string.IsNullOrEmpty(input) || input == placeholder)
            {
                MostrarMensagem("Por favor insere o NIF ou ID do sócio.", sucesso: false);
                return;
            }

            // Aqui chamas a tua lógica de negócio
            // bool ok = SocioService.FazerCheckIn(input);
            // if (ok) ...

            MostrarMensagem($"Check-in realizado com sucesso!", sucesso: true);
            txtSocio.Text = placeholder;
            txtSocio.ForeColor = Color.FromArgb(156, 163, 175);
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