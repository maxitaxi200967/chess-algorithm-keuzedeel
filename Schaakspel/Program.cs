using System;
using System.Windows.Forms;

namespace Schaakspel
{
    internal static class Program
    {
        /// <summary>
        /// Het startpunt van de applicatie.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
