using FitManager.Data;
using FitManager.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class EliminarSocio : Form
    {
        // ── Paleta FitManager ─────────────────────────────────────────
        private static readonly Color CorEscura = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorVerde = ColorTranslator.FromHtml("#1A8A42");
        private static readonly Color CorVerdeClaro = ColorTranslator.FromHtml("#2ECC71");
        private static readonly Color CorVermelho = ColorTranslator.FromHtml("#C0392B");
        private static readonly Color CorVermelhoH = ColorTranslator.FromHtml("#922B21");
        private static readonly Color CorFundo = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorBorda = ColorTranslator.FromHtml("#C8D8C8");
        private static readonly Color CorLabel = ColorTranslator.FromHtml("#4A7A5A");
        private static readonly Color CorInputFundo = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorTexto = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorSubtexto = ColorTranslator.FromHtml("#6A8870");

        private const int FormW = 460;
        private const int FormH = 560;
        private const int HeaderH = 130;
        private const int CardX = 50;
        private const int CardW = 360;
        private const int Pad = 32;

        // Referências a controlos criados em código
        private Panel _picLogo;
        private Label _lblNomeHeader;
        private Panel _cardPesquisa;
        private Panel _cardDetalhes;

        // Labels de valor dentro do card de detalhes
        private Label _valNome;
        private Label _valNif;
        private Label _valTelefone;
        private Label _valEstado;
        private Label _valData;

        private Socio socioEncontrado;

        public EliminarSocio()
        {
            InitializeComponent();
            this.ClientSize = new Size(FormW, FormH);
            this.BackColor = CorFundo;
            this.Font = new Font("Segoe UI", 9.5F);
            ConstruirUI();
        }

        // ─────────────────────────────────────────────────────────────
        // CONSTRUÇÃO DA UI
        // ─────────────────────────────────────────────────────────────
        private void ConstruirUI()
        {
            CriarHeader();
            CriarCardPesquisa();
            CriarCardDetalhes();
            CriarBotaoEliminar();
            CriarRodape();
        }

        // ── 1. Header ─────────────────────────────────────────────────
        private void CriarHeader()
        {
            var header = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(FormW, HeaderH),
                BackColor = CorEscura
            };

            _picLogo = new Panel
            {
                Size = new Size(52, 52),
                Location = new Point(124, 32),
                BackColor = Color.Transparent
            };
            _picLogo.Paint += PicLogo_Paint;

            _lblNomeHeader = new Label
            {
                AutoSize = false,
                Size = new Size(230, 36),
                Location = new Point(184, 26),
                BackColor = Color.Transparent
            };
            _lblNomeHeader.Paint += LblNomeHeader_Paint;

            var lblTag = new Label
            {
                Text = "GESTÃO DE GINÁSIO",
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(110, 255, 255, 255),
                AutoSize = false,
                Size = new Size(230, 16),
                Location = new Point(186, 64),
                BackColor = Color.Transparent
            };

            var accent = new Panel
            {
                BackColor = CorVerdeClaro,
                Size = new Size(40, 3),
                Location = new Point(210, 106)
            };

            header.Controls.Add(_picLogo);
            header.Controls.Add(_lblNomeHeader);
            header.Controls.Add(lblTag);
            header.Controls.Add(accent);
            this.Controls.Add(header);
        }

        // ── 2. Card de pesquisa ───────────────────────────────────────
        private void CriarCardPesquisa()
        {
            _cardPesquisa = new Panel
            {
                Location = new Point(CardX, HeaderH + 20),
                Size = new Size(CardW, 120),
                BackColor = Color.White
            };
            _cardPesquisa.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardPesquisa.Width - 1, _cardPesquisa.Height - 1));

            _cardPesquisa.Controls.Add(new Label
            {
                Text = "Pesquisar Sócio",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize = false,
                Size = new Size(CardW, 28),
                Location = new Point(0, 14),
                TextAlign = ContentAlignment.MiddleCenter
            });
            _cardPesquisa.Controls.Add(new Label
            {
                Text = "Introduza o ID ou NIF do sócio",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize = false,
                Size = new Size(CardW, 16),
                Location = new Point(0, 42),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // TextBox pesquisa
            this.Controls.Remove(txtPesquisa);
            txtPesquisa.Location = new Point(Pad, 68);
            txtPesquisa.Size = new Size(CardW - Pad * 2 - 110, 30);
            txtPesquisa.Font = new Font("Segoe UI", 10F);
            txtPesquisa.BorderStyle = BorderStyle.FixedSingle;
            txtPesquisa.BackColor = CorInputFundo;
            txtPesquisa.ForeColor = CorTexto;
            txtPesquisa.Visible = true;
            txtPesquisa.Enter += (s, e) => txtPesquisa.BackColor = Color.White;
            txtPesquisa.Leave += (s, e) => txtPesquisa.BackColor = CorInputFundo;
            _cardPesquisa.Controls.Add(txtPesquisa);

            // Botão Pesquisar
            this.Controls.Remove(btnPesquisar);
            btnPesquisar.Location = new Point(CardW - Pad - 100, 68);
            btnPesquisar.Size = new Size(100, 30);
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.BackColor = CorVerde;
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.Cursor = Cursors.Hand;
            btnPesquisar.Visible = true;
            btnPesquisar.FlatAppearance.BorderSize = 0;
            btnPesquisar.MouseEnter += (s, e) => btnPesquisar.BackColor = ColorTranslator.FromHtml("#0F6032");
            btnPesquisar.MouseLeave += (s, e) => btnPesquisar.BackColor = CorVerde;
            _cardPesquisa.Controls.Add(btnPesquisar);

            this.Controls.Add(_cardPesquisa);
        }

        // ── 3. Card de detalhes do sócio ──────────────────────────────
        private void CriarCardDetalhes()
        {
            int cardDetalheY = HeaderH + 20 + 120 + 16;

            _cardDetalhes = new Panel
            {
                Location = new Point(CardX, cardDetalheY),
                Size = new Size(CardW, 210),
                BackColor = Color.White,
                Visible = false   // só aparece após pesquisa
            };
            _cardDetalhes.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardDetalhes.Width - 1, _cardDetalhes.Height - 1));

            _cardDetalhes.Controls.Add(new Label
            {
                Text = "Dados do Sócio",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize = false,
                Size = new Size(CardW, 26),
                Location = new Point(0, 14),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Linha de separação
            var sep = new Panel
            {
                BackColor = CorBorda,
                Size = new Size(CardW - Pad * 2, 1),
                Location = new Point(Pad, 46)
            };
            _cardDetalhes.Controls.Add(sep);

            // Linhas de dados: label chave + label valor
            var campos = new[]
            {
                ("Nome",        lblNome),
                ("NIF",         lblNif),
                ("Telefone",    lblTelefone),
                ("Estado",      lblEstado),
                ("Inscrição",   lblData)
            };

            int y = 58;
            foreach (var (chave, lblValor) in campos)
            {
                // Chave (ex: "Nome")
                _cardDetalhes.Controls.Add(new Label
                {
                    Text = chave,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    ForeColor = CorLabel,
                    AutoSize = false,
                    Size = new Size(100, 22),
                    Location = new Point(Pad, y),
                    TextAlign = ContentAlignment.MiddleLeft
                });

                // Valor (labels do Designer reutilizados)
                this.panelDetalhes.Controls.Remove(lblValor);
                lblValor.Font = new Font("Segoe UI", 9.5F);
                lblValor.ForeColor = CorTexto;
                lblValor.AutoSize = false;
                lblValor.Size = new Size(CardW - Pad - 110, 22);
                lblValor.Location = new Point(Pad + 110, y);
                lblValor.TextAlign = ContentAlignment.MiddleLeft;
                _cardDetalhes.Controls.Add(lblValor);

                y += 28;
            }

            this.Controls.Add(_cardDetalhes);

            // Remove o panelDetalhes original do Designer (já não é necessário)
            this.panelDetalhes.Visible = false;
        }

        // ── 4. Botão Eliminar ─────────────────────────────────────────
        private void CriarBotaoEliminar()
        {
            // Separador
            this.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size = new Size(CardW, 1),
                Location = new Point(CardX, FormH - 80)
            });

            this.Controls.Remove(btnEliminar);
            btnEliminar.Location = new Point(CardX, FormH - 68);
            btnEliminar.Size = new Size(CardW, 44);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.BackColor = CorVermelho;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnEliminar.Text = "✕   Eliminar Sócio";
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Enabled = false;
            btnEliminar.Visible = true;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.MouseEnter += (s, e) => { if (btnEliminar.Enabled) btnEliminar.BackColor = CorVermelhoH; };
            btnEliminar.MouseLeave += (s, e) => { if (btnEliminar.Enabled) btnEliminar.BackColor = CorVermelho; };
            this.Controls.Add(btnEliminar);
        }

        // ── 5. Rodapé ─────────────────────────────────────────────────
        private void CriarRodape()
        {
            this.Controls.Add(new Label
            {
                Text = "© 2025 FitManager · Todos os direitos reservados",
                ForeColor = ColorTranslator.FromHtml("#7A9A7A"),
                Font = new Font("Segoe UI", 8F),
                AutoSize = false,
                Size = new Size(FormW, 20),
                Location = new Point(0, FormH - 22),
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
            FillRounded(g, new SolidBrush(CorVerde), new Rectangle(0, 0, 52, 52), 12);
            FillRounded(g, new SolidBrush(CorVerdeClaro), new Rectangle(7, 23, 38, 6), 3);
            FillRounded(g, Brushes.White, new Rectangle(7, 16, 8, 20), 3);
            FillRounded(g, Brushes.White, new Rectangle(37, 16, 8, 20), 3);
            FillRounded(g, new SolidBrush(ColorTranslator.FromHtml("#A8F0C0")),
                new Rectangle(20, 20, 12, 12), 2);
        }

        private void LblNomeHeader_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
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

        // ─────────────────────────────────────────────────────────────
        // LÓGICA ORIGINAL (sem alterações)
        // ─────────────────────────────────────────────────────────────
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisa.Text.Trim();

            if (string.IsNullOrEmpty(termo))
            {
                MessageBox.Show("Introduza o ID ou NIF.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            socioEncontrado = SocioRepository.BuscarSocioPorNifOuId(termo);

            if (socioEncontrado == null)
            {
                MessageBox.Show("Nenhum sócio encontrado.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _cardDetalhes.Visible = false;
                btnEliminar.Enabled = false;
                return;
            }

            // Preencher labels
            lblNome.Text = socioEncontrado.Nome;
            lblNif.Text = socioEncontrado.Nif;
            lblTelefone.Text = socioEncontrado.Telefone;
            lblEstado.Text = socioEncontrado.EstadoAtivo ? "Ativo" : "Inativo";
            lblData.Text = socioEncontrado.DataInscricao.ToShortDateString();

            // Colorir o estado
            lblEstado.ForeColor = socioEncontrado.EstadoAtivo ? CorVerde : CorVermelho;
            lblEstado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            _cardDetalhes.Visible = true;
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (socioEncontrado == null)
                return;

            var confirm = MessageBox.Show(
                $"Tem a certeza que deseja eliminar o sócio {socioEncontrado.Nome}?",
                "Confirmar eliminação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool eliminado = SocioRepository.EliminarSocio(socioEncontrado.Id.ToString());

                if (eliminado)
                {
                    MessageBox.Show("Sócio eliminado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao eliminar sócio.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void EliminarSocio_Load(object sender, EventArgs e) { }

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