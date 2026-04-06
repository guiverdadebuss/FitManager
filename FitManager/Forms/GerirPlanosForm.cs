using FitManager.Data;
using FitManager.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class GerirPlanosForm : Form
    {
        // ── Paleta FitManager ─────────────────────────────────────────
        private static readonly Color CorEscura = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorVerde = ColorTranslator.FromHtml("#1A8A42");
        private static readonly Color CorVerdeClaro = ColorTranslator.FromHtml("#2ECC71");
        private static readonly Color CorVermelho = ColorTranslator.FromHtml("#C0392B");
        private static readonly Color CorVermelhoH = ColorTranslator.FromHtml("#922B21");
        private static readonly Color CorAmbar = ColorTranslator.FromHtml("#D4AC0D");
        private static readonly Color CorAmbarH = ColorTranslator.FromHtml("#9A7D0A");
        private static readonly Color CorFundo = ColorTranslator.FromHtml("#F0F4F1");
        private static readonly Color CorBorda = ColorTranslator.FromHtml("#C8D8C8");
        private static readonly Color CorLabel = ColorTranslator.FromHtml("#4A7A5A");
        private static readonly Color CorInputFundo = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorTexto = ColorTranslator.FromHtml("#0F2A1A");
        private static readonly Color CorSubtexto = ColorTranslator.FromHtml("#6A8870");
        private static readonly Color CorGridAlt = ColorTranslator.FromHtml("#F7FAF7");
        private static readonly Color CorSelecao = ColorTranslator.FromHtml("#D6EEE0");

        private const int FormW = 1000;
        private const int FormH = 620;
        private const int HeaderH = 70;
        private const int Pad = 20;
        private const int FormW_Card = 320; // largura do card lateral de formulário

        private Panel _picLogo;
        private Label _lblNomeHeader;
        private Panel _cardForm;
        private Panel _cardTabela;

        private Plano _planoSelecionado = null;

        public GerirPlanosForm()
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
            CriarCardTabela();
            CriarCardFormulario();
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
                Size = new Size(40, 40),
                Location = new Point(Pad, 14),
                BackColor = Color.Transparent
            };
            _picLogo.Paint += PicLogo_Paint;

            _lblNomeHeader = new Label
            {
                AutoSize = false,
                Size = new Size(220, 30),
                Location = new Point(Pad + 50, 18),
                BackColor = Color.Transparent
            };
            _lblNomeHeader.Paint += LblNome_Paint;

            var lblPagina = new Label
            {
                Text = "Planos de Subscrição",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(280, 44),
                Location = new Point(FormW - 300, 12),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent
            };

            var accent = new Panel
            {
                BackColor = CorVerdeClaro,
                Size = new Size(FormW, 3),
                Location = new Point(0, HeaderH - 3)
            };

            header.Controls.Add(_picLogo);
            header.Controls.Add(_lblNomeHeader);
            header.Controls.Add(lblPagina);
            header.Controls.Add(accent);
            this.Controls.Add(header);
        }

        // ── 2. Card da tabela (lado esquerdo) ─────────────────────────
        private void CriarCardTabela()
        {
            int tabelaX = Pad;
            int tabelaY = HeaderH + Pad;
            int tabelaW = FormW - FormW_Card - Pad * 3;
            int tabelaH = FormH - tabelaY - 30;

            _cardTabela = new Panel
            {
                Location = new Point(tabelaX, tabelaY),
                Size = new Size(tabelaW, tabelaH),
                BackColor = Color.White
            };
            _cardTabela.Paint += (s, e) =>
                e.Graphics.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardTabela.Width - 1, _cardTabela.Height - 1));

            _cardTabela.Controls.Add(new Label
            {
                Text = "Planos disponíveis",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize = false,
                Size = new Size(tabelaW - 24, 30),
                Location = new Point(12, 8),
                TextAlign = ContentAlignment.MiddleLeft
            });
            _cardTabela.Controls.Add(new Label
            {
                Text = "Clique numa linha para editar o plano",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize = false,
                Size = new Size(tabelaW - 24, 18),
                Location = new Point(12, 36),
                TextAlign = ContentAlignment.MiddleLeft
            });
            _cardTabela.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size = new Size(tabelaW - 24, 1),
                Location = new Point(12, 56)
            });

            // DataGridView
            this.Controls.Remove(dgvPlanos);
            dgvPlanos.Location = new Point(0, 60);
            dgvPlanos.Size = new Size(tabelaW, tabelaH - 60);
            dgvPlanos.Visible = true;
            dgvPlanos.BorderStyle = BorderStyle.None;
            dgvPlanos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPlanos.GridColor = CorBorda;
            dgvPlanos.BackgroundColor = Color.White;
            dgvPlanos.RowHeadersVisible = false;
            dgvPlanos.AllowUserToAddRows = false;
            dgvPlanos.AllowUserToDeleteRows = false;
            dgvPlanos.ReadOnly = true;
            dgvPlanos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlanos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlanos.EnableHeadersVisualStyles = false;
            dgvPlanos.Font = new Font("Segoe UI", 9F);
            dgvPlanos.DefaultCellStyle.BackColor = Color.White;
            dgvPlanos.DefaultCellStyle.ForeColor = CorTexto;
            dgvPlanos.DefaultCellStyle.SelectionBackColor = CorSelecao;
            dgvPlanos.DefaultCellStyle.SelectionForeColor = CorTexto;
            dgvPlanos.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvPlanos.AlternatingRowsDefaultCellStyle.BackColor = CorGridAlt;
            dgvPlanos.AlternatingRowsDefaultCellStyle.SelectionBackColor = CorSelecao;
            dgvPlanos.ColumnHeadersDefaultCellStyle.BackColor = CorFundo;
            dgvPlanos.ColumnHeadersDefaultCellStyle.ForeColor = CorLabel;
            dgvPlanos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvPlanos.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvPlanos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPlanos.ColumnHeadersHeight = 36;
            dgvPlanos.RowTemplate.Height = 34;
            _cardTabela.Controls.Add(dgvPlanos);

            this.Controls.Add(_cardTabela);
        }

        // ── 3. Card do formulário (lado direito) ──────────────────────
        private void CriarCardFormulario()
        {
            int formX = FormW - FormW_Card - Pad;
            int formY = HeaderH + Pad;
            int formH = FormH - formY - 30;

            _cardForm = new Panel
            {
                Location = new Point(formX, formY),
                Size = new Size(FormW_Card, formH),
                BackColor = Color.White
            };
            _cardForm.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.DrawRectangle(new Pen(CorBorda, 1),
                    new Rectangle(0, 0, _cardForm.Width - 1, _cardForm.Height - 1));
                // Faixa verde no topo do card
                g.FillRectangle(new SolidBrush(CorVerde),
                    new Rectangle(0, 0, _cardForm.Width, 5));
            };

            int innerW = FormW_Card - 32; // largura interior com padding

            _cardForm.Controls.Add(new Label
            {
                Text = "Detalhes do Plano",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = CorTexto,
                AutoSize = false,
                Size = new Size(FormW_Card, 28),
                Location = new Point(0, 18),
                TextAlign = ContentAlignment.MiddleCenter
            });
            _cardForm.Controls.Add(new Label
            {
                Text = "Preencha os campos abaixo",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CorSubtexto,
                AutoSize = false,
                Size = new Size(FormW_Card, 16),
                Location = new Point(0, 48),
                TextAlign = ContentAlignment.MiddleCenter
            });
            _cardForm.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size = new Size(FormW_Card - 32, 1),
                Location = new Point(16, 72)
            });

            // ── Campos do formulário ──────────────────────────────────
            int y = 88;

            // Nome
            _cardForm.Controls.Add(MakeLabel("Nome do Plano", new Point(16, y)));
            this.Controls.Remove(txtNome);
            txtNome.Location = new Point(16, y + 20);
            txtNome.Size = new Size(innerW, 30);
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.BackColor = CorInputFundo;
            txtNome.ForeColor = CorTexto;
            txtNome.Visible = true;
            txtNome.Enter += (s, e) => txtNome.BackColor = Color.White;
            txtNome.Leave += (s, e) => txtNome.BackColor = CorInputFundo;
            _cardForm.Controls.Add(txtNome);
            y += 62;

            // Preço
            _cardForm.Controls.Add(MakeLabel("Preço Mensal (€)", new Point(16, y)));
            this.Controls.Remove(txtPreco);
            txtPreco.Location = new Point(16, y + 20);
            txtPreco.Size = new Size(innerW, 30);
            txtPreco.Font = new Font("Segoe UI", 10F);
            txtPreco.BorderStyle = BorderStyle.FixedSingle;
            txtPreco.BackColor = CorInputFundo;
            txtPreco.ForeColor = CorTexto;
            txtPreco.Visible = true;
            txtPreco.Enter += (s, e) => txtPreco.BackColor = Color.White;
            txtPreco.Leave += (s, e) => txtPreco.BackColor = CorInputFundo;
            _cardForm.Controls.Add(txtPreco);
            y += 62;

            // Descrição
            _cardForm.Controls.Add(MakeLabel("Descrição", new Point(16, y)));
            this.Controls.Remove(txtDescricao);
            txtDescricao.Location = new Point(16, y + 20);
            txtDescricao.Size = new Size(innerW, 72);
            txtDescricao.Font = new Font("Segoe UI", 10F);
            txtDescricao.BorderStyle = BorderStyle.FixedSingle;
            txtDescricao.BackColor = CorInputFundo;
            txtDescricao.ForeColor = CorTexto;
            txtDescricao.Multiline = true;
            txtDescricao.Visible = true;
            txtDescricao.Enter += (s, e) => txtDescricao.BackColor = Color.White;
            txtDescricao.Leave += (s, e) => txtDescricao.BackColor = CorInputFundo;
            _cardForm.Controls.Add(txtDescricao);
            y += 108;

            // ── Separador antes dos botões ────────────────────────────
            _cardForm.Controls.Add(new Panel
            {
                BackColor = CorBorda,
                Size = new Size(FormW_Card - 32, 1),
                Location = new Point(16, y)
            });
            y += 14;

            // ── Botão Gravar / Atualizar ──────────────────────────────
            this.Controls.Remove(btnGravar);
            btnGravar.Location = new Point(16, y);
            btnGravar.Size = new Size(innerW, 40);
            btnGravar.FlatStyle = FlatStyle.Flat;
            btnGravar.BackColor = CorVerde;
            btnGravar.ForeColor = Color.White;
            btnGravar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGravar.Text = "Criar Novo Plano";
            btnGravar.Cursor = Cursors.Hand;
            btnGravar.Visible = true;
            btnGravar.FlatAppearance.BorderSize = 0;
            btnGravar.MouseEnter += (s, e) => btnGravar.BackColor = ColorTranslator.FromHtml("#0F6032");
            btnGravar.MouseLeave += (s, e) => btnGravar.BackColor = CorVerde;
            _cardForm.Controls.Add(btnGravar);
            y += 48;

            // ── Botão Limpar ──────────────────────────────────────────
            this.Controls.Remove(btnNovo);
            btnNovo.Location = new Point(16, y);
            btnNovo.Size = new Size(innerW, 36);
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.BackColor = CorFundo;
            btnNovo.ForeColor = CorLabel;
            btnNovo.Font = new Font("Segoe UI", 9F);
            btnNovo.Text = "Limpar Campos";
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.Visible = true;
            btnNovo.FlatAppearance.BorderColor = CorBorda;
            btnNovo.FlatAppearance.BorderSize = 1;
            btnNovo.MouseEnter += (s, e) => btnNovo.BackColor = ColorTranslator.FromHtml("#E0EAE0");
            btnNovo.MouseLeave += (s, e) => btnNovo.BackColor = CorFundo;
            _cardForm.Controls.Add(btnNovo);
            y += 44;

            // ── Botão Remover ─────────────────────────────────────────
            this.Controls.Remove(btnRemover);
            btnRemover.Location = new Point(16, y);
            btnRemover.Size = new Size(innerW, 36);
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.BackColor = Color.White;
            btnRemover.ForeColor = CorVermelho;
            btnRemover.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemover.Text = "✕  Remover Plano";
            btnRemover.Cursor = Cursors.Hand;
            btnRemover.Visible = true;
            btnRemover.FlatAppearance.BorderColor = CorVermelho;
            btnRemover.FlatAppearance.BorderSize = 1;
            btnRemover.MouseEnter += (s, e) => { btnRemover.BackColor = CorVermelho; btnRemover.ForeColor = Color.White; };
            btnRemover.MouseLeave += (s, e) => { btnRemover.BackColor = Color.White; btnRemover.ForeColor = CorVermelho; };
            _cardForm.Controls.Add(btnRemover);

            this.Controls.Add(_cardForm);
        }

        // ── 4. Rodapé ─────────────────────────────────────────────────
        private void CriarRodape()
        {
            this.Controls.Add(new Label
            {
                Text = "© 2025 FitManager · Todos os direitos reservados",
                ForeColor = ColorTranslator.FromHtml("#7A9A7A"),
                Font = new Font("Segoe UI", 8F),
                AutoSize = false,
                Size = new Size(FormW, 22),
                Location = new Point(0, FormH - 24),
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
            FillRounded(g, new SolidBrush(CorVerde), new Rectangle(0, 0, 40, 40), 9);
            FillRounded(g, new SolidBrush(CorVerdeClaro), new Rectangle(5, 18, 30, 5), 2);
            FillRounded(g, Brushes.White, new Rectangle(5, 12, 6, 16), 2);
            FillRounded(g, Brushes.White, new Rectangle(29, 12, 6, 16), 2);
            FillRounded(g, new SolidBrush(ColorTranslator.FromHtml("#A8F0C0")),
                new Rectangle(15, 16, 10, 9), 2);
        }

        private void LblNome_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var fnt = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var verde = new SolidBrush(CorVerdeClaro);
            float x = 0;
            g.DrawString("Fit", fnt, Brushes.White, x, 4);
            x += g.MeasureString("Fit", fnt).Width - 3;
            g.DrawString("Manager", fnt, verde, x, 4);
        }

        // ─────────────────────────────────────────────────────────────
        // HELPER
        // ─────────────────────────────────────────────────────────────
        private static Label MakeLabel(string text, Point loc) => new Label
        {
            Text = text,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = CorLabel,
            AutoSize = false,
            Size = new Size(286, 16),
            Location = loc
        };

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

        // ─────────────────────────────────────────────────────────────
        // LÓGICA ORIGINAL (sem alterações)
        // ─────────────────────────────────────────────────────────────
        private void GerirPlanosForm_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        private void AtualizarTabela()
        {
            dgvPlanos.DataSource = null;
            dgvPlanos.DataSource = SocioRepository.ObterTodosPlanos();

            if (dgvPlanos.Columns.Count > 0)
            {
                if (dgvPlanos.Columns["Id"] != null) { dgvPlanos.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; dgvPlanos.Columns["Id"].Width = 50; }
                if (dgvPlanos.Columns["Nome"] != null) dgvPlanos.Columns["Nome"].HeaderText = "Nome";
                if (dgvPlanos.Columns["PrecoMensal"] != null) dgvPlanos.Columns["PrecoMensal"].HeaderText = "Preço Mensal (€)";
                if (dgvPlanos.Columns["Descricao"] != null) dgvPlanos.Columns["Descricao"].HeaderText = "Descrição";
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) return;
            try
            {
                Plano p = new Plano
                {
                    Id = _planoSelecionado?.Id ?? 0,
                    Nome = txtNome.Text.Trim(),
                    PrecoMensal = decimal.Parse(txtPreco.Text),
                    Descricao = txtDescricao.Text.Trim()
                };

                bool sucesso = p.Id == 0
                    ? SocioRepository.InserirPlano(p)
                    : SocioRepository.EditarPlano(p);

                if (sucesso)
                {
                    MessageBox.Show("Plano guardado!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    AtualizarTabela();
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
        }

        private void dgvPlanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _planoSelecionado = (Plano)dgvPlanos.Rows[e.RowIndex].DataBoundItem;
                txtNome.Text = _planoSelecionado.Nome;
                txtPreco.Text = _planoSelecionado.PrecoMensal.ToString();
                txtDescricao.Text = _planoSelecionado.Descricao;
                btnGravar.Text = "Atualizar Plano";
                btnGravar.BackColor = CorAmbar;
                btnGravar.MouseEnter += (s, ev) => btnGravar.BackColor = CorAmbarH;
                btnGravar.MouseLeave += (s, ev) => btnGravar.BackColor = CorAmbar;
            }
        }

        private void LimparCampos()
        {
            _planoSelecionado = null;
            txtNome.Clear();
            txtPreco.Clear();
            txtDescricao.Clear();
            btnGravar.Text = "Criar Novo Plano";
            btnGravar.BackColor = CorVerde;
            txtNome.Focus();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (_planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano na tabela primeiro.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show(
                $"Tem a certeza que deseja eliminar o plano '{_planoSelecionado.Nome}'?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    if (SocioRepository.RemoverPlano(_planoSelecionado.Id))
                    {
                        MessageBox.Show("Plano removido com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        AtualizarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao Remover",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}