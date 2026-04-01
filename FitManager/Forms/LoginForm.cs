using FitManager.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class LoginForm : Form
    {
        // ── Paleta ────────────────────────────────────────────────────
        private static readonly Color CorEscura = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorVerde = ColorTranslator.FromHtml("#1A8A42");
        private static readonly Color CorVerdeClaro = ColorTranslator.FromHtml("#2ECC71");
        private static readonly Color CorFundo = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorBorda = ColorTranslator.FromHtml("#C8D8C8");
        private static readonly Color CorLabel = ColorTranslator.FromHtml("#4A7A5A");
        private static readonly Color CorInputFundo = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorTexto = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorSubtexto = ColorTranslator.FromHtml("#6A8870");

        // ── Layout fixo ───────────────────────────────────────────────
        private const int FormW = 460;
        private const int FormH = 500;
        private const int HeaderH = 130;
        private const int CardX = 50;
        private const int CardY = 150;   // logo 130 + 20 margem
        private const int CardW = 360;
        private const int CardH = 220;
        private const int PaddingH = 32;    // padding horizontal dentro do card

        public LoginForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(FormW, FormH);
            this.BackColor = CorFundo;
            this.Font = new Font("Segoe UI", 9.5F);
            ConstruirUI();
        }

        // ─────────────────────────────────────────────────────────────
        private void ConstruirUI()
        {
            // 1. Header ───────────────────────────────────────────────
            var header = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(FormW, HeaderH),
                BackColor = CorEscura
            };

            var picLogo = new Panel
            {
                Size = new Size(52, 52),
                Location = new Point(124, 36),
                BackColor = Color.Transparent
            };
            picLogo.Paint += PicLogo_Paint;

            var lblNome = new Label
            {
                AutoSize = false,
                Size = new Size(230, 36),
                Location = new Point(184, 30),
                BackColor = Color.Transparent
            };
            lblNome.Paint += LblNome_Paint;

            var lblTag = new Label
            {
                Text = "GESTÃO DE GINÁSIO",
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(110, 255, 255, 255),
                AutoSize = false,
                Size = new Size(230, 16),
                Location = new Point(186, 68),
                BackColor = Color.Transparent
            };

            var accent = new Panel
            {
                BackColor = CorVerdeClaro,
                Size = new Size(40, 3),
                Location = new Point(210, 110)
            };

            header.Controls.Add(picLogo);
            header.Controls.Add(lblNome);
            header.Controls.Add(lblTag);
            header.Controls.Add(accent);
            this.Controls.Add(header);

            // 2. Card ─────────────────────────────────────────────────
            var card = new Panel
            {
                Location = new Point(CardX, CardY),
                Size = new Size(CardW, CardH),
                BackColor = Color.White
            };
            card.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, card.Width - 1, card.Height - 1));

            card.Controls.Add(new Label
            {
                Text = "Bem-vindo de volta",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize = false,
                Size = new Size(CardW, 30),
                Location = new Point(0, 14),
                TextAlign = ContentAlignment.MiddleCenter
            });
            card.Controls.Add(new Label
            {
                Text = "Introduza as suas credenciais para continuar",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize = false,
                Size = new Size(CardW, 18),
                Location = new Point(0, 46),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Label + TextBox Utilizador
            card.Controls.Add(MakeLabel("Utilizador", new Point(PaddingH, 76)));
            this.Controls.Remove(txtUsuario);
            txtUsuario.Location = new Point(PaddingH, 96);
            txtUsuario.Size = new Size(CardW - PaddingH * 2, 28);
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.BackColor = CorInputFundo;
            txtUsuario.ForeColor = CorTexto;
            txtUsuario.Visible = true;
            txtUsuario.Enter += (s, e) => txtUsuario.BackColor = Color.White;
            txtUsuario.Leave += (s, e) => txtUsuario.BackColor = CorInputFundo;
            card.Controls.Add(txtUsuario);

            // Label + TextBox Senha + botão olho
            card.Controls.Add(MakeLabel("Senha", new Point(PaddingH, 142)));
            this.Controls.Remove(txtSenha);
            txtSenha.Location = new Point(PaddingH, 162);
            txtSenha.Size = new Size(CardW - PaddingH * 2 - 42, 28);
            txtSenha.Font = new Font("Segoe UI", 10F);
            txtSenha.BorderStyle = BorderStyle.FixedSingle;
            txtSenha.BackColor = CorInputFundo;
            txtSenha.ForeColor = CorTexto;
            txtSenha.Visible = true;
            txtSenha.Enter += (s, e) => txtSenha.BackColor = Color.White;
            txtSenha.Leave += (s, e) => txtSenha.BackColor = CorInputFundo;
            card.Controls.Add(txtSenha);

            this.Controls.Remove(btnVerPasse);
            btnVerPasse.Location = new Point(CardW - PaddingH - 36, 162);
            btnVerPasse.Size = new Size(36, 28);
            btnVerPasse.FlatStyle = FlatStyle.Flat;
            btnVerPasse.BackColor = CorInputFundo;
            btnVerPasse.ForeColor = CorLabel;
            btnVerPasse.Text = "";
            btnVerPasse.Cursor = Cursors.Hand;
            btnVerPasse.Visible = true;
            btnVerPasse.FlatAppearance.BorderColor = CorBorda;
            btnVerPasse.FlatAppearance.BorderSize = 1;
            btnVerPasse.Paint += BtnVerPasse_Paint;
            btnVerPasse.MouseEnter += (s, e) =>
            {
                btnVerPasse.BackColor = ColorTranslator.FromHtml("#EAF5EE");
                btnVerPasse.FlatAppearance.BorderColor = CorVerdeClaro;
                btnVerPasse.Invalidate();
            };
            btnVerPasse.MouseLeave += (s, e) =>
            {
                btnVerPasse.BackColor = CorInputFundo;
                btnVerPasse.FlatAppearance.BorderColor = CorBorda;
                btnVerPasse.Invalidate();
            };
            card.Controls.Add(btnVerPasse);

            this.Controls.Add(card);

            // 3. Separador ────────────────────────────────────────────
            this.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size = new Size(CardW, 1),
                Location = new Point(CardX, CardY + CardH + 16)
            });

            // 4. Botão Entrar ──────────────────────────────────────────
            this.Controls.Remove(btnLogin);
            btnLogin.Location = new Point(CardX, CardY + CardH + 26);
            btnLogin.Size = new Size(CardW, 44);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.BackColor = CorVerde;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.Visible = true;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = ColorTranslator.FromHtml("#0F6032");
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = CorVerde;
            this.Controls.Add(btnLogin);

            // 5. Rodapé ────────────────────────────────────────────────
            this.Controls.Add(new Label
            {
                Text = "© 2025 FitManager · Todos os direitos reservados",
                ForeColor = ColorTranslator.FromHtml("#7A9A7A"),
                Font = new Font("Segoe UI", 8F),
                AutoSize = false,
                Size = new Size(FormW, 20),
                Location = new Point(0, FormH - 26),
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        // ── Helper label de campo ─────────────────────────────────────
        private static Label MakeLabel(string text, Point loc) => new Label
        {
            Text = text,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = CorLabel,
            AutoSize = false,
            Size = new Size(296, 16),
            Location = loc
        };

        // ─────────────────────────────────────────────────────────────
        // PAINT HANDLERS
        // ─────────────────────────────────────────────────────────────
        private void PicLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            FillRounded(g, new SolidBrush(CorVerde),
                new Rectangle(0, 0, 52, 52), 12);
            FillRounded(g, new SolidBrush(CorVerdeClaro),
                new Rectangle(7, 23, 38, 6), 3);
            FillRounded(g, Brushes.White,
                new Rectangle(7, 16, 8, 20), 3);
            FillRounded(g, Brushes.White,
                new Rectangle(37, 16, 8, 20), 3);
            FillRounded(g, new SolidBrush(ColorTranslator.FromHtml("#A8F0C0")),
                new Rectangle(20, 20, 12, 12), 2);
        }

        private void LblNome_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var fnt = new Font("Segoe UI", 17F, FontStyle.Bold);
            using var verde = new SolidBrush(CorVerdeClaro);
            float x = 0;
            g.DrawString("Fit", fnt, Brushes.White, x, 2);
            x += g.MeasureString("Fit", fnt).Width - 4;
            g.DrawString("Manager", fnt, verde, x, 2);
        }

        private void BtnVerPasse_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(CorLabel, 1.6f)
            { LineJoin = LineJoin.Round, StartCap = LineCap.Round, EndCap = LineCap.Round };

            int cx = btnVerPasse.Width / 2;
            int cy = btnVerPasse.Height / 2;
            bool visivel = !txtSenha.UseSystemPasswordChar;

            if (visivel)
            {
                g.DrawLine(pen, cx - 8, cy - 6, cx + 8, cy + 6);
                g.DrawArc(pen, new RectangleF(cx - 8, cy - 5, 16, 10), 200, 140);
                g.DrawArc(pen, new RectangleF(cx - 2.5f, cy - 2.5f, 5, 5), 180, 180);
            }
            else
            {
                var p = new GraphicsPath();
                p.AddBezier(cx - 9, cy, cx - 5, cy - 6, cx + 5, cy - 6, cx + 9, cy);
                p.AddBezier(cx + 9, cy, cx + 5, cy + 6, cx - 5, cy + 6, cx - 9, cy);
                g.DrawPath(pen, p);
                g.DrawEllipse(pen, cx - 3f, cy - 3f, 6f, 6f);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // EVENTOS
        // ─────────────────────────────────────────────────────────────
        private void btnVerPasse_Click(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = !txtSenha.UseSystemPasswordChar;
            btnVerPasse.Invalidate();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            // lógica aqui
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            try
            {
                string hashDigitado = GerarHash(pass);
                Funcionario func = ValidarNoBanco(user, hashDigitado);

                if (func != null)
                {
                    Sessao.UsuarioLogado = func;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Utilizador ou Senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão: " + ex.Message);
            }
        }

        private Funcionario ValidarNoBanco(string user, string hash)
        {
            string? connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrEmpty(connectionString)) ;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                string sql = "SELECT Id, Usuario FROM Funcionario WHERE Usuario = @u AND Senha_hash = @s";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@s", hash);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Funcionario((int)reader["Id"], reader["Usuario"].ToString());
                    }
                }
            }
            return null;
        }
        private string GerarHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }





        // ─────────────────────────────────────────────────────────────
        // HELPER
        // ─────────────────────────────────────────────────────────────
        private static void FillRounded(Graphics g, Brush brush, Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }
    }
}
