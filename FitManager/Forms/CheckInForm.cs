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
        // ── Controlos ─────────────────────────────────────────────────
        private Panel  _picLogo;
        private Label  _lblNomeHeader;
        private Panel  _card;
        private Label  _lblFieldLabel;
        private TextBox txtSocio;
        private Button  btnCheckin;
        private Panel  _panelMsg;
        private Label  _lblMsg;

        // ── Paleta FitManager ─────────────────────────────────────────
        private static readonly Color CorEscura     = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorVerde      = ColorTranslator.FromHtml("#1A8A42");
        private static readonly Color CorVerdeClaro = ColorTranslator.FromHtml("#2ECC71");
        private static readonly Color CorFundo      = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorBorda      = ColorTranslator.FromHtml("#C8D8C8");
        private static readonly Color CorLabel      = ColorTranslator.FromHtml("#4A7A5A");
        private static readonly Color CorInputFundo = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorTexto      = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorSubtexto   = ColorTranslator.FromHtml("#6A8870");

        private const int FormW   = 460;
        private const int FormH   = 480;
        private const int HeaderH = 70;
        private const int CardX   = 50;
        private const int CardW   = 360;
        private const int Pad     = 32;

        private readonly string _placeholder = "Ex: NIF ou ID do Sócio";

        public CheckInForm()
        {
            this.Text            = "FitManager — Check-In";
            this.ClientSize      = new Size(FormW, FormH);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = CorFundo;
            this.Font            = new Font("Segoe UI", 9.5F);

            CriarHeader();
            CriarCard();
            CriarRodape();
        }

        // ─────────────────────────────────────────────────────────────
        // CONSTRUÇÃO
        // ─────────────────────────────────────────────────────────────

        private void CriarHeader()
        {
            var header = new Panel
            {
                Location  = new Point(0, 0),
                Size      = new Size(FormW, HeaderH),
                BackColor = CorEscura
            };

            _picLogo = new Panel
            {
                Size      = new Size(40, 40),
                Location  = new Point(Pad, 14),
                BackColor = Color.Transparent
            };
            _picLogo.Paint += PicLogo_Paint;

            _lblNomeHeader = new Label
            {
                AutoSize  = false,
                Size      = new Size(220, 30),
                Location  = new Point(Pad + 50, 18),
                BackColor = Color.Transparent
            };
            _lblNomeHeader.Paint += LblNome_Paint;

            var lblPagina = new Label
            {
                Text      = "Check-In",
                Font      = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = false,
                Size      = new Size(160, 44),
                Location  = new Point(FormW - 180, 12),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent
            };

            var accent = new Panel
            {
                BackColor = CorVerdeClaro,
                Size      = new Size(FormW, 3),
                Location  = new Point(0, HeaderH - 3)
            };

            header.Controls.Add(_picLogo);
            header.Controls.Add(_lblNomeHeader);
            header.Controls.Add(lblPagina);
            header.Controls.Add(accent);
            this.Controls.Add(header);
        }

        private void CriarCard()
        {
            int cardY = HeaderH + 30;
            int cardH = 300;

            _card = new Panel
            {
                Location  = new Point(CardX, cardY),
                Size      = new Size(CardW, cardH),
                BackColor = Color.White
            };
            _card.Paint += Card_Paint;

            // ── Ícone de check-in (círculo verde com visto) ───────────
            var picIcone = new Panel
            {
                Size      = new Size(56, 56),
                Location  = new Point((CardW - 56) / 2, 22),
                BackColor = Color.Transparent
            };
            picIcone.Paint += PicIcone_Paint;
            _card.Controls.Add(picIcone);

            // Título
            _card.Controls.Add(new Label
            {
                Text      = "Registo de Entrada",
                Font      = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize  = false,
                Size      = new Size(CardW, 26),
                Location  = new Point(0, 88),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Subtítulo
            _card.Controls.Add(new Label
            {
                Text      = "Ginásio FitManager",
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize  = false,
                Size      = new Size(CardW, 18),
                Location  = new Point(0, 116),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Separador
            _card.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size      = new Size(CardW - Pad * 2, 1),
                Location  = new Point(Pad, 142)
            });

            // Label campo
            _lblFieldLabel = new Label
            {
                Text      = "NIF ou ID do Sócio",
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = CorLabel,
                AutoSize  = false,
                Size      = new Size(CardW - Pad * 2, 16),
                Location  = new Point(Pad, 158)
            };
            _card.Controls.Add(_lblFieldLabel);

            // TextBox
            txtSocio = new TextBox
            {
                Size        = new Size(CardW - Pad * 2, 30),
                Location    = new Point(Pad, 178),
                Font        = new Font("Segoe UI", 10F),
                ForeColor   = CorBorda,
                Text        = _placeholder,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor   = CorInputFundo
            };
            txtSocio.Enter   += TxtSocio_Enter;
            txtSocio.Leave   += TxtSocio_Leave;
            txtSocio.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) FazerCheckin(); };
            _card.Controls.Add(txtSocio);

            // Botão Check-In
            btnCheckin = new Button
            {
                Text      = "✓   Fazer Check-In",
                Size      = new Size(CardW - Pad * 2, 42),
                Location  = new Point(Pad, 222),
                Font      = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = CorVerde,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnCheckin.FlatAppearance.BorderSize = 0;
            btnCheckin.Click      += (s, e) => FazerCheckin();
            btnCheckin.MouseEnter += (s, e) => btnCheckin.BackColor = ColorTranslator.FromHtml("#0F6032");
            btnCheckin.MouseLeave += (s, e) => btnCheckin.BackColor = CorVerde;
            _card.Controls.Add(btnCheckin);

            // Painel de mensagem inline
            _panelMsg = new Panel
            {
                Size      = new Size(CardW - Pad * 2, 0),   // começa colapsado
                Location  = new Point(Pad, 276),
                Visible   = false,
                BackColor = Color.Transparent
            };
            _lblMsg = new Label
            {
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Segoe UI", 9F)
            };
            _panelMsg.Controls.Add(_lblMsg);
            _panelMsg.Paint += PanelMsg_Paint;
            _card.Controls.Add(_panelMsg);

            this.Controls.Add(_card);

            // Separador + botão entrar
            this.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size      = new Size(CardW, 1),
                Location  = new Point(CardX, cardY + cardH + 14)
            });
        }

        private void CriarRodape()
        {
            this.Controls.Add(new Label
            {
                Text      = "© 2025 FitManager · Todos os direitos reservados",
                ForeColor = ColorTranslator.FromHtml("#7A9A7A"),
                Font      = new Font("Segoe UI", 8F),
                AutoSize  = false,
                Size      = new Size(FormW, 22),
                Location  = new Point(0, FormH - 24),
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        // ─────────────────────────────────────────────────────────────
        // PAINT HANDLERS
        // ─────────────────────────────────────────────────────────────

        private void PicLogo_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            FillRounded(g, new SolidBrush(CorVerde),         new Rectangle(0, 0, 40, 40), 9);
            FillRounded(g, new SolidBrush(CorVerdeClaro),    new Rectangle(5, 18, 30, 5), 2);
            FillRounded(g, Brushes.White,                     new Rectangle(5, 12, 6, 16), 2);
            FillRounded(g, Brushes.White,                     new Rectangle(29, 12, 6, 16), 2);
            FillRounded(g, new SolidBrush(ColorTranslator.FromHtml("#A8F0C0")),
                new Rectangle(15, 16, 10, 9), 2);
        }

        private void LblNome_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var fnt   = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var verde = new SolidBrush(CorVerdeClaro);
            float x = 0;
            g.DrawString("Fit", fnt, Brushes.White, x, 4);
            x += g.MeasureString("Fit", fnt).Width - 3;
            g.DrawString("Manager", fnt, verde, x, 4);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                new Rectangle(0, 0, _card.Width - 1, _card.Height - 1));
        }

        private void PicIcone_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Círculo fundo verde claro
            using var bgBrush = new SolidBrush(Color.FromArgb(30, 26, 138, 66));
            g.FillEllipse(bgBrush, 0, 0, 55, 55);
            using var borderPen = new Pen(CorVerde, 1.5f);
            g.DrawEllipse(borderPen, 1, 1, 53, 53);

            // Visto (checkmark)
            using var pen = new Pen(CorVerde, 2.8f)
            {
                LineJoin  = LineJoin.Round,
                StartCap  = LineCap.Round,
                EndCap    = LineCap.Round
            };
            g.DrawLines(pen, new[]
            {
                new Point(14, 28),
                new Point(23, 37),
                new Point(42, 18)
            });
        }

        private void PanelMsg_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, _panelMsg.Width - 1, _panelMsg.Height - 1);
            using var path  = RoundedPath(rect, 6);
            using var brush = new SolidBrush(_panelMsg.BackColor);
            g.FillPath(brush, path);
        }

        // ─────────────────────────────────────────────────────────────
        // LÓGICA ORIGINAL (sem alterações)
        // ─────────────────────────────────────────────────────────────

        private void FazerCheckin()
        {
            string input = txtSocio.Text.Trim();

            if (string.IsNullOrEmpty(input) || input == _placeholder)
            {
                MostrarMensagem("Por favor insere o NIF ou ID do sócio.", sucesso: false);
                return;
            }

            try
            {
                var resultado = VerificarSocio(input);

                if (resultado == null)
                {
                    MostrarPopup("Sócio não encontrado",
                        "Nenhum sócio corresponde ao NIF ou ID inserido.", sucesso: false);
                    return;
                }

                if (!resultado.Value.estadoAtivo)
                {
                    MostrarPopup("Acesso negado",
                        $"{resultado.Value.nome} não tem a subscrição ativa.", sucesso: false);
                    return;
                }

                RegistarEntrada(resultado.Value.id);
                MostrarPopup("Bem-vindo!", $"{resultado.Value.nome} entrou com sucesso.", sucesso: true);

                txtSocio.Text      = _placeholder;
                txtSocio.ForeColor = CorBorda;
                _panelMsg.Visible  = false;
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

            bool isNumeric = int.TryParse(input, out int idParsed);
            string query   = isNumeric
                ? "SELECT Id, Nome, EstadoAtivo FROM Socio WHERE Id = @Valor"
                : "SELECT Id, Nome, EstadoAtivo FROM Socio WHERE Nif = @Valor";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Valor", isNumeric ? (object)idParsed : input);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return (reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));

            return null;
        }

        private void RegistarEntrada(int socioId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            using var cmd  = new SqlCommand("INSERT INTO RegistoEntrada (SocioId) VALUES (@SocioId)", conn);
            cmd.Parameters.AddWithValue("@SocioId", socioId);
            cmd.ExecuteNonQuery();
        }

        private void MostrarPopup(string titulo, string mensagem, bool sucesso)
        {
            using var popup = new Form
            {
                Text            = "",
                Size            = new Size(360, 210),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor       = Color.White
            };

            // Barra colorida no topo
            popup.Controls.Add(new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 5,
                BackColor = sucesso ? CorVerde : ColorTranslator.FromHtml("#C0392B")
            });

            // Círculo com ícone
            var painelIcone = new Panel
            {
                Size      = new Size(52, 52),
                Location  = new Point((360 - 52) / 2, 22),
                BackColor = Color.Transparent
            };
            bool _sucesso = sucesso;
            painelIcone.Paint += (s, ev) =>
            {
                var g = ev.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color cor = _sucesso ? CorVerde : ColorTranslator.FromHtml("#C0392B");
                using var bgBrush = new SolidBrush(Color.FromArgb(25, cor.R, cor.G, cor.B));
                g.FillEllipse(bgBrush, 0, 0, 51, 51);
                using var pen = new Pen(cor, 2.5f)
                    { StartCap = LineCap.Round, EndCap = LineCap.Round };
                if (_sucesso)
                    g.DrawLines(pen, new[] { new Point(13, 27), new Point(22, 36), new Point(38, 16) });
                else
                {
                    g.DrawLine(pen, 16, 16, 36, 36);
                    g.DrawLine(pen, 36, 16, 16, 36);
                }
            };
            popup.Controls.Add(painelIcone);

            popup.Controls.Add(new Label
            {
                Text      = titulo,
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = CorTexto,
                Size      = new Size(320, 24),
                Location  = new Point(20, 88),
                TextAlign = ContentAlignment.MiddleCenter
            });
            popup.Controls.Add(new Label
            {
                Text      = mensagem,
                Font      = new Font("Segoe UI", 9F),
                ForeColor = CorSubtexto,
                Size      = new Size(320, 36),
                Location  = new Point(20, 116),
                TextAlign = ContentAlignment.MiddleCenter
            });

            var btnOk = new Button
            {
                Text      = "OK",
                Size      = new Size(110, 34),
                Location  = new Point((360 - 110) / 2, 156),
                Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = sucesso ? CorVerde : ColorTranslator.FromHtml("#C0392B"),
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, ev) => popup.Close();
            popup.Controls.Add(btnOk);

            popup.Deactivate += (s, ev) => popup.Close();
            popup.ShowDialog(this);
        }

        private void MostrarMensagem(string texto, bool sucesso)
        {
            _panelMsg.BackColor = sucesso
                ? Color.FromArgb(220, 252, 231)
                : Color.FromArgb(254, 226, 226);
            _lblMsg.ForeColor = sucesso
                ? CorVerde
                : ColorTranslator.FromHtml("#922B21");
            _lblMsg.Text      = texto;
            _panelMsg.Size    = new Size(CardW - Pad * 2, 34);
            _panelMsg.Visible = true;
            _panelMsg.Invalidate();
        }

        private void TxtSocio_Enter(object sender, EventArgs e)
        {
            if (txtSocio.Text == _placeholder)
            {
                txtSocio.Text      = "";
                txtSocio.ForeColor = CorTexto;
                txtSocio.BackColor = Color.White;
            }
        }

        private void TxtSocio_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSocio.Text))
            {
                txtSocio.Text      = _placeholder;
                txtSocio.ForeColor = CorBorda;
                txtSocio.BackColor = CorInputFundo;
            }
        }

        // ─────────────────────────────────────────────────────────────
        // HELPERS
        // ─────────────────────────────────────────────────────────────

        private static void FillRounded(Graphics g, Brush brush, Rectangle r, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X,         r.Y,          d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y,          d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d,   0, 90);
            path.AddArc(r.X,         r.Bottom - d, d, d,  90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }

        private static GraphicsPath RoundedPath(Rectangle r, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X,         r.Y,          d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y,          d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d,   0, 90);
            path.AddArc(r.X,         r.Bottom - d, d, d,  90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
