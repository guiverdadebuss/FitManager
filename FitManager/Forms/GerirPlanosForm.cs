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
    public partial class GerirPlanosForm : Form
    {

        private Plano _planoSelecionado = null;

        public GerirPlanosForm()
        {
            InitializeComponent();
            FitManager.Services.StyleManager.Aplicar(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void GerirPlanosForm_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        private void AtualizarTabela()
        {
            dgvPlanos.DataSource = null;
            dgvPlanos.DataSource = SocioRepository.ObterTodosPlanos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) return;

            try
            {
                Plano p = new Plano
                {
                    Id = _planoSelecionado?.Id ?? 0,
                    Nome = txtNome.Text.Trim(),
                    PrecoMensal = decimal.Parse(txtPreco.Text),
                    Descricao = txtDescricao.Text.Trim()
                };

                bool sucesso;
                if (p.Id == 0)
                    sucesso = SocioRepository.InserirPlano(p);
                else
                    sucesso = SocioRepository.EditarPlano(p);

                if (sucesso)
                {
                    MessageBox.Show("Plano guardado!");
                    LimparCampos();
                    AtualizarTabela();
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }

        }

        private void dgvPlanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _planoSelecionado = (Plano)dgvPlanos.Rows[e.RowIndex].DataBoundItem;

                txtNome.Text = _planoSelecionado.Nome;
                txtPreco.Text = _planoSelecionado.PrecoMensal.ToString();
                txtDescricao.Text = _planoSelecionado.Descricao;

                btnGravar.Text = "Atualizar Plano";
            }
        }

        private void LimparCampos()
        {
            _planoSelecionado = null;
            txtNome.Clear();
            txtPreco.Clear();
            txtDescricao.Clear();
            btnGravar.Text = "Criar Novo Plano";
            txtNome.Focus();
        }


        private void btnRemover_Click(object sender, EventArgs e)
        {


            var confirmacao = MessageBox.Show($"Tem a certeza que deseja eliminar o plano '{_planoSelecionado.Nome}'?",
                                              "Confirmar Exclusão",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    if (SocioRepository.RemoverPlano(_planoSelecionado.Id))
                    {
                        MessageBox.Show("Plano removido com sucesso!");
                        LimparCampos();
                        AtualizarTabela();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao Remover", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
