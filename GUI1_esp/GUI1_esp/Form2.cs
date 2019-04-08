using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace GUI1_esp
{   
    public partial class Form2 : Form
    { 
        public int width = -1;
        public int height = -1;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form2()
        {
            InitializeComponent();

            System.Threading.Thread.Sleep(2000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            bool isNumeric = int.TryParse(textBox1.Text, out int n);
            if (isNumeric)
            {
                width = int.Parse(textBox1.Text);
                flag++;
                if (width > 11 || width < 3)
                {
                    textBox1.ResetText();
                    flag = 0;
                }
            }
            else
            {
                textBox1.ResetText();
                flag = 0;
            }
            isNumeric = int.TryParse(textBox2.Text, out n);
            if (isNumeric)
            {
                height = int.Parse(textBox2.Text);
                flag++;
                if (height > 11 || height < 0)
                {
                    textBox2.ResetText();
                    flag = 0;
                }
            }
            else
            {
                textBox2.ResetText();
                flag = 0;
            }
            if (flag == 2)
            {
                TextWriter pos = new StreamWriter(@"room.txt");
                string xx = width + "," + height;
                pos.WriteLine(xx);
                pos.Close();

                //notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(10000, "Important Notification", "Your Big Gay", ToolTipIcon.Info);

                Close();
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*if (!(string.IsNullOrEmpty(textBox2.Text)) && !(string.IsNullOrEmpty(textBox1.Text)))
            {
                button1.Enabled = true;
            }
            if (string.IsNullOrEmpty(textBox2.Text) || (string.IsNullOrEmpty(textBox1.Text)))
            {
                button1.Enabled = false;
            }*/
        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(textBox2.Text) && (!string.IsNullOrEmpty(textBox1.Text)))
            {
                button1.Enabled = true;
            }

            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                button1.Enabled = false;
            }*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
