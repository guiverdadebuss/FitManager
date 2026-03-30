using FitManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitManager.Forms
{
    public partial class ListarSociosForm : Form
    {
        List<Socio> ListarSocios = new List<Socio>();
        public ListarSociosForm()
        {
            InitializeComponent();
        }

        private void ListarSociosForm_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
        }

        //Configuração Do DataGridView
        private void ConfigurarDataGridView()
        {
            dgvSocios.ReadOnly = true;
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.AllowUserToAddRows = false;
            dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //Filtros para listar Socios por Nome ou NIF 
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtPesquisa.Text.ToLower();

            var filtrados = ListarSocios
                .Where(s => s.Nome.ToLower().Contains(filtro) ||
                            s.NIF.ToLower().Contains(filtro))
                .ToList();

            dgvSocios.DataSource = filtrados;
        }

        private void ToList()
        {
            throw new NotImplementedException();
        }
    }
}
