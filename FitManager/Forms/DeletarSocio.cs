using FitManager.Models;
using FitManager.Data;

namespace FitManager.Forms
{
    public partial class DeletarSocio : Form
    {
        private Socio _socioParaEliminar = null;

        public DeletarSocio()
        {
            InitializeComponent();
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termo = txtBusca.Text.Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                MessageBox.Show("Insira um NIF ou ID para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _socioParaEliminar = SocioRepository.BuscarSocioPorNifOuId(termo);

            if (_socioParaEliminar != null)
            {
                lblNomeSocio.Text = _socioParaEliminar.Nome;
                lblStatus.Text = (_socioParaEliminar.EstadoAtivo ? "Ativo" : "Inativo");

                btnEliminar.Enabled = true;
                MessageBox.Show("Sócio encontrado! Verifique os dados antes de eliminar.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sócio não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimparInterface();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_socioParaEliminar == null) return;

            var resultado = MessageBox.Show($"Tem a certeza que deseja eliminar {_socioParaEliminar.Nome}?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    bool sucesso = SocioRepository.EliminarSocio(_socioParaEliminar.Id.ToString());

                    if (sucesso)
                    {
                        MessageBox.Show("Sócio eliminado com sucesso!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível eliminar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparInterface()
        {
            _socioParaEliminar = null;
            lblNomeSocio.Text = "Sócio: ---";
            lblStatus.Text = "Estado: ---";
            btnEliminar.Enabled = false;
            txtBusca.Clear();
            txtBusca.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}