using FitManager.Data;
using FitManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class ListarSocio : Form
    {
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
        private static readonly Color CorGridHeader = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorGridAlt    = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorSelecao    = ColorTranslator.FromHtml("#D6EEE0");
        private static readonly Color CorSelecaoTxt = ColorTranslator.FromHtml("#0F2A1A");

        // ── Layout ────────────────────────────────────────────────────
        private const int FormW   = 900;
        private const int FormH   = 620;
        private const int HeaderH = 90;
        private const int Pad     = 20;

        // Painéis principais
        private Panel _cardBusca;
        private Panel _cardDetalhes;
        private Panel _cardTabela;

        // Lista carregada
        List<Socio> listaSocios = new List<Socio>();

        public ListarSocio()
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
            CriarBarraBusca();
            CriarCardDetalhes();
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

            var picLogo = new Panel
            {
                Size      = new Size(44, 44),
                Location  = new Point(Pad, 22),
                BackColor = Color.Transparent
            };
            picLogo.Paint += PicLogo_Paint;

            var lblNome = new Label
            {
                AutoSize  = false,
                Size      = new Size(230, 32),
                Location  = new Point(Pad + 54, 18),
                BackColor = Color.Transparent
            };
            lblNome.Paint += LblNome_Paint;

            var lblTag = new Label
            {
                Text      = "GESTÃO DE GINÁSIO",
                Font      = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = Color.FromArgb(110, 255, 255, 255),
                AutoSize  = false,
                Size      = new Size(200, 14),
                Location  = new Point(Pad + 56, 52),
                BackColor = Color.Transparent
            };

            // Título da página à direita
            var lblPagina = new Label
            {
                Text      = "Lista de Sócios",
                Font      = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = false,
                Size      = new Size(300, 44),
                Location  = new Point(FormW - 320, 22),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent
            };

            // Barra verde accent em baixo
            var accent = new Panel
            {
                BackColor = CorVerdeClaro,
                Size      = new Size(FormW, 3),
                Location  = new Point(0, HeaderH - 3)
            };

            header.Controls.Add(picLogo);
            header.Controls.Add(lblNome);
            header.Controls.Add(lblTag);
            header.Controls.Add(lblPagina);
            header.Controls.Add(accent);
            this.Controls.Add(header);
        }

        // ── 2. Barra de busca ─────────────────────────────────────────
        private void CriarBarraBusca()
        {
            _cardBusca = new Panel
            {
                Location  = new Point(Pad, HeaderH + Pad),
                Size      = new Size(FormW - Pad * 2, 56),
                BackColor = Color.White
            };
            _cardBusca.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardBusca.Width - 1, _cardBusca.Height - 1));

            var lblPesq = new Label
            {
                Text      = "Pesquisar por ID ou NIF:",
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = CorLabel,
                AutoSize  = false,
                Size      = new Size(180, 30),
                Location  = new Point(16, 12),
                TextAlign = ContentAlignment.MiddleLeft
            };

            this.Controls.Remove(txtBusca);
            txtBusca.Location    = new Point(200, 13);
            txtBusca.Size        = new Size(340, 28);
            txtBusca.Font        = new Font("Segoe UI", 10F);
            txtBusca.BorderStyle = BorderStyle.FixedSingle;
            txtBusca.BackColor   = CorInputFundo;
            txtBusca.ForeColor   = CorTexto;
            txtBusca.Visible     = true;
            txtBusca.Enter      += (s, e) => txtBusca.BackColor = Color.White;
            txtBusca.Leave      += (s, e) => txtBusca.BackColor = CorInputFundo;
            // Enter também pesquisa
            txtBusca.KeyDown    += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) btnBusca_Click(s, e);
            };

            this.Controls.Remove(btnBusca);
            btnBusca.Location  = new Point(550, 13);
            btnBusca.Size      = new Size(110, 28);
            btnBusca.FlatStyle = FlatStyle.Flat;
            btnBusca.BackColor = CorVerde;
            btnBusca.ForeColor = Color.White;
            btnBusca.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBusca.Text      = "Pesquisar";
            btnBusca.Cursor    = Cursors.Hand;
            btnBusca.Visible   = true;
            btnBusca.FlatAppearance.BorderSize = 0;
            btnBusca.MouseEnter += (s, e) => btnBusca.BackColor = ColorTranslator.FromHtml("#0F6032");
            btnBusca.MouseLeave += (s, e) => btnBusca.BackColor = CorVerde;

            var btnLimpar = new Button
            {
                Location  = new Point(670, 13),
                Size      = new Size(80, 28),
                FlatStyle = FlatStyle.Flat,
                BackColor = CorFundo,
                ForeColor = CorLabel,
                Font      = new Font("Segoe UI", 9F),
                Text      = "Limpar",
                Cursor    = Cursors.Hand
            };
            btnLimpar.FlatAppearance.BorderColor = CorBorda;
            btnLimpar.FlatAppearance.BorderSize  = 1;
            btnLimpar.Click += (s, e) =>
            {
                txtBusca.Clear();
                _cardDetalhes.Visible = false;
                CarregarTabela();
            };

            _cardBusca.Controls.Add(lblPesq);
            _cardBusca.Controls.Add(txtBusca);
            _cardBusca.Controls.Add(btnBusca);
            _cardBusca.Controls.Add(btnLimpar);
            this.Controls.Add(_cardBusca);
        }

        // ── 3. Card de detalhes (aparece após pesquisa) ───────────────
        private void CriarCardDetalhes()
        {
            int y = HeaderH + Pad + 56 + Pad;

            _cardDetalhes = new Panel
            {
                Location  = new Point(Pad, y),
                Size      = new Size(FormW - Pad * 2, 96),
                BackColor = Color.White,
                Visible   = false
            };
            _cardDetalhes.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardDetalhes.Width - 1, _cardDetalhes.Height - 1));
                // Faixa verde à esquerda
                g.FillRectangle(new SolidBrush(CorVerde), 0, 0, 4, _cardDetalhes.Height);
            };

            var lblTit = new Label
            {
                Text      = "Sócio encontrado",
                Font      = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = CorVerde,
                AutoSize  = false,
                Size      = new Size(160, 20),
                Location  = new Point(16, 10)
            };
            _cardDetalhes.Controls.Add(lblTit);

            // Campos em grelha horizontal — (chave, label, x_offset, largura)
            var campos = new[]
            {
                ("ID",        lblId,       0,   50),
                ("Nome",      lblNome,     60,  200),
                ("NIF",       lblNif,      270, 130),
                ("Telefone",  lblTelefone, 410, 130),
                ("Inscrição", lblDataInsc, 550, 120),
                ("Plano",     lblPlano,    680, 60),
            };

            foreach (var (chave, lbl, x, largura) in campos)
            {
                _cardDetalhes.Controls.Add(new Label
                {
                    Text      = chave,
                    Font      = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                    ForeColor = CorLabel,
                    AutoSize  = false,
                    Size      = new Size(largura, 14),
                    Location  = new Point(16 + x, 36)
                });

                this.Controls.Remove(lbl);
                lbl.Font      = new Font("Segoe UI", 9.5F);
                lbl.ForeColor = CorTexto;
                lbl.AutoSize  = false;
                lbl.Size      = new Size(largura, 20);
                lbl.Location  = new Point(16 + x, 54);
                lbl.Visible   = true;
                _cardDetalhes.Controls.Add(lbl);
            }

            this.Controls.Add(_cardDetalhes);
        }

        // ── 4. Card com a tabela ──────────────────────────────────────
        private void CriarCardTabela()
        {
            int detalhesH = 96 + Pad;
            int tabelaY   = HeaderH + Pad + 56 + Pad + detalhesH;
            int tabelaH   = FormH - tabelaY - 30;

            _cardTabela = new Panel
            {
                Location  = new Point(Pad, tabelaY),
                Size      = new Size(FormW - Pad * 2, tabelaH),
                BackColor = Color.White
            };
            _cardTabela.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardTabela.Width - 1, _cardTabela.Height - 1));

            // Cabeçalho da tabela
            var lblTit = new Label
            {
                Text      = "Todos os Sócios",
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize  = false,
                Size      = new Size(300, 30),
                Location  = new Point(12, 8),
                TextAlign = ContentAlignment.MiddleLeft
            };
            _cardTabela.Controls.Add(lblTit);

            // Contador
            var lblCount = new Label
            {
                Name      = "lblCount",
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize  = false,
                Size      = new Size(200, 30),
                Location  = new Point(_cardTabela.Width - 220, 8),
                TextAlign = ContentAlignment.MiddleRight
            };
            _cardTabela.Controls.Add(lblCount);

            var sepTit = new Panel
            {
                BackColor = CorBorda,
                Size      = new Size(_cardTabela.Width - 24, 1),
                Location  = new Point(12, 40)
            };
            _cardTabela.Controls.Add(sepTit);

            // DataGridView estilizado
            this.Controls.Remove(dgvSocios);
            dgvSocios.Location                          = new Point(0, 44);
            dgvSocios.Size                              = new Size(_cardTabela.Width, tabelaH - 44);
            dgvSocios.Visible                           = true;
            dgvSocios.Anchor                            = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSocios.BorderStyle                       = BorderStyle.None;
            dgvSocios.CellBorderStyle                   = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSocios.GridColor                         = CorBorda;
            dgvSocios.BackgroundColor                   = Color.White;
            dgvSocios.RowHeadersVisible                 = false;
            dgvSocios.AllowUserToAddRows                = false;
            dgvSocios.AllowUserToDeleteRows             = false;
            dgvSocios.ReadOnly                          = true;
            dgvSocios.SelectionMode                     = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.AutoSizeColumnsMode               = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocios.EnableHeadersVisualStyles         = false;
            dgvSocios.Font                              = new Font("Segoe UI", 9F);

            // Células
            dgvSocios.DefaultCellStyle.BackColor          = Color.White;
            dgvSocios.DefaultCellStyle.ForeColor          = CorTexto;
            dgvSocios.DefaultCellStyle.SelectionBackColor = CorSelecao;
            dgvSocios.DefaultCellStyle.SelectionForeColor = CorSelecaoTxt;
            dgvSocios.DefaultCellStyle.Padding            = new Padding(4, 0, 4, 0);

            // Linhas alternadas
            dgvSocios.AlternatingRowsDefaultCellStyle.BackColor          = CorGridAlt;
            dgvSocios.AlternatingRowsDefaultCellStyle.SelectionBackColor = CorSelecao;
            dgvSocios.AlternatingRowsDefaultCellStyle.SelectionForeColor = CorSelecaoTxt;

            // Header
            dgvSocios.ColumnHeadersDefaultCellStyle.BackColor  = CorGridHeader;
            dgvSocios.ColumnHeadersDefaultCellStyle.ForeColor  = CorLabel;
            dgvSocios.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvSocios.ColumnHeadersDefaultCellStyle.Padding    = new Padding(4, 0, 4, 0);
            dgvSocios.ColumnHeadersBorderStyle                 = DataGridViewHeaderBorderStyle.None;
            dgvSocios.ColumnHeadersHeight                      = 36;
            dgvSocios.RowTemplate.Height                       = 32;

            _cardTabela.Controls.Add(dgvSocios);
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
                Size      = new Size(FormW, 20),
                Location  = new Point(0, FormH - 22),
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        // ─────────────────────────────────────────────────────────────
        // PAINT HANDLERS
        // ─────────────────────────────────────────────────────────────
        private void PicLogo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            FillRounded(g, new SolidBrush(CorVerde),
                new Rectangle(0, 0, 44, 44), 10);
            FillRounded(g, new SolidBrush(CorVerdeClaro),
                new Rectangle(6, 19, 32, 5), 2);
            FillRounded(g, Brushes.White,
                new Rectangle(6, 13, 7, 17), 2);
            FillRounded(g, Brushes.White,
                new Rectangle(31, 13, 7, 17), 2);
            FillRounded(g, new SolidBrush(ColorTranslator.FromHtml("#A8F0C0")),
                new Rectangle(17, 17, 10, 10), 2);
        }

        private void LblNome_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var fnt   = new Font("Segoe UI", 15F, FontStyle.Bold);
            using var verde = new SolidBrush(CorVerdeClaro);
            float x = 0;
            g.DrawString("Fit", fnt, Brushes.White, x, 2);
            x += g.MeasureString("Fit", fnt).Width - 3;
            g.DrawString("Manager", fnt, verde, x, 2);
        }

        // ─────────────────────────────────────────────────────────────
        // DADOS
        // ─────────────────────────────────────────────────────────────
        private void CarregarTabela()
        {
            listaSocios = SocioRepository.CarregarTodosSocios();
            dgvSocios.DataSource = null;
            dgvSocios.DataSource = listaSocios;

            // Renomear colunas para português
            if (dgvSocios.Columns.Count > 0)
            {
                if (dgvSocios.Columns["Id"]            != null) dgvSocios.Columns["Id"].HeaderText           = "ID";
                if (dgvSocios.Columns["Nome"]          != null) dgvSocios.Columns["Nome"].HeaderText         = "Nome";
                if (dgvSocios.Columns["Nif"]           != null) dgvSocios.Columns["Nif"].HeaderText          = "NIF";
                if (dgvSocios.Columns["Telefone"]      != null) dgvSocios.Columns["Telefone"].HeaderText     = "Telefone";
                if (dgvSocios.Columns["DataInscricao"] != null) dgvSocios.Columns["DataInscricao"].HeaderText = "Inscrição";
                if (dgvSocios.Columns["PlanoId"]       != null) dgvSocios.Columns["PlanoId"].HeaderText      = "Plano";
                if (dgvSocios.Columns["EstadoAtivo"]   != null) dgvSocios.Columns["EstadoAtivo"].HeaderText  = "Estado";

                // Larguras fixas por coluna
                dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                void SetCol(string colName, int w) { if (dgvSocios.Columns[colName] != null) dgvSocios.Columns[colName].Width = w; }
                SetCol("Id",             50);
                SetCol("Nome",          200);
                SetCol("Nif",           110);
                SetCol("Telefone",      110);
                SetCol("DataInscricao", 110);
                SetCol("PlanoId",        60);
                SetCol("EstadoAtivo",    70);
                if (dgvSocios.Columns["PlanoEscolhido"] != null) dgvSocios.Columns["PlanoEscolhido"].Visible = false;
            }

            // Atualizar contador
            var lblCount = _cardTabela.Controls["lblCount"] as Label;
            if (lblCount != null)
                lblCount.Text = $"{listaSocios.Count} sócio(s) registado(s)";
        }

        // ─────────────────────────────────────────────────────────────
        // EVENTOS ORIGINAIS (sem alterações)
        // ─────────────────────────────────────────────────────────────
        private void ListarSocio_Load(object sender, EventArgs e)
        {
            CarregarTabela();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            string busca = txtBusca.Text.Trim();
            if (string.IsNullOrEmpty(busca)) return;

            Socio socio = SocioRepository.BuscarSocioPorNifOuId(busca);
            if (socio == null)
            {
                MessageBox.Show("NIF ou ID não encontrado no sistema.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _cardDetalhes.Visible = false;
                return;
            }

            lblId.Text       = socio.Id.ToString();
            lblNome.Text     = socio.Nome;
            lblNif.Text      = socio.Nif;
            lblTelefone.Text = socio.Telefone;
            lblDataInsc.Text = socio.DataInscricao.ToShortDateString();
            lblPlano.Text    = socio.PlanoId.ToString();

            _cardDetalhes.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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
