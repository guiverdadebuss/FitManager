using FitManager.Models;
using FitManager.Data;

namespace FitManager.Forms
{
    public partial class NovoSocio : Form
    {
        public NovoSocio()
        {
            InitializeComponent();
        }

        private void NovoSocio_Load(object sender, EventArgs e)
        {
            CarregarPlanos();
        }

        private void CarregarPlanos()
        {
            try
            {
                var planos = SocioRepository.ObterTodosPlanos();
                cboPlano.DataSource = null; 
                cboPlano.DataSource = planos;
                cboPlano.DisplayMember = "Nome";
                cboPlano.ValueMember = "Id";
                cboPlano.SelectedIndex = -1;    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar planos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtNif.Text))
            {
                MessageBox.Show("Nome e NIF são obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboPlano.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um plano!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Socio novo = new Socio
                {
                    Nome = txtNome.Text.Trim(),
                    Nif = txtNif.Text.Trim(),
                    Telefone = txtTelefone.Text.Trim(),
                    EstadoAtivo = true,
                    PlanoId = (int)cboPlano.SelectedValue,
                    DataInscricao = DateTime.Now
                };

                bool sucesso = SocioRepository.AdicionarSocio(novo);

                if (sucesso)
                {
                    MessageBox.Show("Sócio registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao guardar: " + ex.Message, "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}