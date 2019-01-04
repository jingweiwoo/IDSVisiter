using System;
using System.Collections.Generic;
// using System.Linq;
using System.Windows.Forms;
using Office2007Renderer;

namespace AppStart
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ToolStripManager.Renderer = new Office2007Renderer.Office2007Renderer();

            Application.Run(new frmMain());
        }
    }
}
