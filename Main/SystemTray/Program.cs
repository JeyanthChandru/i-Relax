using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SystemTray
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + "\\i-Relax\\FirstTest.exe";
            Process process = Process.Start(@directory);
            int id = process.Id;
            Process tempProc = Process.GetProcessById(id);
            tempProc.WaitForExit();
            Console.WriteLine(directory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
