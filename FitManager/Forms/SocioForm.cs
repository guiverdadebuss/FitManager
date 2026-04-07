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
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            ListarSocio det = new ListarSocio();
            det.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            det.ShowDialog();
            this.Show();
        }

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
    }
}

