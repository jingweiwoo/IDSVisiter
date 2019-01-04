using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visiter
{
    class Program
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static void Main()
        {
            Visiter.App app = new Visiter.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
