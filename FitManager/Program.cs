using FitManager.Forms;

namespace FitManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (CriarNovoSocio fLogin = new CriarNovoSocio())
            {
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}