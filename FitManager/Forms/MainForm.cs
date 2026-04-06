using FitManager.Data;
using FitManager.Models;
using FitManager.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class MainForm : Form
    {
        // ── Paleta FitManager ─────────────────────────────────────────
        private static readonly Color CorEscura     = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorVerde      = ColorTranslator.FromHtml("#1A8A42");
        private static readonly Color CorVerdeClaro = ColorTranslator.FromHtml("#2ECC71");
        private static readonly Color CorFundo      = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorBorda      = ColorTranslator.FromHtml("#C8D8C8");
        private static readonly Color CorLabel      = ColorTranslator.FromHtml("#4A7A5A");
        private static readonly Color CorTexto      = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorSubtexto   = ColorTranslator.FromHtml("#6A8870");
        private static readonly Color CorGridHeader = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorGridAlt    = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorSelecao    = ColorTranslator.FromHtml("#D6EEE0");

        private const int FormW   = 1100;
        private const int FormH   = 680;
        private const int HeaderH = 70;
        private const int Pad     = 20;
        private const int SideW   = 200;

        // Referências a painéis criados em código
        private Panel _sidebar;
        private Panel _cardSocios;
        private Panel _cardEntradas;
        private Panel _cardTabela;
        private Panel _picLogo;
        private Label _lblNomeHeader;

        public MainForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(FormW, FormH);
            this.BackColor  = CorFundo;
            this.Font       = new Font("Segoe UI", 9.5F);
            ConstruirUI();
        }

        // ─────────────────────────────────────────────────────────────
        // CONSTRUÇÃO DA UI
        // ─────────────────────────────────────────────────────────────
        private void ConstruirUI()
        {
            CriarHeader();
            CriarSidebar();
            CriarMetricCards();
            CriarCardTabela();
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

            // Boas-vindas à direita
            this.Controls.Remove(lblUsuarioLogado);
            lblUsuarioLogado.AutoSize  = false;
            lblUsuarioLogado.Size      = new Size(380, 30);
            lblUsuarioLogado.Location  = new Point(FormW - 400, 20);
            lblUsuarioLogado.Font      = new Font("Segoe UI", 9.5F);
            lblUsuarioLogado.ForeColor = Color.FromArgb(180, 255, 255, 255);
            lblUsuarioLogado.TextAlign = ContentAlignment.MiddleRight;
            lblUsuarioLogado.BackColor = Color.Transparent;
            lblUsuarioLogado.Visible   = true;
            header.Controls.Add(lblUsuarioLogado);

            // Linha verde accent em baixo
            var accent = new Panel
            {
                BackColor = CorVerdeClaro,
                Size      = new Size(FormW, 3),
                Location  = new Point(0, HeaderH - 3)
            };

            header.Controls.Add(_picLogo);
            header.Controls.Add(_lblNomeHeader);
            header.Controls.Add(accent);
            this.Controls.Add(header);
        }

        // ── 2. Sidebar de navegação ───────────────────────────────────
        private void CriarSidebar()
        {
            _sidebar = new Panel
            {
                Location  = new Point(0, HeaderH),
                Size      = new Size(SideW, FormH - HeaderH),
                BackColor = ColorTranslator.FromHtml("#162E1A")
            };

            // Separador subtil no topo da sidebar
            var sepTopo = new Panel
            {
                BackColor = Color.FromArgb(40, 255, 255, 255),
                Size      = new Size(SideW, 1),
                Location  = new Point(0, 0)
            };
            _sidebar.Controls.Add(sepTopo);

            // Título da secção
            var lblNav = new Label
            {
                Text      = "NAVEGAÇÃO",
                Font      = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 255, 255, 255),
                AutoSize  = false,
                Size      = new Size(SideW, 18),
                Location  = new Point(0, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _sidebar.Controls.Add(lblNav);

            // Botões de navegação
            var navBtns = new[]
            {
                (btnSocios,  "Sócios",            "👤"),
                (btnPlanos,  "Planos Subscrição",  "📋"),
                (btnCheckIn, "Check-In",           "✓"),
            };

            int y = 52;
            foreach (var (btn, texto, icone) in navBtns)
            {
                this.Controls.Remove(btn);
                btn.Location  = new Point(12, y);
                btn.Size      = new Size(SideW - 24, 46);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(200, 255, 255, 255);
                btn.Font      = new Font("Segoe UI", 9.5F);
                btn.Text      = $"  {icone}  {texto}";
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Cursor    = Cursors.Hand;
                btn.Visible   = true;
                btn.FlatAppearance.BorderSize  = 0;
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#1A8A42");
                btn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#0F6032");
                _sidebar.Controls.Add(btn);
                y += 54;
            }

            // Separador antes do logout (visual)
            var sepBottom = new Panel
            {
                BackColor = Color.FromArgb(40, 255, 255, 255),
                Size      = new Size(SideW - 24, 1),
                Location  = new Point(12, FormH - HeaderH - 60)
            };
            _sidebar.Controls.Add(sepBottom);

            // Versão no fundo da sidebar
            var lblVer = new Label
            {
                Text      = "FitManager v1.0",
                Font      = new Font("Segoe UI", 7.5F),
                ForeColor = Color.FromArgb(70, 255, 255, 255),
                AutoSize  = false,
                Size      = new Size(SideW, 20),
                Location  = new Point(0, FormH - HeaderH - 36),
                TextAlign = ContentAlignment.MiddleCenter
            };
            _sidebar.Controls.Add(lblVer);

            this.Controls.Add(_sidebar);
        }

        // ── 3. Cards de métricas ──────────────────────────────────────
        private void CriarMetricCards()
        {
            int contentX = SideW + Pad;
            int contentY = HeaderH + Pad;
            int cardW    = 200;
            int cardH    = 90;

            // Card Sócios Ativos
            _cardSocios = CriarMetricCard(
                location : new Point(contentX, contentY),
                size     : new Size(cardW, cardH),
                titulo   : "Sócios Ativos",
                icone    : "👥"
            );
            this.Controls.Remove(lblTotalSocios);
            lblTotalSocios.AutoSize  = false;
            lblTotalSocios.Size      = new Size(cardW - 32, 36);
            lblTotalSocios.Location  = new Point(16, 46);
            lblTotalSocios.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalSocios.ForeColor = CorVerde;
            lblTotalSocios.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalSocios.Visible   = true;
            _cardSocios.Controls.Add(lblTotalSocios);
            this.Controls.Add(_cardSocios);

            // Card Check-Ins
            _cardEntradas = CriarMetricCard(
                location : new Point(contentX + cardW + Pad, contentY),
                size     : new Size(cardW, cardH),
                titulo   : "Check-Ins Hoje",
                icone    : "✓"
            );
            this.Controls.Remove(lblTotalEntradas);
            lblTotalEntradas.AutoSize  = false;
            lblTotalEntradas.Size      = new Size(cardW - 32, 36);
            lblTotalEntradas.Location  = new Point(16, 46);
            lblTotalEntradas.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalEntradas.ForeColor = CorVerde;
            lblTotalEntradas.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalEntradas.Visible   = true;
            _cardEntradas.Controls.Add(lblTotalEntradas);
            this.Controls.Add(_cardEntradas);
        }

        private Panel CriarMetricCard(Point location, Size size, string titulo, string icone)
        {
            var card = new Panel
            {
                Location  = location,
                Size      = size,
                BackColor = Color.White
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, card.Width - 1, card.Height - 1));
                e.Graphics.FillRectangle(new SolidBrush(CorVerde),
                    new Rectangle(0, 0, 4, card.Height));
            };

            card.Controls.Add(new Label
            {
                Text      = $"{icone}  {titulo}",
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = CorLabel,
                AutoSize  = false,
                Size      = new Size(size.Width - 16, 24),
                Location  = new Point(16, 14),
                TextAlign = ContentAlignment.MiddleLeft
            });

            return card;
        }

        // ── 4. Card da tabela de acessos ──────────────────────────────
        private void CriarCardTabela()
        {
            int contentX = SideW + Pad;
            int tabelaY  = HeaderH + Pad + 90 + Pad;
            int tabelaW  = FormW - contentX - Pad;
            int tabelaH  = FormH - tabelaY - 36;

            _cardTabela = new Panel
            {
                Location  = new Point(contentX, tabelaY),
                Size      = new Size(tabelaW, tabelaH),
                BackColor = Color.White
            };
            _cardTabela.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardTabela.Width - 1, _cardTabela.Height - 1));

            _cardTabela.Controls.Add(new Label
            {
                Text      = "Últimos Acessos",
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize  = false,
                Size      = new Size(300, 30),
                Location  = new Point(12, 8),
                TextAlign = ContentAlignment.MiddleLeft
            });

            var sep = new Panel
            {
                BackColor = CorBorda,
                Size      = new Size(tabelaW - 24, 1),
                Location  = new Point(12, 40)
            };
            _cardTabela.Controls.Add(sep);

            // DataGridView
            this.Controls.Remove(dgvAcessos);
            dgvAcessos.Location                          = new Point(0, 44);
            dgvAcessos.Size                              = new Size(tabelaW, tabelaH - 44);
            dgvAcessos.Visible                           = true;
            dgvAcessos.BorderStyle                       = BorderStyle.None;
            dgvAcessos.CellBorderStyle                   = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAcessos.GridColor                         = CorBorda;
            dgvAcessos.BackgroundColor                   = Color.White;
            dgvAcessos.RowHeadersVisible                 = false;
            dgvAcessos.AllowUserToAddRows                = false;
            dgvAcessos.AllowUserToDeleteRows             = false;
            dgvAcessos.ReadOnly                          = true;
            dgvAcessos.SelectionMode                     = DataGridViewSelectionMode.FullRowSelect;
            dgvAcessos.EnableHeadersVisualStyles         = false;
            dgvAcessos.Font                              = new Font("Segoe UI", 9F);
            dgvAcessos.DefaultCellStyle.BackColor          = Color.White;
            dgvAcessos.DefaultCellStyle.ForeColor          = CorTexto;
            dgvAcessos.DefaultCellStyle.SelectionBackColor = CorSelecao;
            dgvAcessos.DefaultCellStyle.SelectionForeColor = CorTexto;
            dgvAcessos.DefaultCellStyle.Padding            = new Padding(6, 0, 6, 0);
            dgvAcessos.AlternatingRowsDefaultCellStyle.BackColor          = CorGridAlt;
            dgvAcessos.AlternatingRowsDefaultCellStyle.SelectionBackColor = CorSelecao;
            dgvAcessos.ColumnHeadersDefaultCellStyle.BackColor  = CorGridHeader;
            dgvAcessos.ColumnHeadersDefaultCellStyle.ForeColor  = CorLabel;
            dgvAcessos.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvAcessos.ColumnHeadersDefaultCellStyle.Padding    = new Padding(6, 0, 6, 0);
            dgvAcessos.ColumnHeadersBorderStyle                 = DataGridViewHeaderBorderStyle.None;
            dgvAcessos.ColumnHeadersHeight                      = 36;
            dgvAcessos.RowTemplate.Height                       = 38;

            _cardTabela.Controls.Add(dgvAcessos);
            this.Controls.Add(_cardTabela);
        }

        // ── 5. Rodapé ─────────────────────────────────────────────────
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Sessao.EstaLogado)
            {
                this.Text = "FitManager — " + Sessao.UsuarioLogado.Usuario;
                string name = Sessao.UsuarioLogado.Usuario;
                lblUsuarioLogado.Text = "Bem-vindo, " + char.ToUpper(name[0]) + name.Substring(1);
                CarregarResumoDiario();
                AtualizarTabelaAcessos();
            }
        }

        public void CarregarResumoDiario()
        {
            try
            {
                int ativos    = SocioRepository.CarregarTotalSociosAtivos();
                int entradas  = SocioRepository.CarregarCheckIns();
                lblTotalSocios.Text   = ativos.ToString();
                lblTotalEntradas.Text = entradas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar resumo: " + ex.Message);
            }
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            SocioForm soc = new SocioForm();
            soc.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            soc.ShowDialog();
            this.Show();
        }

        private void btnPlanos_Click(object sender, EventArgs e)
        {
            GerirPlanosForm plan = new GerirPlanosForm();
            plan.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            plan.ShowDialog();
            this.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInForm check = new CheckInForm();
            check.FormClosed += (s, args) => CarregarResumoDiario();
            check.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            check.ShowDialog();
            this.Show();
        }

        private void AtualizarTabelaAcessos()
        {
            try
            {
                var acessos = SocioRepository.ObterUltimosAcessos();
                var dadosParaExibir = acessos.Select(a => new {
                    Hora     = a.DataHora.ToString("HH:mm:ss"),
                    Data     = a.DataHora.ToShortDateString(),
                    Socio    = a.SocioQueEntrou?.Nome ?? "N/A",
                    Documento = a.SocioQueEntrou?.Nif ?? "-"
                }).ToList();

                dgvAcessos.DataSource = null;
                dgvAcessos.DataSource = dadosParaExibir;
                FormatarGrade();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar histórico: " + ex.Message);
            }
        }

        private void FormatarGrade()
        {
            dgvAcessos.AutoSizeColumnsMode      = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAcessos.AllowUserToResizeColumns = false;
            dgvAcessos.AllowUserToResizeRows    = false;

            if (dgvAcessos.Columns["Socio"] != null)
                dgvAcessos.Columns["Socio"].FillWeight = 200;
            if (dgvAcessos.Columns["Hora"] != null)
                dgvAcessos.Columns["Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvAcessos.Columns["Data"] != null)
                dgvAcessos.Columns["Data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAcessos.RowTemplate.Height = 38;
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
