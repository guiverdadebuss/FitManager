using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class CriarNovoSocio : Form
    {
        // ── Paleta de cores ──────────────────────────────────────────
        private readonly Color corPrimaria = ColorTranslator.FromHtml("#1E3A5F");
        private readonly Color corDestaque = ColorTranslator.FromHtml("#2D6A9F");
        private readonly Color corFundo = ColorTranslator.FromHtml("#F4F6F8");
        private readonly Color corBorda = ColorTranslator.FromHtml("#D0D7DE");
        private readonly Color corSucesso = ColorTranslator.FromHtml("#2ECC71");
        private readonly Color corTextoLabel = ColorTranslator.FromHtml("#5A6A7E");

        public CriarNovoSocio()
        {
            InitializeComponent();
            AplicarEstilo();
        }

        private void AplicarEstilo()
        {
            // ── Form ─────────────────────────────────────────────────
            this.Text = "Criar Novo Sócio";
            this.BackColor = corFundo;
            this.Font = new Font("Segoe UI", 9.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(480, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Padding = new Padding(0);

            // ── Panel do cabeçalho ────────────────────────────────────
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                BackColor = corPrimaria,
                Padding = new Padding(24, 0, 0, 0)
            };

            var lblTitulo = new Label
            {
                Text = "Novo Sócio",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblSubtitulo = new Label
            {
                Text = "Preencha os dados do novo sócio",
                ForeColor = Color.FromArgb(180, 255, 255, 255),
                Font = new Font("Segoe UI", 8.5F),
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Height = 22,
                TextAlign = ContentAlignment.BottomLeft,
                Padding = new Padding(24, 0, 0, 6)
            };

            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblSubtitulo);

            // ── Panel do conteúdo ─────────────────────────────────────
            var panelBody = new Panel
            {
                BackColor = Color.White,
                Size = new Size(400, 310),
                Location = new Point(40, 88),
                Padding = new Padding(24)
            };
            panelBody.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, panelBody.Width - 1, panelBody.Height - 1);
                e.Graphics.DrawRectangle(new Pen(corBorda, 1), rect);
            };

            // ── Campos do formulário ──────────────────────────────────
            int y = 24;
            var campos = new[]
            {
                ("Nome",     "Ex: João Silva"),
                ("NIF",      "Ex: 123456789"),
                ("Telefone", "Ex: 912 345 678"),
                ("Plano ID", "Ex: 1")
            };

            var inputs = new TextBox[campos.Length];

            for (int i = 0; i < campos.Length; i++)
            {
                var (nome, placeholder) = campos[i];

                var lbl = new Label
                {
                    Text = nome,
                    Location = new Point(24, y),
                    Size = new Size(340, 18),
                    ForeColor = corTextoLabel,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                };

                var txt = new TextBox
                {
                    Location = new Point(24, y + 22),
                    Size = new Size(352, 32),
                    Font = new Font("Segoe UI", 10F),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = ColorTranslator.FromHtml("#F8FAFC"),
                    ForeColor = ColorTranslator.FromHtml("#1E3A5F"),
                    Tag = placeholder
                };

                // Placeholder simulado
                txt.Text = placeholder;
                txt.ForeColor = corBorda;
                txt.GotFocus += (s, e) =>
                {
                    var t = (TextBox)s;
                    if (t.Text == (string)t.Tag) { t.Text = ""; t.ForeColor = ColorTranslator.FromHtml("#1E3A5F"); }
                };
                txt.LostFocus += (s, e) =>
                {
                    var t = (TextBox)s;
                    if (string.IsNullOrWhiteSpace(t.Text)) { t.Text = (string)t.Tag; t.ForeColor = corBorda; }
                };

                // Foco — borda azul
                txt.Enter += (s, e) => ((TextBox)s).BackColor = Color.White;
                txt.Leave += (s, e) => ((TextBox)s).BackColor = ColorTranslator.FromHtml("#F8FAFC");

                inputs[i] = txt;
                panelBody.Controls.Add(lbl);
                panelBody.Controls.Add(txt);
                y += 72;
            }

            // ── Botões ────────────────────────────────────────────────
            var btnGuardar = CriarBotao("Guardar Sócio", new Point(40, 416), corDestaque, Color.White);
            btnGuardar.Size = new Size(192, 40);
            btnGuardar.Click += BtnGuardar_Click;

            var btnCancelar = CriarBotaoCancelar("Cancelar", new Point(248, 416));
            btnCancelar.Size = new Size(192, 40);
            btnCancelar.Click += (s, e) => this.Close();

            // ── Linha separadora ──────────────────────────────────────
            var separator = new Panel
            {
                BackColor = corBorda,
                Size = new Size(400, 1),
                Location = new Point(40, 400)
            };

            // ── Adicionar ao Form ─────────────────────────────────────
            this.Controls.Add(panelHeader);
            this.Controls.Add(panelBody);
            this.Controls.Add(separator);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }

        // ── Helpers para criar botões ─────────────────────────────────
        private Button CriarBotao(string texto, Point loc, Color fundo, Color texto_cor)
        {
            var btn = new Button
            {
                Text = texto,
                Location = loc,
                FlatStyle = FlatStyle.Flat,
                BackColor = fundo,
                ForeColor = texto_cor,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = corPrimaria;
            btn.MouseLeave += (s, e) => btn.BackColor = fundo;
            return btn;
        }

        private Button CriarBotaoCancelar(string texto, Point loc)
        {
            var btn = new Button
            {
                Text = texto,
                Location = loc,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = corDestaque,
                Font = new Font("Segoe UI", 9.5F),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = corBorda;
            btn.MouseEnter += (s, e) => { btn.BackColor = corFundo; };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.White; };
            return btn;
        }

        // ── Eventos ───────────────────────────────────────────────────
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // A tua lógica de guardar vai aqui
            MessageBox.Show("Sócio criado com sucesso!", "FitManager",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CriarNovoSocio_Load(object sender, EventArgs e) { }
    }
}