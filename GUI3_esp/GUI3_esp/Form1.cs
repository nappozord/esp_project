using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Globalization;

using XComponent.SliderBar;
using System.Runtime.InteropServices;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;

namespace GUI3_esp
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Boolean is_live = false;
        public Boolean is_there_a_room = false;
        public Boolean is_this_a_backup = false;
        public Boolean am_I_on_stats = false;
        public Boolean am_I_on_backup_button = false;
        DateTime from;
        DateTime startT;
        DateTime endT;
        int five_or_ten = 5;
        public int one_time = 0;
        public int k = 0;
        public int h = 0;
        private Dictionary<string, int> statisticCountPerUser = new Dictionary<string, int>();
        private Dictionary<string, List<string>> statisticDateTimePerUser = new Dictionary<string, List<string>>();
        private Dictionary<string, int> statisticCountPerVendor = new Dictionary<string, int>();
        private Dictionary<string, List<string>> statisticUsersPerVendor = new Dictionary<string, List<string>>();
        private List<string> statisticDevicesDateTime = new List<string>();
        private List<int> statisticUserCounter = new List<int>();
        private List<PictureBox> esps = new List<PictureBox>();
        private List<PictureBox> user_plot = new List<PictureBox>();
        //private List<Label> esps_mac = new List<Label>();
        int user_x, user_y;
        //Timer for showing the users when clicking in the room
        System.Timers.Timer aTimer = new System.Timers.Timer();
        //Timer for showing the vendor when clicking on a MAC
        System.Timers.Timer bTimer = new System.Timers.Timer();
        //Timer for the real time date
        System.Timers.Timer dateTimer = new System.Timers.Timer();
        private static string dir_src = AppDomain.CurrentDomain.BaseDirectory;
        private string file_room = Path.Combine(dir_src, @"room.txt");
        private string file_mac_list = Path.Combine(dir_src, @"mac_list.txt");
        private string file_time_and_space = Path.Combine(dir_src, @"time_and_space.txt");
        private string file_mac_vendor = Path.Combine(dir_src, @"mac_vendor\mac_vendor.txt");
        
        public Form1()
        {
            InitializeComponent();

            //Se c'è già un processo gui.exe attivo, non lo riaprire, lol, era facile dio cane!!! 
            Process[] pname = Process.GetProcessesByName("gui");
            if (pname.Length > 1)
                this.Close();

            delete_txt();

            users.EnableHeadersVisualStyles = false;
            users.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
            users.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            from = DateTime.Now;

            dateTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnDateTimedEvent);
            dateTimer.Interval = 100;
            dateTimer.Enabled = true;

            Timer timer1 = new Timer();
            timer1.Interval = 10000;//10 seconds
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();

            start_everything();
        }

        private void OnDateTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                DateTime now = DateTime.Now;

                date_now.Text = now.ToString("HH:mm:ss");

                if (now.Day > from.Day)
                {
                    backup(true);
                    from = now;
                }
            });
        }

        private void delete_txt()
        {
            DirectoryInfo di = new DirectoryInfo(dir_src);

            FileInfo[] Files = di.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                file.Delete();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            start_everything();
        }

        //Line chart that shows number of devices over time
        //When a point is clicked it shows the MAC of the devices catpured

        private void StatisticGeneratorLineChart()
        {
            cartesianChart1.Visible = true;

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "# of Devices:",
                    Values = new ChartValues<int> {},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                }
            };

            for (int i = 0; i < statisticUserCounter.Count(); i++)
            {
                cartesianChart1.Series[0].Values.Add(statisticUserCounter[i]);
            }

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "",
                Labels = statisticDevicesDateTime
            });

            int max = statisticUserCounter.Max();

            if (max == 0) max = 10;

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Devices",
                MinValue = 0,
                MaxValue = max
            });

            if (max < 10) cartesianChart1.AxisY[0].Separator = new Separator { Step = 1 };

        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            string date = cartesianChart1.AxisX[0].Labels[int.Parse(chartPoint.X.ToString())].ToString();
            DateTime start_time = DateTime.Parse(date);
            startT = start_time;
            DateTime end_time = calculateTime((int)start_time.Minute + five_or_ten);

            plot(start_time, end_time);
        }

        //Pie chart that shows how many users have the same vendor

        private void StatisticGeneratorPieChart()
        {
            pieChart1.Visible = true;

            Func<ChartPoint, string> labelPoint = ChartPoint => string.Format("{0} ({1:P})", ChartPoint.Y, ChartPoint.Participation);

            pieChart1.Series = new SeriesCollection { };

            if (statisticCountPerVendor.Count() > 0)
            {
                foreach (KeyValuePair<string, int> entry in statisticCountPerVendor.OrderBy(x => x.Value))
                {
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = entry.Key,
                        Values = new ChartValues<int> { entry.Value },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });
                }
            }
            else
            {
                pieChart1.Series.Add(new PieSeries
                {
                    Title = "No Device",
                    Values = new ChartValues<int> { 1 },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }


            pieChart1.DefaultLegend.Foreground = System.Windows.Media.Brushes.AliceBlue;

            //pieChart1.DataClick += pieChart1_DataClick;

            pieChart1.LegendLocation = LegendLocation.Right;
        }

        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            users.Rows.Clear();
            for (int i = 0; i < pieChart1.Series.Count(); i++)
            {
                if (pieChart1.Series[i].Equals(chartPoint.SeriesView))
                {
                    string user_local = pieChart1.Series[i].Title.ToString();

                    foreach (KeyValuePair<string, List<string>> entry in statisticUsersPerVendor)
                    {
                        if (entry.Key.ToString().Equals(user_local))
                        {
                            for (int j = 0; j < entry.Value.Count(); j++)
                            {
                                users.Rows.Add(entry.Value[j].ToString());
                            }
                            return;
                        }
                    }
                }
            }
        }

        private void StatisticGeneratorHistoChart()
        {
            histogramChart1.Visible = true;

            histogramChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<int> {}
                }
            };

            if (statisticCountPerUser.Count() > 0)
            {
                foreach (KeyValuePair<string, int> entry in statisticCountPerUser)
                {
                    histogramChart1.Series[0].Values.Add(entry.Value);
                }
            }

            histogramChart1.AxisX.Add(new Axis
            {
                Title = "Devices",
                Labels = statisticCountPerUser.Keys.ToArray(),
                LabelsRotation = -12
            });

            if (statisticCountPerUser.Count() < 15) histogramChart1.AxisX[0].Separator = new Separator { Step = 1 };

            int max;

            if (statisticCountPerUser.Count() == 0) max = 10;

            else max = statisticCountPerUser.Values.Max();

            histogramChart1.AxisY.Add(new Axis
            {
                Title = "Times Sniffed",
                MinValue = 0,
                MaxValue = max,
                LabelFormatter = value => value.ToString("N0")
            });

            if (max < 10) histogramChart1.AxisY[0].Separator = new Separator { Step = 1 };
        }

        private void histogramChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            users.Rows.Clear();

            string device = histogramChart1.AxisX[0].Labels[chartPoint.Key];

            foreach (KeyValuePair<string, List<string>> entry in statisticDateTimePerUser)
            {
                if (entry.Key.ToString().Equals(device))
                {
                    for (int j = 0; j < entry.Value.Count(); j++)
                    {
                        users.Rows.Add(entry.Value[j].ToString());
                    }
                    if (users.RowCount < 10) userCounter.Text = "0" + users.RowCount.ToString();
                    else userCounter.Text = users.RowCount.ToString();
                    return;
                }
            }
        }

        private void start_everything()
        {
            if (File.Exists(file_room) && !am_I_on_backup_button)
            {
                one_time = 0;

                is_there_a_room = true;
                place_holder.Visible = false;
                place_holder2.Visible = false;
                place_holder3.Visible = false;
                place_holder4.Visible = false;
                place_holder5.Visible = false;
                place_holder6.Visible = false;

                if (!am_I_on_stats)
                {
                    room.Visible = true;
                    users.Columns[0].HeaderText = "MAC";
                    users.Columns[1].HeaderText = "X";
                    users.Columns[2].HeaderText = "Y";
                }

                string text = File.ReadAllText(file_room);
                string[] xy = text.Split(',');
                int width = int.Parse(xy[0]);
                int height = int.Parse(xy[1]);
                room.Height = height * 40;
                room.Width = width * 40;
                //room.BackColor = Color.Transparent;
                room.Location = new Point((panel3.Width / 2) - (room.Width / 2), (panel3.Height / 2) - (room.Height / 2));

                Controls.Add(label7);

                users.EnableHeadersVisualStyles = false;
                users.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
                users.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                if (File.Exists(file_mac_list))
                {
                    for (int x = 0; x < h; x++)
                    {
                        room.Controls.Remove(esps[x]);
                    }

                    esps.Clear();
                    //esps_mac.Clear();
                    h = 0;

                    string mac_list1 = System.IO.File.ReadAllText(file_mac_list);
                    mac_list1 = mac_list1.Replace("\n", "");
                    mac_list1 = mac_list1.Replace("\r", ",");
                    string[] mac_list2 = mac_list1.Split(',', ':');
                    for (int i = 0; i < mac_list2.Length; i++)
                    {
                        if (mac_list2[i] != "")
                        {
                            PictureBox pb = new PictureBox
                            {
                                Image = Properties.Resources.ICONA_ESP,
                                Size = new Size(40, 40),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                BackColor = Color.Transparent
                            };
                            int x_esp = int.Parse(mac_list2[i + 1]) * 40;
                            int y_esp = int.Parse(mac_list2[i + 2]) * 40;
                            y_esp = room.Height - y_esp - 40;                           //CHANGE
                            if ((x_esp + 40) > room.Width)
                                x_esp -= 15;
                            if ((y_esp + 40) > room.Height)
                                y_esp -= 13;
                            pb.Location = new Point(x_esp, y_esp);                     //CHANGE
                            esps.Add(pb);
                            room.Controls.Add(esps[h]);

                            h++;
                            i += 2;
                        }
                    }
                }
                else
                {
                    esps.Clear();
                    room.Controls.Clear();
                }
            }
        }

        private void calculate_tick()
        {
            trackBar1.Enabled = true;
            TimeSpan span = endT.Subtract(startT);
            if (span.TotalMinutes < 60 * 6)
            {
                trackBar1.Minimum = 0;
                trackBar1.Maximum = ((int)span.TotalMinutes / 5) - 1;
                five_or_ten = 5;
            }

            else
            {
                trackBar1.Minimum = 0;
                trackBar1.Maximum = ((int)span.TotalMinutes / 10) - 1;
                five_or_ten = 10;
            }

        }

        private void plot(DateTime start, DateTime end)
        {
            //room.Visible = true;

            users.Rows.Clear();

            for (int x = 0; x < k; x++)
                room.Controls.Remove(user_plot[x]);

            user_plot.Clear();

            if (!File.Exists(file_time_and_space))
            {
                label1.Text = "Nothing sniffed by now!";
                trackBar1.Enabled = false;
                return;
            }

            string text2 = System.IO.File.ReadAllText(file_time_and_space);
            text2 = text2.Replace("\n", "");
            text2 = text2.Replace("\r", "");
            text2 = text2.Replace("  ", " ");

            string[] all_time = text2.Split(';');
            k = 0;

            userCounter.Text = "00";

            for (int i = 0; i < all_time.Length - 1; i++)
            {

                string[] user_pos = all_time[i].Split(',');
                string[] date = user_pos[0].Split(' ', ':');

                DateTime date_rel = DateTime.Parse(date[6] + "-" + date[1] + "-" + date[2] + " " + date[3] + ":" + date[4] + ":" + date[5]);

                if (start < date_rel && date_rel < end)
                {
                    for (int j = 1; j < user_pos.Length - 1; j += 3)
                    {
                        float user_x1 = float.Parse(user_pos[j + 1], NumberStyles.Any, CultureInfo.InvariantCulture);
                        float user_y1 = float.Parse(user_pos[j + 2], NumberStyles.Any, CultureInfo.InvariantCulture);
                        if ((user_x1 - (int)user_x1) >= 0.5 && (user_x1 + 0.5) < room.Width / 40) user_x1 = user_x1 + (float)0.5;
                        if ((user_y1 - (int)user_y1) >= 0.5 && (user_y1 + 0.5) < room.Height / 40) user_y1 = user_y1 + (float)0.5;
                        user_x = (int)user_x1;
                        user_y = (int)user_y1;
                        int flag = 0;
                        for (int x = 0; x < users.RowCount; x++)
                        {
                            if (users.Rows[x].Cells[0].Value.ToString() == put_some_zeroes(user_pos[j].ToUpper()))
                                flag++;
                        }
                        if (flag == 0)
                        {
                            Boolean cell_su_esp = false;
                            users.Rows.Add(put_some_zeroes(user_pos[j].ToUpper()), user_x, user_y);

                            user_x = user_x * 40;
                            user_y = user_y * 40;
                            PictureBox pb = new PictureBox
                            {
                                Image = Properties.Resources.cell1,
                                Size = new Size(40, 40),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                BackColor = Color.Transparent,
                                Location = new Point(user_x, room.Height - user_y - 40)
                            };
                            for (int counter = 0; counter < esps.Count(); counter++)
                            {
                                if (esps[counter].Location == pb.Location)
                                {
                                    for (int p = 0; p < user_plot.Count; p++)
                                    {
                                        if (user_plot[p].Location == pb.Location)
                                            user_plot[p].Image = Properties.Resources.ICONA_ESP_cell;
                                    }
                                    pb.Image = Properties.Resources.ICONA_ESP_cell;
                                    cell_su_esp = true;
                                }
                            }
                            if(!cell_su_esp)
                            {
                                int num = 0;
                                for (int l = 0; l < users.RowCount; l++)
                                {
                                    if ((int)pb.Location.X / 40 == int.Parse(users.Rows[l].Cells[1].Value.ToString())
                                        && ((room.Height - (int)pb.Location.Y) / 40) == int.Parse(users.Rows[l].Cells[2].Value.ToString()) + 1)
                                    {
                                        num++;
                                    }
                                }

                                if (num == 2)
                                {
                                    for (int p = 0; p < user_plot.Count; p++)
                                    {
                                        if (user_plot[p].Location == pb.Location)
                                            user_plot[p].Image = Properties.Resources.cell2;
                                    }
                                    pb.Image = Properties.Resources.cell2;
                                }
                                if (num == 3)
                                {
                                    for (int p = 0; p < user_plot.Count; p++)
                                    {
                                        if (user_plot[p].Location == pb.Location)
                                            user_plot[p].Image = Properties.Resources.cell3;
                                    }
                                    pb.Image = Properties.Resources.cell3;
                                }
                                if (num == 4)
                                {
                                    for (int p = 0; p < user_plot.Count; p++)
                                    {
                                        if (user_plot[p].Location == pb.Location)
                                            user_plot[p].Image = Properties.Resources.cell4;
                                    }
                                    pb.Image = Properties.Resources.cell4;
                                }
                                if (num == 5)
                                {
                                    for (int p = 0; p < user_plot.Count; p++)
                                    {
                                        if (user_plot[p].Location == pb.Location)
                                            user_plot[p].Image = Properties.Resources.cell5;
                                    }
                                    pb.Image = Properties.Resources.cell5;
                                }
                                if (num > 5)
                                {
                                    for (int p = 0; p < user_plot.Count; p++)
                                    {
                                        if (user_plot[p].Location == pb.Location)
                                            user_plot[p].Image = Properties.Resources.cell5_;
                                    }
                                    pb.Image = Properties.Resources.cell5_;
                                }
                            }

                            pb.BringToFront();
                            pb.Click += pb_Click;
                            user_plot.Add(pb);
                            esps[0].Controls.Add(user_plot[k]);
                            room.Controls.Add(user_plot[k]);
                            k++;
                        }
                    }
                }
                if (users.RowCount < 10) userCounter.Text = "0" + users.RowCount.ToString();
                else userCounter.Text = users.RowCount.ToString();
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(users.Rows[0].Cells[1].Value.ToString() + " " + users.Rows[0].Cells[2].Value.ToString());
            label7.BringToFront();
            PictureBox ckPic = sender as PictureBox;
            //Console.WriteLine(ckPic.Location.X / 40 + " " + (room.Height - ckPic.Location.Y) / 40);
            label7.Location = new Point((panel3.Width / 2) - (room.Width / 2) + ckPic.Location.X - 29,
                (panel3.Height / 2) - (room.Height / 2) + (ckPic.Location.Y) + 46);
            //label7.BackColor = Color.FromArgb(55, 55, 55);
            label7.Text = "";
            for (int i = 0; i < users.RowCount; i++)
            {
                if ((int)ckPic.Location.X / 40 == int.Parse(users.Rows[i].Cells[1].Value.ToString())
                    && ((room.Height - (int)ckPic.Location.Y) / 40) == int.Parse(users.Rows[i].Cells[2].Value.ToString()) + 1)
                {
                    label7.Text += users.Rows[i].Cells[0].Value.ToString() + "\n";
                }
            }
            label7.Visible = true;

            aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () { label7.Visible = false; });
            aTimer.Enabled = false;
        }

        private DateTime calculateTime(int minute)
        {
            int year = startT.Year;
            int month = startT.Month;
            int day = startT.Day;
            int hour = startT.Hour;


            while (minute > 59)
            {
                minute -= 60;
                hour++;
                if (hour > 23)
                {
                    hour = 0;
                    day++;
                }
            }

            DateTime a = new DateTime(year, month, day, hour, minute, 00);

            return a;
        }

        private void live_Click_1(object sender, EventArgs e)
        {
            file_room = Path.Combine(dir_src, @"room.txt");
            file_mac_list = Path.Combine(dir_src, @"mac_list.txt");
            file_time_and_space = Path.Combine(dir_src, @"time_and_space.txt");

            if (File.Exists(file_room))
            {
                is_there_a_room = true;
            }
            else is_there_a_room = false;

            if (is_there_a_room)
            {
                if (is_this_a_backup)
                {
                    is_this_a_backup = false;
                    start_everything();
                }

                am_I_on_backup_button = false;

                place_holder6.Visible = false;

                make_plot_visible();

                Timer timer3 = new Timer();
                timer3.Interval = 60000;//60 seconds
                timer3.Tick += new System.EventHandler(timer3_Tick);
                timer3.Start();

                trackBar1.Value = 0;

                if (!is_live)
                {
                    startT = DateTime.Now.AddMinutes(-2);
                    endT = startT.AddMinutes(4);

                    time_start.Text = put_some_zeroes(startT.Hour.ToString());
                    time_start2.Text = put_some_zeroes(startT.Minute.ToString());
                    time_end.Text = put_some_zeroes(endT.Hour.ToString());
                    time_end2.Text = put_some_zeroes(endT.Minute.ToString());
                    dateStart.Value = startT;
                    dateEnd.Value = endT;

                    calculate_tick();

                    string mgs = "From: " + startT.ToString("dd-MMM-yyyy HH:mm") + "\nTo: " + endT.ToString("dd-MMM-yyyy HH:mm");

                    label1.Text = mgs;

                    plot(startT, endT);

                    is_live = true;
                    live.Text = "LIVE ON";

                    button_backup.Enabled = false;
                }
                else
                {
                    startT = DateTime.Now.AddMinutes(-2);
                    endT = startT.AddMinutes(4);

                    time_start.Text = put_some_zeroes(startT.Hour.ToString());
                    time_start2.Text = put_some_zeroes(startT.Minute.ToString());
                    time_end.Text = put_some_zeroes(endT.Hour.ToString());
                    time_end2.Text = put_some_zeroes(endT.Minute.ToString());
                    dateStart.Value = startT;
                    dateEnd.Value = endT;

                    calculate_tick();

                    string mgs = "From: " + startT.ToString("dd-MMM-yyyy HH:mm") + "\nTo: " + endT.ToString("dd-MMM-yyyy HH:mm");

                    label1.Text = mgs;

                    plot(startT, endT);

                    is_live = false;
                    live.Text = "LIVE OFF";

                    button_backup.Enabled = true;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (is_live)
            {
                startT = DateTime.Now.AddMinutes(-2);
                endT = startT.AddMinutes(4);

                time_start.Text = put_some_zeroes(startT.Hour.ToString());
                time_start2.Text = put_some_zeroes(startT.Minute.ToString());
                time_end.Text = put_some_zeroes(endT.Hour.ToString());
                time_end2.Text = put_some_zeroes(endT.Minute.ToString());
                dateStart.Value = startT;
                dateEnd.Value = endT;

                string mgs = "From: " + startT.ToString("dd-MMM-yyyy HH:mm") + "\nTo: " + endT.ToString("dd-MMM-yyyy HH:mm");

                label1.Text = mgs;

                plot(startT, endT);
            }
        }

        private void make_plot_visible()
        {
            room.Visible = true;
            trackBar1.Visible = true;
            piechart.Visible = false;
            piecharticon.Visible = false;
            pieChart1.Visible = false;
            linechart.Visible = false;
            linecharticon.Visible = false;
            cartesianChart1.Visible = false;
            histochart.Visible = false;
            histocharticon.Visible = false;
            histogramChart1.Visible = false;



            am_I_on_stats = false;

            users.Columns[0].HeaderText = "MAC";
            users.Columns[1].HeaderText = "X";
            users.Columns[2].HeaderText = "Y";
            users.Rows.Clear();

            if (!is_this_a_backup)
                label8.Text = "ESP SNIFFER";
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (is_there_a_room && !is_live)
            {
                make_plot_visible();

                bool isNumeric = int.TryParse(time_start.Text, out int n);
                if (!isNumeric)
                {
                    label1.Text = "Input Error";
                    return;
                }
                isNumeric = int.TryParse(time_start2.Text, out n);
                if (!isNumeric)
                {
                    label1.Text = "Input Error";
                    return;
                }
                isNumeric = int.TryParse(time_end.Text, out n);
                if (!isNumeric)
                {
                    label1.Text = "Input Error";
                    return;
                }
                isNumeric = int.TryParse(time_end2.Text, out n);
                if (!isNumeric)
                {
                    label1.Text = "Input Error";
                    return;
                }

                startT = new DateTime(dateStart.Value.Year, dateStart.Value.Month, dateStart.Value.Day, int.Parse(time_start.Text), int.Parse(time_start2.Text), 00);
                endT = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, dateEnd.Value.Day, int.Parse(time_end.Text), int.Parse(time_end2.Text), 00);

                if (endT <= startT)
                {
                    label1.Text = "Input Error";
                    return;
                }
                else
                {
                    calculate_tick();

                    trackBar1.Value = 0;

                    //string mgs = "From: " + startT.Day.ToString() + "/" + startT.Month.ToString() + "/" + startT.Year.ToString() + " " + startT.Hour.ToString("") + ":" + startT.Minute.ToString() + "    To: " + calculateTime((int)startT.Minute + five_or_ten).Day.ToString() + "/" + calculateTime((int)startT.Minute + five_or_ten).Month.ToString() + "/" + calculateTime((int)startT.Minute + five_or_ten).Year.ToString() + " " + calculateTime((int)startT.Minute + five_or_ten).Hour.ToString() + ":" + calculateTime((int)startT.Minute + five_or_ten).Minute.ToString();

                    string mgs = "From: " + startT.ToString("dd-MMM-yyyy HH:mm") + "\nTo: " + calculateTime((int)startT.Minute + five_or_ten).ToString("dd-MMM-yyyy HH:mm");

                    label1.Text = mgs;

                    plot(startT, calculateTime((int)startT.Minute + five_or_ten));
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int minute = startT.Minute + (trackBar1.Value * five_or_ten);

            DateTime a = calculateTime(minute);

            minute = startT.Minute + (trackBar1.Value * five_or_ten) + five_or_ten;

            DateTime b = calculateTime(minute);

            string mgs = "From: " + a.ToString("dd-MMM-yyyy HH:mm") + "\nTo: " + b.ToString("dd-MMM-yyyy HH:mm");
            label1.Text = mgs;

            plot(a, b);
        }

        private void time_start_MouseClick(object sender, MouseEventArgs e)
        {
            time_start.SelectAll();
            time_start.Focus();
        }

        private void time_start2_MouseClick(object sender, MouseEventArgs e)
        {
            time_start2.SelectAll();
            time_start2.Focus();
        }

        private void time_end_MouseClick(object sender, MouseEventArgs e)
        {
            time_end.SelectAll();
            time_end.Focus();
        }

        private void time_end2_MouseClick(object sender, MouseEventArgs e)
        {
            time_end2.SelectAll();
            time_end2.Focus();
        }

        private void room_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int numOfCells = room.Width * room.Height;
            int cellSize = 40;
            Pen p = new Pen(Color.FromArgb(100, 100, 100));

            for (int y = 1; y < numOfCells; ++y)
            {
                g.DrawLine(p, 1, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 1; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 1, x * cellSize, numOfCells * cellSize);
            }
        }

        private void trackBar1_ValueChanged(object sender, decimal value)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            foreach (Process proc_server in Process.GetProcessesByName("server"))
            {
                proc_server.Kill();
            }

            foreach (Process proc_analyzer in Process.GetProcessesByName("rec_analyzer"))
            {
                proc_analyzer.Kill();
            }

            if (is_there_a_room)
                backup(false);

            delete_txt();

            this.Close();
        }

        private void backup(Boolean is_a_new_day)
        {
            string src = AppDomain.CurrentDomain.BaseDirectory;
            string to;
            string dst;
            if (!is_a_new_day)
            {
                to = DateTime.Now.ToString("-HH.mm)");
                dst = src + from.ToString("dd-MM-yy(HH.mm") + to + "_backup";
            }
            else
            {
                dst = src + from.ToString("dd-MM-yy(HH.mm-") + "23.59)_backup";
            }
            
            string src_file_room = Path.Combine(src, @"room.txt");
            string src_file_mac_list = Path.Combine(src, @"mac_list.txt");
            string src_file_time_and_space = Path.Combine(src, @"time_and_space.txt");

            string dst_file_room = Path.Combine(dst, @"room.txt");
            string dst_file_mac_list = Path.Combine(dst, @"mac_list.txt");
            string dst_file_time_and_space = Path.Combine(dst, @"time_and_space.txt");

            //Copy the files in the backup directory and delete them from the source directory
            if (File.Exists(src_file_room) && File.Exists(src_file_mac_list) && File.Exists(src_file_time_and_space))
            {
                //Create the backup directory

                DirectoryInfo di;
                if (!is_this_a_backup) di = Directory.CreateDirectory(dst);

                if (!is_this_a_backup) File.Copy(src_file_room, dst_file_room, true);
                if (!is_a_new_day) File.Delete(src_file_room);

                if (!is_this_a_backup) File.Copy(src_file_mac_list, dst_file_mac_list, true);
                if (!is_a_new_day) File.Delete(src_file_mac_list);

                if (!is_this_a_backup) File.Copy(src_file_time_and_space, dst_file_time_and_space, true);
                File.Delete(src_file_time_and_space);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            //label10.BackColor = Color.FromArgb(51, 51, 58);
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            //label9.BackColor = Color.FromArgb(51, 51, 58);
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.BackColor = Color.FromArgb(51, 51, 58);
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.FromArgb(45, 45, 48);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.FromArgb(51, 51, 58);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void make_charts_visible()
        {
            trackBar1.Visible = false;
            room.Visible = false;

            am_I_on_stats = true;

            piechart.Visible = true;
            piecharticon.Visible = true;
            linechart.Visible = true;
            linecharticon.Visible = true;
            histochart.Visible = true;
            histocharticon.Visible = true;
        }

        private void Stats_Click(object sender, EventArgs e)
        {
            if (is_there_a_room)
            {
                pieChart1.Visible = false;
                histogramChart1.Visible = false;

                OK_Click(new object(), new EventArgs());

                if (label1.Text == "Input Error") return;

                string mgs = "From: " + startT.ToString("dd-MMM-yyyy HH:mm") + "\nTo: " + endT.ToString("dd-MMM-yyyy HH:mm");

                label1.Text = mgs;

                make_charts_visible();

                DateTime startTn = startT;

                cartesianChart1.Series.Clear();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();
                histogramChart1.Series.Clear();
                histogramChart1.AxisX.Clear();
                histogramChart1.AxisY.Clear();

                statisticCountPerUser.Clear();
                statisticUserCounter.Clear();
                statisticDevicesDateTime.Clear();
                statisticDateTimePerUser.Clear();
                statisticCountPerVendor.Clear();
                statisticUsersPerVendor.Clear();

                List<string> users_for_pie = new List<string>();

                while (startT < endT)
                {
                    plot(startT, calculateTime((int)startT.Minute + five_or_ten));
                    //Adds the number of the users in the selected time in a proper list (Y axis)
                    //Line chart
                    statisticUserCounter.Add(int.Parse(userCounter.Text));
                    //Adds the dates divided by 5 or 10 minutes of the selected time in a proper list (X axis)
                    //Line chart
                    statisticDevicesDateTime.Add(startT.ToString("dd-MMM-yy HH:mm"));

                    for (int i = 0; i < users.RowCount; i++)
                    {
                        //Adds in a proper dict all users sniffed over the time selected and counts how many time they have been sniffed
                        //Histo chart
                        if (statisticCountPerUser.ContainsKey(users.Rows[i].Cells[0].Value.ToString()))
                        {
                            statisticCountPerUser[users.Rows[i].Cells[0].Value.ToString()] += 1;
                        }
                        else statisticCountPerUser[users.Rows[i].Cells[0].Value.ToString()] = 1;

                        //Adds in a proper dict all users sniffed over the time selected and lists all dates they have been sniffed
                        //Histo chart
                        if (statisticDateTimePerUser.ContainsKey(users.Rows[i].Cells[0].Value.ToString()))
                        {
                            statisticDateTimePerUser[users.Rows[i].Cells[0].Value.ToString()].Add(startT.ToString("dd-MMM-yy HH:mm"));
                        }
                        else
                        {
                            statisticDateTimePerUser[users.Rows[i].Cells[0].Value.ToString()] = new List<string>();
                            statisticDateTimePerUser[users.Rows[i].Cells[0].Value.ToString()].Add(startT.ToString("dd-MMM-yy HH:mm"));
                        }

                        if (!users_for_pie.Contains(users.Rows[i].Cells[0].Value.ToString()))
                        {
                            users_for_pie.Add(users.Rows[i].Cells[0].Value.ToString());
                            //Adds in a proper dict all vendor sniffed over the time selected and lists all dates they have been sniffed
                            //Pie chart
                            string mac_vendor_for_pie = get_mac_vendor(users.Rows[i].Cells[0].Value.ToString());
                            if (statisticCountPerVendor.ContainsKey(mac_vendor_for_pie))
                            {
                                statisticCountPerVendor[mac_vendor_for_pie] += 1;
                            }
                            else statisticCountPerVendor[mac_vendor_for_pie] = 1;

                            //Adds in a proper dict all vendor sniffed over the time selected and lists all dates they have been sniffed
                            //Pie chart
                            if (statisticUsersPerVendor.ContainsKey(mac_vendor_for_pie))
                            {
                                statisticUsersPerVendor[mac_vendor_for_pie].Add(users.Rows[i].Cells[0].Value.ToString());
                            }
                            else
                            {
                                statisticUsersPerVendor[mac_vendor_for_pie] = new List<string>();
                                statisticUsersPerVendor[mac_vendor_for_pie].Add(users.Rows[i].Cells[0].Value.ToString());
                            }
                        }
                    }
                    startT = calculateTime((int)startT.Minute + five_or_ten);
                }

                int c = 0;

                foreach (KeyValuePair<string, List<string>> entry in statisticUsersPerVendor)
                {
                    c += entry.Value.Count();
                }
                if (c < 10) userCounter.Text = "0" + c.ToString();
                else userCounter.Text = c.ToString();

                startT = startTn;

                StatisticGeneratorLineChart();

                StatisticGeneratorPieChart();

                StatisticGeneratorHistoChart();

                is_live = false;
                live.Text = "LIVE OFF";
            }
        }

        private void linechart_Click(object sender, EventArgs e)
        {
            users.Columns[0].HeaderText = "MAC";
            users.Columns[1].HeaderText = "X";
            users.Columns[2].HeaderText = "Y";
            users.Rows.Clear();

            int c = 0;

            foreach (KeyValuePair<string, List<string>> entry in statisticUsersPerVendor)
            {
                c += entry.Value.Count();
            }
            if (c < 10) userCounter.Text = "0" + c.ToString();
            else userCounter.Text = c.ToString();

            cartesianChart1.Visible = true;
            pieChart1.Visible = false;
            histogramChart1.Visible = false;
        }

        private void piechart_Click(object sender, EventArgs e)
        {
            users.Columns[0].HeaderText = "MAC";
            users.Columns[1].HeaderText = "";
            users.Columns[2].HeaderText = "";
            users.Rows.Clear();

            int c = 0;

            foreach(KeyValuePair<string, List<string>> entry in statisticUsersPerVendor)
            {
                c += entry.Value.Count();
            }
            if (c < 10) userCounter.Text = "0" + c.ToString();
            else userCounter.Text = c.ToString();

            cartesianChart1.Visible = false;
            histogramChart1.Visible = false;
            pieChart1.Visible = true;
        }

        private void histochart_Click(object sender, EventArgs e)
        {
            users.Columns[0].HeaderText = "DATE-TIME";
            users.Columns[1].HeaderText = "";
            users.Columns[2].HeaderText = "";
            users.Rows.Clear();

            int c = 0;

            foreach (KeyValuePair<string, List<string>> entry in statisticUsersPerVendor)
            {
                c += entry.Value.Count();
            }
            if (c < 10) userCounter.Text = "0" + c.ToString();
            else userCounter.Text = c.ToString();

            cartesianChart1.Visible = false;
            pieChart1.Visible = false;
            //if (statisticCountPerUser.Count() < 11)
            histogramChart1.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void open_backup(string directory)
        {
            is_this_a_backup = true;

            string src = AppDomain.CurrentDomain.BaseDirectory;

            string dst = src + directory;

            string dst_file_room = Path.Combine(dst, @"room.txt");
            string dst_file_mac_list = Path.Combine(dst, @"mac_list.txt");
            string dst_file_time_and_space = Path.Combine(dst, @"time_and_space.txt");

            change_time_and_date(directory);

            //Change where to look at files
            file_room = dst_file_room;
            file_mac_list = dst_file_mac_list;
            file_time_and_space = dst_file_time_and_space;
            place_holder.Visible = false;
            place_holder2.Visible = false;
            place_holder3.Visible = false;
            place_holder6.Visible = false;

            place_holder4.Visible = true;
            place_holder5.Visible = true;
        }

        private void change_time_and_date(string directory)
        {
            directory = directory.Replace("-", ".");
            directory = directory.Replace("(", ".");
            directory = directory.Replace(")_backup", "");

            string[] words = directory.Split('.');

            dateStart.Value = new DateTime(2000 + int.Parse(words[2]), int.Parse(words[1]), int.Parse(words[0]));
            dateEnd.Value = dateStart.Value;

            time_start.Text = words[3];
            time_start2.Text = words[4];
            time_end.Text = words[5];
            time_end2.Text = words[6];
        }

        private void users_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (users.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                if (users.CurrentCell != null && users.CurrentCell.Value != null && am_I_on_backup_button && users.CurrentCell.Value.ToString() != "No backup to load")
                {
                    open_backup(users.CurrentCell.Value.ToString());
                    string title_backup = users.CurrentCell.Value.ToString();
                    label8.Text = label8.Text + " - BACKUP OF " + title_backup.Remove(21);

                    users.Rows.Clear();
                    users.Columns[0].HeaderText = "MAC";
                    users.Columns[1].HeaderText = "X";
                    users.Columns[2].HeaderText = "Y";
                    users.EnableHeadersVisualStyles = false;
                    users.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
                    users.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                    am_I_on_backup_button = false;
                }
            }
        }

        private void Panel2_Click(object sender, EventArgs e)
        {

        }

        private void Button_backup_Click(object sender, EventArgs e)
        {
            if (one_time == 0)
            {
                make_plot_visible();

                room.Controls.Clear();

                am_I_on_backup_button = true;

                label8.Text = "ESP SNIFFER";

                place_holder4.Visible = false;
                place_holder5.Visible = false;

                one_time = 1;
                users.Rows.Clear();
                users.Columns[0].HeaderText = "SELECT A BACKUP";
                users.Columns[1].HeaderText = "";
                users.Columns[2].HeaderText = "";

                place_holder6.Visible = true;

                is_there_a_room = false;
                place_holder.Visible = false;
                place_holder2.Visible = false;
                Place_holder3.Visible = false;
                room.Visible = false;

                string[] dirs = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory, "*_backup", SearchOption.TopDirectoryOnly);
                foreach (string dir in dirs)
                {
                    users.Rows.Add(dir.Replace(AppDomain.CurrentDomain.BaseDirectory, ""));
                }

                if (users.RowCount == 0)
                    users.Rows.Add("No backup to load", "");

                file_room = Path.Combine(dir_src, @"room.txt");
                file_mac_list = Path.Combine(dir_src, @"mac_list.txt");
                file_time_and_space = Path.Combine(dir_src, @"time_and_space.txt");
            }
        }

        private void Place_holder3_Click(object sender, EventArgs e)
        {

        }

        private void time_start2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void time_start_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void time_end_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void time_end2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void time_end2_Leave(object sender, EventArgs e)
        {
            time_end2.Text = put_some_zeroes(time_end2.Text);
        }

        private void time_end_Leave(object sender, EventArgs e)
        {
            time_end.Text = put_some_zeroes(time_end.Text);
        }

        private void time_start2_Leave(object sender, EventArgs e)
        {
            time_start2.Text = put_some_zeroes(time_start2.Text);
        }

        private void time_start_Leave(object sender, EventArgs e)
        {
            time_start.Text = put_some_zeroes(time_start.Text);
        }

        private String get_mac_vendor(String mac)
        {
            string line;

            string MAC = MAC_format(mac);

            string vendor = "";

            StreamReader file = new StreamReader(file_mac_vendor);

            Boolean is_private = false;

            string[] mac_div = mac.Split(':');
            var mac_tochar = mac_div[0].ToCharArray();
            if (mac_tochar[1] == '2' || mac_tochar[1] == '6' || mac_tochar[1] == 'A' || mac_tochar[1] == 'E')
                is_private = true;

                vendor = vendor + " (Private MAC)";

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(MAC))
                {
                    string[] words = line.Split('\t');
                    vendor = words[1];
                    if(is_private) vendor = vendor + " (Private MAC)";
                    return vendor;
                }
            }

            vendor = "No vendor found";
            if (is_private) vendor = vendor + " (Private MAC)";

            return vendor;
        }

        private void users_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (users.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
                if (users.CurrentCell != null && users.CurrentCell.Value != null && !am_I_on_backup_button && users.Columns[0].HeaderText == "MAC" && File.Exists(file_mac_vendor))
                {
                    mac_vendor_label.BringToFront();
                    mac_vendor_label.Text = "";

                    mac_vendor_label.Text = get_mac_vendor(users.CurrentCell.Value.ToString());

                    mac_vendor_label.Visible = true;

                    aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent2);
                    aTimer.Interval = 5000;
                    aTimer.Enabled = true;
                }
            }
        }

        private void OnTimedEvent2(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () { mac_vendor_label.Visible = false; });
            bTimer.Enabled = false;
        }

        private String MAC_format(String str)
        {
            string[] words = str.Split(':');
            str = "";
            for (int i = 0; i < 3; i++)
            {
                str = str + words[i];
            }
            return str;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //Questa funzione deve mettere gli zeri nei mac, tipo AB:3:CD... --> AB:03:CD...
        private String put_some_zeroes(String str)
        {
            string[] words = str.Split(':');
            str = "";
            for (int i = 0; i < words.Count(); i++)
            {
                if (words[i].Count() == 1)
                    words[i] = "0" + words[i].PadLeft(1, '0');

                if (i > 0) str = str + ":" + words[i];
                else str = words[i];
            }
            return str;
        }
    }
}
