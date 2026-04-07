using System.Drawing;
using System.Windows.Forms;

namespace FitManager.Services
{
    public static class StyleManager
    {
        public static Color VerdeEscuro = Color.FromArgb(10, 40, 25);
        public static Color VerdeMedio = Color.FromArgb(30, 130, 70);
        public static Color VerdeFundo = Color.FromArgb(240, 250, 240);
        public static Color CorTexto = VerdeEscuro;
        public static Color CinzaSuave = Color.FromArgb(189, 195, 199);

        public static void Aplicar(Form form)
        {
            form.BackColor = VerdeFundo;
            form.Font = new Font("Segoe UI", 10F);
            form.ForeColor = CorTexto;

            EstilizarControlos(form.Controls);
        }

        private static void EstilizarControlos(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                    if (btn.Name.ToLower().Contains("eliminar") || btn.Name.ToLower().Contains("remover"))
                        btn.BackColor = Color.FromArgb(231, 76, 60);
                    else if (btn.Name.ToLower().Contains("cancelar") || btn.Name.ToLower().Contains("sair"))
                        btn.BackColor = CinzaSuave;
                    else
                        btn.BackColor = VerdeEscuro;
                }

                else if (c is Label lbl)
                {
                    lbl.ForeColor = VerdeEscuro;

                    if (lbl.Name.StartsWith("lblId"))
                    {
                        lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                        lbl.ForeColor = VerdeMedio;
                    }
                }


                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.GridColor = Color.FromArgb(220, 235, 220);

                    dgv.ColumnHeadersDefaultCellStyle.BackColor = VerdeEscuro;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.DefaultCellStyle.SelectionBackColor = VerdeMedio;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                    dgv.RowHeadersVisible = false;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 255, 245);
                }


                else if (c is GroupBox gb)
                {
                    gb.ForeColor = VerdeEscuro;
                    gb.Font = new Font(gb.Font, FontStyle.Bold);
                }

                if (c.HasChildren) EstilizarControlos(c.Controls);
            }
        }
    }
}