using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authed;
using Jose.jwe;
using Newtonsoft.Json;

namespace Howling_Software
{
    public partial class Register : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Checker check = new Checker();
        Auth auth = new Auth();

        public Register()
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
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string password = textBox3.Text;
            string email = textBox4.Text;
            string token = textBox5.Text;
            bool authed = auth.Authenticate(Globals.secret_key);
            bool register = auth.Register(username, password, email, token);
            
            if (authed != true)
            {
                MessageBox.Show("Please contact the Administration", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (register == true && authed == true)
            {
                Error.CstmError.Show("User " + username + " successfully registered!");
                this.Close();
            }
            else
            {
                Error.CstmError.Show("Error please check your Informations");
                
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if (key == Keys.Space)
            {
                Error.CstmError.Show("Don't accept Space char in your name");
                textBox2.Clear();
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
