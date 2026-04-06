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
    public partial class AtualizaSocio : Form
    {
        private Socio socioEncontrado = null;
        public AtualizaSocio()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            String nifParaBusca = txtInputNif.Text;

            if (string.IsNullOrWhiteSpace(nifParaBusca))
            {
                MessageBox.Show("Por favor, insira um NIF para pesquisar.");
                return;
            }

            if (socioEncontrado != null)
            {
                txtNome.Text = socioEncontrado.Nome;
                txtTelefone.Text = socioEncontrado.Telefone;
                txtPlanoId.Text = socioEncontrado.PlanoId.ToString();

                MessageBox.Show("Sócio encontrado!");
            }
            else
            {
                MessageBox.Show("Sócio não encontrado.");
                txtNome.Clear();
                txtTelefone.Clear();
                txtPlanoId.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Socio socioEditado = new Socio
                {
                    Nome = txtNome.Text,
                    Telefone = txtTelefone.Text,
                    PlanoId = int.Parse(txtPlanoId.Text)
                };

                bool sucesso = SocioRepository.AtualizarSocio(socioEditado);

                if (sucesso)
                {
                    MessageBox.Show("Socio Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi feita.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
