using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitManager.Models;
using FitManager.Data;

namespace FitManager.Forms
{
    public partial class EditarSocio : Form
    {
        private Socio socioEncontrado = null;
        public EditarSocio()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBusca.Text.Trim();

            if (string.IsNullOrWhiteSpace(termoBusca))
            {
                MessageBox.Show("Por favor, insira um ID ou NIF para pesquisar.");
                return;
            }

            socioEncontrado = SocioRepository.BuscarSocioPorNifOuId(termoBusca);

            if (socioEncontrado != null)
            {
                txtNome.Text = socioEncontrado.Nome;
                txtTelefone.Text = socioEncontrado.Telefone;
                txtPlanoId.Text = socioEncontrado.PlanoId.ToString();

                MessageBox.Show("Sócio encontrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sócio não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Clear();
                txtTelefone.Clear();
                txtPlanoId.Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (socioEncontrado == null)
            {
                MessageBox.Show("Primeiro precisa de buscar um sócio!");
                return;
            }

            try
            {
                socioEncontrado.Nome = txtNome.Text.Trim();
                socioEncontrado.Telefone = txtTelefone.Text.Trim();

                if (int.TryParse(txtPlanoId.Text, out int novoPlanoId))
                {
                    socioEncontrado.PlanoId = novoPlanoId;
                }

                bool sucesso = SocioRepository.AtualizarSocio(socioEncontrado);

                if (sucesso)
                {
                    MessageBox.Show("Sócio atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possível atualizar o sócio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}