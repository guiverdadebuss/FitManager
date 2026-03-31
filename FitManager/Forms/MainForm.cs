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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Sessao.EstaLogado)
            {
                this.Text = "Sistema de Gestão - Logado como: " + Sessao.UsuarioLogado.Usuario;
                lblUsuarioLogado.Text = "Bem-vindo, " + Sessao.UsuarioLogado.Usuario;
            }
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            SocioForm soc = new SocioForm();
            soc.StartPosition = FormStartPosition.CenterScreen; // abrir a janela no centro da tela
            this.Hide();
            soc.ShowDialog();
            this.Show();
        }

        private void btnPlanos_Click(object sender, EventArgs e)
        {
            PlanoAdd plan = new PlanoAdd();
            plan.StartPosition = FormStartPosition.CenterScreen; // abrir a janela no centro da tela
            this.Hide();
            plan.ShowDialog();
            this.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckInForm check = new CheckInForm();
            check.StartPosition = FormStartPosition.CenterScreen; // abrir a janela no centro da tela
            this.Hide();
            check.ShowDialog();
            this.Show();
        }
    }
}
