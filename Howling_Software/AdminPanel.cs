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
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using static System.Windows.Forms.ListView;

namespace Howling_Software
{
    public partial class AdminPanel : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Checker check = new Checker();
        

        Auth auth = new Auth();

        public AdminPanel()
        {
            bool isLegit = check.CheckFiles();
            if (!isLegit)
            {
                Error.CstmError.Show("You don't have permission to access the tool due wrong/modified files!");
                Application.Exit();
            }
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
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
                string[] row = { textBox2.Text, textBox3.Text, textBox5.Text };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                label6.Text = Convert.ToString(listView1.Items.Count);
            }
            else
            {
                Error.CstmError.Show("Error please check your Informations");
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            export2File(listView1, ":");
        }


        private void export2File(ListView lv, string splitter)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory() + "\\Data", "Accounts.txt");
            
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (ListViewItem item in lv.Items)
                    {
                        sw.WriteLine("{0}{1}{2}{3}{4}", item.SubItems[0].Text, splitter, item.SubItems[1].Text, splitter, item.SubItems[2].Text);
                    }
                }
        }

        private void import2list()
        {
            string[] itm = new string[3];
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/Data", "Accounts.txt");
        
            foreach (var line in System.IO.File.ReadLines(path))
            {
                string[] GetAccountInfo = line.Split(':');
                itm[0] = GetAccountInfo[0];
                itm[1] = GetAccountInfo[1];
                itm[2] = GetAccountInfo[2];

                ListViewItem lvi = new ListViewItem(itm);
                listView1.Items.Add(lvi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            import2list();
            label6.Text = Convert.ToString(listView1.Items.Count);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
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
    }
}
