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


        private void btnApagarSocio_Click(object sender, EventArgs e)
        {
            using (var f = new EliminarSocio())
            {
                // Se no form de eliminar o utilizador concluir com sucesso:
                if (f.ShowDialog() == DialogResult.OK)
                {
                    // Recarrega a lista / grid de sócios
                    CarregarTodosSocios(); // ou o método que já usas para atualizar a grelha
                }
            }
        }

        private void CarregarTodosSocios()
        {
            // Obter dados do repositório
            var socios = FitManager.Data.SocioRepository.CarregarTodosSocios();

            
        }
    }
}


