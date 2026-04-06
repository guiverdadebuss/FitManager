using FitManager.Data;
using FitManager.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class SocioForm : Form
    {
        // ── Paleta FitManager ─────────────────────────────────────────
        private static readonly Color CorEscura     = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorVerde      = ColorTranslator.FromHtml("#1A8A42");
        private static readonly Color CorVerdeClaro = ColorTranslator.FromHtml("#2ECC71");
        private static readonly Color CorVermelho   = ColorTranslator.FromHtml("#C0392B");
        private static readonly Color CorVermelhoH  = ColorTranslator.FromHtml("#922B21");
        private static readonly Color CorAzul       = ColorTranslator.FromHtml("#2D6A9F");
        private static readonly Color CorAzulH      = ColorTranslator.FromHtml("#1E3A5F");
        private static readonly Color CorAmbar      = ColorTranslator.FromHtml("#D4AC0D");
        private static readonly Color CorAmbarH     = ColorTranslator.FromHtml("#9A7D0A");
        private static readonly Color CorFundo      = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorBorda      = ColorTranslator.FromHtml("#C8D8C8");
        private static readonly Color CorLabel      = ColorTranslator.FromHtml("#4A7A5A");
        private static readonly Color CorTexto      = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorSubtexto   = ColorTranslator.FromHtml("#6A8870");

        private const int FormW   = 900;
        private const int FormH   = 500;
        private const int HeaderH = 70;
        private const int Pad     = 28;

        private Panel _picLogo;
        private Label _lblNomeHeader;

        public SocioForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(FormW, FormH);
            this.BackColor  = CorFundo;
            this.Font       = new Font("Segoe UI", 9.5F);
            ConstruirUI();
        }

        // ─────────────────────────────────────────────────────────────
        private void ConstruirUI()
        {
            CriarHeader();
            CriarSubtitulo();
            CriarActionCards();
            CriarRodape();
        }

        // ── 1. Header ─────────────────────────────────────────────────
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
                Text      = "Gestão de Sócios",
                Font      = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = false,
                Size      = new Size(280, 44),
                Location  = new Point(FormW - 300, 12),
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

        // ── 2. Subtítulo da secção ────────────────────────────────────
        private void CriarSubtitulo()
        {
            this.Controls.Add(new Label
            {
                Text      = "Selecione uma operação",
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize  = false,
                Size      = new Size(FormW - Pad * 2, 24),
                Location  = new Point(Pad, HeaderH + 22),
                TextAlign = ContentAlignment.MiddleLeft
            });
            this.Controls.Add(new Label
            {
                Text      = "Escolha a ação que pretende realizar sobre os sócios do ginásio",
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize  = false,
                Size      = new Size(FormW - Pad * 2, 18),
                Location  = new Point(Pad, HeaderH + 48),
                TextAlign = ContentAlignment.MiddleLeft
            });

            // Linha separadora
            this.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size      = new Size(FormW - Pad * 2, 1),
                Location  = new Point(Pad, HeaderH + 72)
            });
        }

        // ── 3. Cards de ação ──────────────────────────────────────────
        private void CriarActionCards()
        {
            // Definição de cada card: (botão, título, descrição, cor, cor hover, ícone)
            var acoes = new[]
            {
                (btnCriarSocio,  "Criar Sócio",       "Registar um novo\nsócio no sistema",    CorVerde,    CorVerdeClaro, "＋"),
                (btnEditarSocio, "Editar Sócio",      "Alterar dados de\num sócio existente",  CorAzul,     CorAzulH,      "✎"),
                (btnDetalhes,    "Detalhes / Listar", "Consultar e pesquisar\ntodos os sócios", CorLabel,    CorEscura,     "☰"),
                (btnApagarSocio, "Eliminar Sócio",    "Remover um sócio\ndo sistema",           CorVermelho, CorVermelhoH,  "✕"),
            };

            int cardW     = 188;
            int cardH     = 200;
            int totalW    = acoes.Length * cardW + (acoes.Length - 1) * Pad;
            int startX    = (FormW - totalW) / 2;
            int cardY     = HeaderH + 92;

            for (int i = 0; i < acoes.Length; i++)
            {
                var (btn, titulo, descricao, cor, corHover, icone) = acoes[i];
                int x = startX + i * (cardW + Pad);

                // Card (panel branco)
                var card = new Panel
                {
                    Location  = new Point(x, cardY),
                    Size      = new Size(cardW, cardH),
                    BackColor = Color.White,
                    Cursor    = Cursors.Hand
                };

                Color corAtual = cor;
                card.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.DrawRectangle(new Pen(CorBorda, 1),
                        new Rectangle(0, 0, card.Width - 1, card.Height - 1));
                    // Topo colorido
                    g.FillRectangle(new SolidBrush(corAtual),
                        new Rectangle(0, 0, card.Width, 6));
                };

                // Círculo com ícone
                var picIcone = new Panel
                {
                    Size      = new Size(56, 56),
                    Location  = new Point((cardW - 56) / 2, 22),
                    BackColor = Color.Transparent
                };
                Color corIcone = cor;
                picIcone.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using var bgBrush = new SolidBrush(Color.FromArgb(20, corIcone.R, corIcone.G, corIcone.B));
                    g.FillEllipse(bgBrush, 0, 0, 55, 55);
                    using var pen = new Pen(corIcone, 1.5f);
                    g.DrawEllipse(pen, 1, 1, 53, 53);
                    using var fnt = new Font("Segoe UI", 20F, FontStyle.Bold);
                    var sz = g.MeasureString(icone, fnt);
                    using var brush = new SolidBrush(corIcone);
                    g.DrawString(icone, fnt, brush,
                        (56 - sz.Width) / 2 - 1,
                        (56 - sz.Height) / 2);
                };
                card.Controls.Add(picIcone);

                // Título
                card.Controls.Add(new Label
                {
                    Text      = titulo,
                    Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = CorTexto,
                    AutoSize  = false,
                    Size      = new Size(cardW - 16, 22),
                    Location  = new Point(8, 88),
                    TextAlign = ContentAlignment.MiddleCenter
                });

                // Descrição
                card.Controls.Add(new Label
                {
                    Text      = descricao,
                    Font      = new Font("Segoe UI", 8.5F),
                    ForeColor = CorSubtexto,
                    AutoSize  = false,
                    Size      = new Size(cardW - 16, 42),
                    Location  = new Point(8, 112),
                    TextAlign = ContentAlignment.TopCenter
                });

                // Botão dentro do card
                this.Controls.Remove(btn);
                btn.Location  = new Point(12, 162);
                btn.Size      = new Size(cardW - 24, 28);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = cor;
                btn.ForeColor = Color.White;
                btn.Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                btn.Cursor    = Cursors.Hand;
                btn.Visible   = true;
                btn.FlatAppearance.BorderSize = 0;

                Color corBase  = cor;
                Color corHov   = corHover;
                btn.MouseEnter += (s, e) => btn.BackColor = corHov;
                btn.MouseLeave += (s, e) => btn.BackColor = corBase;

                card.Controls.Add(btn);
                this.Controls.Add(card);
            }
        }

        // ── 4. Rodapé ─────────────────────────────────────────────────
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

        // ─────────────────────────────────────────────────────────────
        // LÓGICA ORIGINAL (sem alterações)
        // ─────────────────────────────────────────────────────────────
        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            ListarSocio det = new ListarSocio();
            det.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            det.ShowDialog();
            this.Show();
        }

        private void btnApagarSocio_Click(object sender, EventArgs e)
        {
            using (var f = new EliminarSocio())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    CarregarTodosSocios();
            }
        }

        private void CarregarTodosSocios()
        {
            var socios = SocioRepository.CarregarTodosSocios();
            // lógica de atualização da grelha aqui
        }

        // ─────────────────────────────────────────────────────────────
        // HELPER
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
    }
}
