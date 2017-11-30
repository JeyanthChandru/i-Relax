using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using EyeTribe.ClientSdk;
using EyeTribe.ClientSdk.Data;
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
               
            string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + "\\i-Relax\\Test.exe";
            string directory_eye = "C:\\Program Files (x86)\\EyeTribe\\Server\\EyeTribe.exe";
            Console.WriteLine(directory);
            Process process_eye = Process.Start(directory_eye);
            Process process = Process.Start(directory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

       

    }
}
