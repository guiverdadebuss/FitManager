using System;
using System.Drawing;
using System.Windows.Forms;
using FitManager.Models;
using FitManager.Data;

namespace FitManager.Forms
{
    public partial class CriarNovoSocio : Form
    {


        private void CriarNovoSocio_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Socio novoSocio = new Socio();

                novoSocio.Nome = txtNome.Text;
                novoSocio.Nif = txtNif.Text;
                novoSocio.Telefone = txtTelefone.Text;
                novoSocio.PlanoId = int.Parse(txtPlanoId.Text);
                novoSocio.EstadoAtivo = true;
                novoSocio.DataInscricao = DateTime.Now;

                SocioRepository.AdicionarSocio(novoSocio);

                MessageBox.Show("Sócio criado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar: " + ex.Message);
            }
        }

        private void txtPlanoId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNif_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}