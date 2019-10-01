using System;
using System.Windows.Forms;
namespace deck
{
    class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm = new Form1();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            Application.Run(frm);
        }
    }
}
