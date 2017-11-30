using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace SystemTray
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer1_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (1000) * (20);              // Timer will tick evert second
            timer.Enabled = true;                       // Enable the timer
            timer.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                Hide();
                string directory = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + "\\i-Relax\\Test.exe";
                Process process = Process.Start(@directory);
                int id = process.Id;
                Process tempProc = Process.GetProcessById(id);
                tempProc.WaitForExit();
                notifyIcon.ShowBalloonTip(500);

            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.Visible = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("EyeTribe"))
            {
                process.Kill();
            }

            foreach (var process in Process.GetProcessesByName("Test"))
            {
                process.Kill();
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
