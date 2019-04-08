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
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading;



namespace GUI2_esp
{   
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private string[] args;
        int x = -1, y = -1;
        int height;
        int button_dim = 50;
        List<Button> buttons = new List<Button>();
        Button ok = new Button();
        Label tutorial = new Label();

        public Form1(string[] argus)
        {
            InitializeComponent();

            args = argus;

            DateTime startedTime = Process.GetCurrentProcess().StartTime;

            int flag = 0;

            //Process[] pname = Process.GetProcessesByName("GUI2_esp");
            Process[] pname = Process.GetProcessesByName("positioner");
            while (pname.Length > 1)
            {
                flag = 0;
                //pname = Process.GetProcessesByName("GUI2_esp");
                for (int i = 0; i < pname.Count(); i++)
                {
                    if (pname[i].StartTime < startedTime)
                    {
                        flag = 0;
                        break;
                    }
                    else
                    {
                        flag++;
                    }
                }
                if(flag == pname.Count())
                    break;

                Thread.Sleep(100);

                pname = Process.GetProcessesByName("positioner");
            }

            if (File.Exists(@"mac_list.txt"))
            {
                string line;
                StreamReader file = new StreamReader(@"mac_list.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(args[1]))
                        Close();
                }
                file.Close();
            }

            //string[] lines = System.IO.File.ReadAllLines(@".\WriteLines2.txt");
            while (!File.Exists(@"room.txt")) {
                Thread.Sleep(5000);
            }
            string text = System.IO.File.ReadAllText(@"room.txt");
            string [] xy = text.Split(',');
            int width = int.Parse(xy[0]);
            height = int.Parse(xy[1]);
            this.Controls.Add(tutorial);
            tutorial.Location = new Point(8, 40);
            tutorial.Width = button_dim * width;
            tutorial.Height = button_dim;
            tutorial.Text = "This is the room, place your ESP in the right position - ESP MAC: " + args[1].ToUpper();
            tutorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            tutorial.ForeColor = Color.FromArgb(221, 221, 221);
            tutorial.Font = new Font(tutorial.Font.FontFamily, tutorial.Font.Size + 1f, tutorial.Font.Style);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    buttons.Add(new Button());
                    this.Controls.Add(buttons[i + j * width]);
                    buttons[i + j * width].Width = button_dim;
                    buttons[i + j * width].Height = button_dim;
                    buttons[i + j * width].BackColor = Color.FromArgb(38, 38, 38);
                    buttons[i + j * width].FlatStyle = FlatStyle.Flat;
                    buttons[i + j * width].FlatAppearance.BorderSize = 0;
                    buttons[i + j * width].Location = new Point(i * buttons[i + j * width].Width + 8, j * buttons[i + j * width].Height + button_dim + 40);
                    buttons[i + j * width].Text = buttons[i + j * width].Location.X/button_dim + ";" + (height - buttons[i + j * width].Location.Y / button_dim);  //commentando questo spariscono i numerelli nelle caselle
                    buttons[i + j * width].ForeColor = Color.FromArgb(221, 221, 221);
                    buttons[i + j * width].Click += new EventHandler(Clicked);
                }
            }
            this.Width = button_dim * width + 16;
            this.Height = button_dim * height + 39 + button_dim*2 + 10;
            this.Controls.Add(ok);
            ok.Location = new Point(8, button_dim*height + button_dim + 40);
            ok.BackColor = Color.FromArgb(38, 38, 38);
            ok.ForeColor = Color.FromArgb(221, 221, 221);
            ok.FlatAppearance.BorderSize = 0;
            ok.FlatStyle = FlatStyle.Flat;
            ok.Width = button_dim*width;
            ok.Height = button_dim;
            ok.Text = "Ok";
            
            ok.Click += new EventHandler(ClickOk);
            //ok.Enabled = false;
            
        }

        System.Timers.Timer aTimer = new System.Timers.Timer();

        public void ClickOk(object sender, EventArgs e)
        {
            if (x != -1 && y != -1)
            {
                string position = args[1] + "," + x + ":" + y;
                TextWriter pos = new StreamWriter(@"mac_list.txt", true);
                pos.WriteLine(position);
                pos.Close();
                Close();
            }
            else
            {
                ok.Text = "Input a valid position";
                aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 3000;
                aTimer.Enabled = true;
            }
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            ok.Text = "OK";
            aTimer.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ClickOk_v2(object sender, EventArgs e)
        {
            ok.Text = "NO NO NO";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void Clicked(object sender, EventArgs e)
        {
            Button pushedBtn = sender as Button;
            if (pushedBtn.BackColor == Color.FromArgb(0, 167, 157))
            {
                pushedBtn.BackColor = Color.FromArgb(38, 38, 38);
                for(int k=0; k<buttons.Count; k++)
                {
                    buttons[k].FlatStyle = FlatStyle.Flat;
                    buttons[k].FlatAppearance.BorderSize = 0;
                    buttons[k].BackColor = Color.FromArgb(38, 38, 38);
                    buttons[k].ForeColor = Color.FromArgb(221, 221, 221); 
                    buttons[k].Enabled = true;
                }
                x = -1;
                y = -1;
                //ok.Enabled = false;
            }
            else
            {

                if (pushedBtn != null)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (buttons[i].BackColor == Color.FromArgb(0, 167, 157))
                        {
                            ok.Text = "No more than one place for the esp!";
                            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                            aTimer.Interval = 2000;
                            aTimer.Enabled = true;
                            return;
                        }
                    }
                    pushedBtn.BackColor = Color.FromArgb(0, 167, 157);
                    x = pushedBtn.Location.X / button_dim;
                    y = height - pushedBtn.Location.Y / button_dim;
                }
            }
        }
    }
}
