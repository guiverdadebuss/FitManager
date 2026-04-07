using FitManager.Data;
using FitManager.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FitManager.Services.StyleManager.Aplicar(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Sessao.EstaLogado)
            {
                this.Text = "Sistema de Gestão - Logado como: " + Sessao.UsuarioLogado.Usuario;
                string name = Sessao.UsuarioLogado.Usuario;
                lblUsuarioLogado.Text = "Bem-vindo, " + char.ToUpper(name[0]) + name.Substring(1);

                CarregarResumoDiario();
                AtualizarTabelaAcessos();
            }
        }


        public void CarregarResumoDiario()
        {
            try
            {
                int ativos = SocioRepository.CarregarTotalSociosAtivos();
                int entradas = SocioRepository.CarregarCheckIns();

                lblTotalSocios.Text = ativos.ToString();
                lblTotalEntradas.Text = entradas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar resumo: " + ex.Message);
            }
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            SocioForm soc = new SocioForm();
            soc.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            soc.ShowDialog();
            this.Show();
        }

        private void btnPlanos_Click(object sender, EventArgs e)
        {
            GerirPlanosForm plan = new GerirPlanosForm();
            plan.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            plan.ShowDialog();
            this.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInForm check = new CheckInForm();
            check.FormClosed += (s, args) => {
                CarregarResumoDiario();    
                AtualizarTabelaAcessos();
            };
            check.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            check.ShowDialog();
            this.Show();
        }


        private void AtualizarTabelaAcessos()
        {
            try
            {
                var acessos = SocioRepository.ObterUltimosAcessos();

                var dadosParaExibir = acessos.Select(a => new {
                    Hora = a.DataHora.ToString("HH:mm:ss"),
                    Data = a.DataHora.ToShortDateString(),
                    Socio = a.SocioQueEntrou?.Nome ?? "N/A",
                    Documento = a.SocioQueEntrou?.Nif ?? "-"
                }).ToList();

                dgvAcessos.DataSource = null;
                dgvAcessos.DataSource = dadosParaExibir;

                if (dgvAcessos.Columns.Count > 0)
                {
                    dgvAcessos.Columns["Socio"].HeaderText = "Sócio";
                    dgvAcessos.Columns["Documento"].HeaderText = "NIF/Documento";
                }

                FormatarGrade();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar histórico: " + ex.Message);
            }
        }


        private void FormatarGrade()
        {
            dgvAcessos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvAcessos.Columns["Socio"] != null)
                dgvAcessos.Columns["Socio"].FillWeight = 200;
            dgvAcessos.RowTemplate.Height = 40;

            dgvAcessos.AllowUserToResizeColumns = false;
            dgvAcessos.AllowUserToResizeRows = false;

            dgvAcessos.Columns["Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAcessos.Columns["Data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
