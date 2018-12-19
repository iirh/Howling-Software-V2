using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using ManualMapInjection.Injection;
using System.IO;
using Authed;
using Jose.jwe;
using Newtonsoft.Json;

namespace Howling_Software
{
    public partial class Main : Form
    {
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Checker check = new Checker();

        public Main()
        {
            bool isLegit = check.CheckFiles();
            if (!isLegit)
            {
                Error.CstmError.Show("You don't have permission to access the tool due wrong/modified files!");
                Application.Exit();
            }
            
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            loader Login = new loader();
            Globals.loggedoff = "true";
            this.Close();
            Login.Show();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Globals.AdminName.Contains(Globals.username))
            {
                Adminbtn.Visible = true;
            }
            CheatList.Items.Add(Globals.cheat1);
            Welcomelbl.Text = "Welcome: " + Globals.username + " !";
        }

        
        private void lgn_button_Click(object sender, EventArgs e)
        {
            string selecedcheat = CheatList.GetItemText(CheatList.SelectedItem);
            WebClient client = new WebClient();
            var name = "csgo";
            var target = Process.GetProcessesByName(name).FirstOrDefault();
             if (target == null)
             {
                 Error.CstmError.Show("Process not found");
                 return;
             }
             
            if (selecedcheat == "Howling Cheat CSGO") 
            {
                
                string Temppath = Path.GetTempPath();
                var path = Temppath + Globals.CheatName;

                client.DownloadFile(Globals.DownLink, path);

                var file = File.ReadAllBytes(path);

                if (!File.Exists(path))
                {
                    Error.CstmError.Show("unexpected error. File not found! press OK to restart client...");
                    Application.Restart();
                }

                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                label1.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";

                if (File.Exists(path))
                    File.Delete(path);

                Application.ExitThread();
                Application.Exit();
            }
            if(selecedcheat == "")
            {
                Error.CstmError.Show("No Cheat selected");
            }
            
        }

        private void CheatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void Adminbtn_Click(object sender, EventArgs e)
        {
            AdminPanel Ad = new AdminPanel();
            Ad.Show();
        }
    }
}
