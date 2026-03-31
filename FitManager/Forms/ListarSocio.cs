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
        List<Socio> listaSocios = new List<Socio>();

        public ListarSocio()
        {
            InitializeComponent();
        }

        private void ListarSocio_Load(object sender, EventArgs e)
        {
            AtualizarTabelaSocios();
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

        private void AtualizarTabelaSocios()
        {
            try
            {
                var socios = SocioRepository.CarregarTodosSocios();

                var sociosParaExibir = socios.Select(socio => new
                {
                    socio.Id,
                    socio.Nome,
                    socio.Nif,
                    socio.Telefone,
                    socio.DataInscricao,
                    socio.EstadoAtivo,
                    socio.PlanoId
                }).ToList();

                dgvSocios.DataSource = null;
                dgvSocios.DataSource = sociosParaExibir;

                FormatarGrade();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar histórico: " + ex.Message);
            }
        }
        private void FormatarGrade()
        {
            // Configurações Globais
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSocios.RowTemplate.Height = 40;
            dgvSocios.AllowUserToResizeColumns = false;
            dgvSocios.AllowUserToResizeRows = false;
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.ReadOnly = true;

            // Formatação de cada coluna individualmente
            if (dgvSocios.Columns["Id"] != null)
                dgvSocios.Columns["Id"].HeaderText = "ID";

            if (dgvSocios.Columns["Nome"] != null)
            {
                dgvSocios.Columns["Nome"].HeaderText = "Nome do Sócio";
                dgvSocios.Columns["Nome"].FillWeight = 200;
            } // <-- VOCÊ TINHA ESQUECIDO DE FECHAR ESTA CHAVE

            if (dgvSocios.Columns["Nif"] != null)
                dgvSocios.Columns["Nif"].HeaderText = "NIF";

            if (dgvSocios.Columns["Telefone"] != null)
                dgvSocios.Columns["Telefone"].HeaderText = "Telefone";

            if (dgvSocios.Columns["DataInscricao"] != null)
            {
                dgvSocios.Columns["DataInscricao"].HeaderText = "Inscrição";
                dgvSocios.Columns["DataInscricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvSocios.Columns["EstadoAtivo"] != null)
            {
                dgvSocios.Columns["EstadoAtivo"].HeaderText = "Ativo?";
                dgvSocios.Columns["EstadoAtivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvSocios.Columns["PlanoId"] != null)
            {
                dgvSocios.Columns["PlanoId"].HeaderText = "Plano";
                dgvSocios.Columns["PlanoId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}