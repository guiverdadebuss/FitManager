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
    public partial class SocioForm : Form
    {
        public SocioForm()
        {
            InitializeComponent();
            FitManager.Services.StyleManager.Aplicar(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        //private void btnDetalhes_Click(object sender, EventArgs e)
        //{
        //    ListarSocio det = new ListarSocio();
        //    det.StartPosition = FormStartPosition.CenterScreen;
        //    this.Hide();
        //    det.ShowDialog();
        //    this.Show();
        //}

        private void btnEditarSocio_Click(object sender, EventArgs e)
        {
            EditarSocio edit = new EditarSocio();
            edit.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            edit.ShowDialog();
            this.Show();
        }

        private void btnCriarSocio_Click(object sender, EventArgs e)
        {
            NovoSocio novo = new NovoSocio();
            novo.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            novo.ShowDialog();
            this.Show();
        }

        private void btnApagarSocio_Click(object sender, EventArgs e)
        {
            DeletarSocio del = new DeletarSocio();
            del.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            del.ShowDialog();
            this.Show();
        }

        private void SocioForm_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }


        private void AtualizarGrid()
        {
            try
            {
                var lista = SocioRepository.CarregarTodosSocios();

                dgvSocios.DataSource = null;
                dgvSocios.DataSource = lista;

                dgvSocios.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a lista: " + ex.Message);
            }
        }


        private void btnBusca_Click(object sender, EventArgs e)
        {
            string busca = txtBusca.Text.Trim();

            if (string.IsNullOrEmpty(busca))
            {
                AtualizarGrid();
                return;
            }

            Socio socio = SocioRepository.BuscarSocioPorNifOuId(busca);

            if (socio == null)
            {
                MessageBox.Show("NIF ou ID não encontrado no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimparLabels();
                return;
            }

            lblId.Text = socio.Id.ToString();
            lblNome.Text = socio.Nome;
            lblNif.Text = socio.Nif;
            lblTelefone.Text = socio.Telefone ?? "---";
            lblDataInsc.Text = socio.DataInscricao.ToShortDateString();
            lblPlano.Text = socio.PlanoId.ToString();
        }

        private void LimparLabels()
        {
            lblId.Text = "---";
            lblNome.Text = "---";
            lblNif.Text = "---";
            lblTelefone.Text = "---";
            lblDataInsc.Text = "---";
            lblPlano.Text = "---";
        }

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Socio selecionado = (Socio)dgvSocios.Rows[e.RowIndex].DataBoundItem;

                lblId.Text = selecionado.Id.ToString();
                lblNome.Text = selecionado.Nome;
                lblNif.Text = selecionado.Nif;
                lblTelefone.Text = selecionado.Telefone ?? "---";
                lblDataInsc.Text = selecionado.DataInscricao.ToShortDateString();
                lblPlano.Text = selecionado.PlanoId.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

