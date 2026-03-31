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
    public partial class ListarSocio : Form
    {
        public ListarSocio()
        {
            InitializeComponent();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            string busca = txtBusca.Text.Trim();

            if (string.IsNullOrEmpty(busca)) return;

            Socio socio = SocioRepository.BuscarSocioPorNifOuId(busca);
            if (socio == null)
            {
                MessageBox.Show("NIF ou ID não encontrado no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lblId.Text = socio.Id.ToString();
            lblNome.Text = socio.Nome;
            lblNif.Text = socio.Nif;
            lblTelefone.Text = socio.Telefone;
            lblDataInsc.Text = socio.DataInscricao.ToString();
            lblPlano.Text = socio.PlanoId.ToString();
        }

    }
}

