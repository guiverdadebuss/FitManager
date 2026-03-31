using FitManager.Data;
using FitManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class CheckInForm : Form
    {
        public CheckInForm()
        {
            InitializeComponent();
        }


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                string busca = txtBusca.Text.Trim();

                if (string.IsNullOrEmpty(busca)) return;

                Socio socio = SocioRepository.BuscarSocioPorNifOuId(busca);

                if (socio == null)
                {
                    MessageBox.Show("NIF ou ID não encontrado no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!socio.EstadoAtivo)
                {
                    MessageBox.Show($"O sócio {socio.Nome} está com o acesso BLOQUEADO (Inativo).", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (SocioRepository.RegistarEntrada(socio.Id))
                {
                    lblMensagem.Text = $"Entrada confirmada. Bem vindo(a) {socio.Nome}";
                    lblMensagem.ForeColor = Color.Green;
                    

                    txtBusca.Clear();
                    txtBusca.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no processo de Check-in: " + ex.Message, "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }



        private void CheckInForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
