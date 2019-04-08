using System.Windows.Forms;

namespace GUI3_esp
{
    partial class Form1
    {
       
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new XComponent.SliderBar.MACTrackBar();
            this.histocharticon = new System.Windows.Forms.PictureBox();
            this.histochart = new System.Windows.Forms.Button();
            this.linecharticon = new System.Windows.Forms.PictureBox();
            this.piecharticon = new System.Windows.Forms.PictureBox();
            this.piechart = new System.Windows.Forms.Button();
            this.linechart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mac_vendor_label = new System.Windows.Forms.Label();
            this.Stats = new System.Windows.Forms.Button();
            this.live = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.userCounter = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.time_start = new System.Windows.Forms.RichTextBox();
            this.time_end2 = new System.Windows.Forms.RichTextBox();
            this.time_end = new System.Windows.Forms.RichTextBox();
            this.time_start2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.users = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.place_holder6 = new System.Windows.Forms.Label();
            this.place_holder5 = new System.Windows.Forms.Label();
            this.place_holder4 = new System.Windows.Forms.Label();
            this.place_holder3 = new System.Windows.Forms.Label();
            this.place_holder2 = new System.Windows.Forms.Label();
            this.place_holder = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.room = new System.Windows.Forms.PictureBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.histogramChart1 = new LiveCharts.WinForms.CartesianChart();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_backup = new System.Windows.Forms.Button();
            this.date_now = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histocharticon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linecharticon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piecharticon)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.users)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.room)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.histocharticon);
            this.panel1.Controls.Add(this.histochart);
            this.panel1.Controls.Add(this.linecharticon);
            this.panel1.Controls.Add(this.piecharticon);
            this.panel1.Controls.Add(this.piechart);
            this.panel1.Controls.Add(this.linechart);
            this.panel1.Location = new System.Drawing.Point(11, 595);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 61);
            this.panel1.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Transparent;
            this.trackBar1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.trackBar1.Enabled = false;
            this.trackBar1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.trackBar1.IndentHeight = 6;
            this.trackBar1.Location = new System.Drawing.Point(11, 9);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 10;
            this.trackBar1.Minimum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(701, 42);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.trackBar1.TickHeight = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.trackBar1.TrackerSize = new System.Drawing.Size(20, 20);
            this.trackBar1.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.trackBar1.TrackLineHeight = 2;
            this.trackBar1.Value = 0;
            this.trackBar1.ValueChanged += new XComponent.SliderBar.ValueChangedHandler(this.trackBar1_ValueChanged);
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // histocharticon
            // 
            this.histocharticon.Image = global::GUI3_esp.Properties.Resources.histochart;
            this.histocharticon.Location = new System.Drawing.Point(448, 20);
            this.histocharticon.Name = "histocharticon";
            this.histocharticon.Size = new System.Drawing.Size(20, 20);
            this.histocharticon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histocharticon.TabIndex = 21;
            this.histocharticon.TabStop = false;
            // 
            // histochart
            // 
            this.histochart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.histochart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.histochart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.histochart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.histochart.Location = new System.Drawing.Point(337, 15);
            this.histochart.Name = "histochart";
            this.histochart.Size = new System.Drawing.Size(136, 30);
            this.histochart.TabIndex = 20;
            this.histochart.Text = "HISTO CHART";
            this.histochart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.histochart.UseVisualStyleBackColor = false;
            this.histochart.Visible = false;
            this.histochart.Click += new System.EventHandler(this.histochart_Click);
            // 
            // linecharticon
            // 
            this.linecharticon.Image = global::GUI3_esp.Properties.Resources.linechart;
            this.linecharticon.Location = new System.Drawing.Point(128, 20);
            this.linecharticon.Name = "linecharticon";
            this.linecharticon.Size = new System.Drawing.Size(20, 20);
            this.linecharticon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linecharticon.TabIndex = 18;
            this.linecharticon.TabStop = false;
            // 
            // piecharticon
            // 
            this.piecharticon.Image = global::GUI3_esp.Properties.Resources.piechart;
            this.piecharticon.Location = new System.Drawing.Point(288, 20);
            this.piecharticon.Name = "piecharticon";
            this.piecharticon.Size = new System.Drawing.Size(20, 20);
            this.piecharticon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.piecharticon.TabIndex = 19;
            this.piecharticon.TabStop = false;
            // 
            // piechart
            // 
            this.piechart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.piechart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.piechart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piechart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.piechart.Location = new System.Drawing.Point(177, 15);
            this.piechart.Name = "piechart";
            this.piechart.Size = new System.Drawing.Size(136, 30);
            this.piechart.TabIndex = 17;
            this.piechart.Text = "PIE CHART";
            this.piechart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.piechart.UseVisualStyleBackColor = false;
            this.piechart.Visible = false;
            this.piechart.Click += new System.EventHandler(this.piechart_Click);
            // 
            // linechart
            // 
            this.linechart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.linechart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.linechart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linechart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.linechart.Location = new System.Drawing.Point(17, 15);
            this.linechart.Name = "linechart";
            this.linechart.Size = new System.Drawing.Size(136, 30);
            this.linechart.TabIndex = 16;
            this.linechart.Text = "LINE CHART";
            this.linechart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linechart.UseVisualStyleBackColor = false;
            this.linechart.Visible = false;
            this.linechart.Click += new System.EventHandler(this.linechart_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.mac_vendor_label);
            this.panel2.Controls.Add(this.Stats);
            this.panel2.Controls.Add(this.live);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.userCounter);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.dateEnd);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dateStart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.time_start);
            this.panel2.Controls.Add(this.time_end2);
            this.panel2.Controls.Add(this.time_end);
            this.panel2.Controls.Add(this.time_start2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.OK);
            this.panel2.Controls.Add(this.users);
            this.panel2.Location = new System.Drawing.Point(753, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 527);
            this.panel2.TabIndex = 2;
            this.panel2.Click += new System.EventHandler(this.Panel2_Click);
            // 
            // mac_vendor_label
            // 
            this.mac_vendor_label.AutoSize = true;
            this.mac_vendor_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mac_vendor_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.mac_vendor_label.Location = new System.Drawing.Point(14, 3);
            this.mac_vendor_label.Name = "mac_vendor_label";
            this.mac_vendor_label.Size = new System.Drawing.Size(276, 25);
            this.mac_vendor_label.TabIndex = 12;
            this.mac_vendor_label.Text = "HERE ARE THE VENDORS";
            this.mac_vendor_label.Visible = false;
            // 
            // Stats
            // 
            this.Stats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.Stats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Stats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.Stats.Location = new System.Drawing.Point(290, 375);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(100, 30);
            this.Stats.TabIndex = 15;
            this.Stats.Text = "STATS";
            this.Stats.UseVisualStyleBackColor = false;
            this.Stats.Click += new System.EventHandler(this.Stats_Click);
            // 
            // live
            // 
            this.live.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.live.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.live.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.live.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.live.Location = new System.Drawing.Point(290, 331);
            this.live.Name = "live";
            this.live.Size = new System.Drawing.Size(100, 30);
            this.live.TabIndex = 14;
            this.live.Text = "LIVE OFF";
            this.live.UseVisualStyleBackColor = false;
            this.live.Click += new System.EventHandler(this.live_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::GUI3_esp.Properties.Resources.cell1;
            this.pictureBox2.Location = new System.Drawing.Point(289, 449);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // userCounter
            // 
            this.userCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.userCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.userCounter.Location = new System.Drawing.Point(358, 452);
            this.userCounter.MaxLength = 2;
            this.userCounter.Name = "userCounter";
            this.userCounter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.userCounter.Size = new System.Drawing.Size(37, 23);
            this.userCounter.TabIndex = 13;
            this.userCounter.Text = "00";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.richTextBox1.Location = new System.Drawing.Point(333, 452);
            this.richTextBox1.MaxLength = 2;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(17, 23);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "x";
            // 
            // dateEnd
            // 
            this.dateEnd.CalendarFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEnd.Location = new System.Drawing.Point(290, 199);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.label5.Location = new System.Drawing.Point(311, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Start:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dateStart
            // 
            this.dateStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStart.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.dateStart.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dateStart.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateStart.Location = new System.Drawing.Point(290, 71);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(100, 20);
            this.dateStart.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(330, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(330, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = ":";
            // 
            // time_start
            // 
            this.time_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.time_start.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.time_start.Location = new System.Drawing.Point(303, 111);
            this.time_start.MaxLength = 2;
            this.time_start.Name = "time_start";
            this.time_start.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.time_start.Size = new System.Drawing.Size(29, 23);
            this.time_start.TabIndex = 0;
            this.time_start.Text = "00";
            this.time_start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.time_start_MouseClick);
            this.time_start.TextChanged += new System.EventHandler(this.time_start_TextChanged);
            this.time_start.Leave += new System.EventHandler(this.time_start_Leave);
            // 
            // time_end2
            // 
            this.time_end2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.time_end2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_end2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_end2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.time_end2.Location = new System.Drawing.Point(351, 243);
            this.time_end2.MaxLength = 2;
            this.time_end2.Name = "time_end2";
            this.time_end2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.time_end2.Size = new System.Drawing.Size(37, 23);
            this.time_end2.TabIndex = 6;
            this.time_end2.Text = "00";
            this.time_end2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.time_end2_MouseClick);
            this.time_end2.TextChanged += new System.EventHandler(this.time_end2_TextChanged);
            this.time_end2.Leave += new System.EventHandler(this.time_end2_Leave);
            // 
            // time_end
            // 
            this.time_end.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.time_end.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_end.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.time_end.Location = new System.Drawing.Point(303, 243);
            this.time_end.MaxLength = 2;
            this.time_end.Name = "time_end";
            this.time_end.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.time_end.Size = new System.Drawing.Size(29, 23);
            this.time_end.TabIndex = 2;
            this.time_end.Text = "00";
            this.time_end.MouseClick += new System.Windows.Forms.MouseEventHandler(this.time_end_MouseClick);
            this.time_end.TextChanged += new System.EventHandler(this.time_end_TextChanged);
            this.time_end.Leave += new System.EventHandler(this.time_end_Leave);
            // 
            // time_start2
            // 
            this.time_start2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.time_start2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.time_start2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_start2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.time_start2.Location = new System.Drawing.Point(351, 111);
            this.time_start2.MaxLength = 2;
            this.time_start2.Name = "time_start2";
            this.time_start2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.time_start2.Size = new System.Drawing.Size(37, 23);
            this.time_start2.TabIndex = 5;
            this.time_start2.Text = "00";
            this.time_start2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.time_start2_MouseClick);
            this.time_start2.TextChanged += new System.EventHandler(this.time_start2_TextChanged);
            this.time_start2.Leave += new System.EventHandler(this.time_start2_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(311, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "End:";
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.OK.Location = new System.Drawing.Point(289, 287);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 30);
            this.OK.TabIndex = 4;
            this.OK.Text = "PLOT";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // users
            // 
            this.users.AllowUserToAddRows = false;
            this.users.AllowUserToDeleteRows = false;
            this.users.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.users.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.users.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.users.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.users.DefaultCellStyle = dataGridViewCellStyle5;
            this.users.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.users.Location = new System.Drawing.Point(20, 31);
            this.users.Name = "users";
            this.users.ReadOnly = true;
            this.users.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.users.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.users.RowHeadersVisible = false;
            this.users.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.users.Size = new System.Drawing.Size(236, 475);
            this.users.TabIndex = 0;
            this.users.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.users_CellClick);
            this.users.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.users_CellContentClick);
            this.users.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.users_CellMouseClick);
            this.users.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.users_CellMouseDoubleClick);
            // 
            // Column2
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "MAC";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 165;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "X";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column3
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(157)))));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Y";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 30;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.label1.Location = new System.Drawing.Point(753, 594);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 62);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.place_holder6);
            this.panel3.Controls.Add(this.place_holder5);
            this.panel3.Controls.Add(this.place_holder4);
            this.panel3.Controls.Add(this.place_holder3);
            this.panel3.Controls.Add(this.place_holder2);
            this.panel3.Controls.Add(this.place_holder);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.room);
            this.panel3.Controls.Add(this.cartesianChart1);
            this.panel3.Controls.Add(this.histogramChart1);
            this.panel3.Controls.Add(this.pieChart1);
            this.panel3.Location = new System.Drawing.Point(11, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 527);
            this.panel3.TabIndex = 3;
            // 
            // place_holder6
            // 
            this.place_holder6.AutoSize = true;
            this.place_holder6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.place_holder6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.place_holder6.Location = new System.Drawing.Point(157, 249);
            this.place_holder6.Name = "place_holder6";
            this.place_holder6.Size = new System.Drawing.Size(404, 42);
            this.place_holder6.TabIndex = 11;
            this.place_holder6.Text = "Please select a backup";
            this.place_holder6.Visible = false;
            // 
            // place_holder5
            // 
            this.place_holder5.AutoSize = true;
            this.place_holder5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.place_holder5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.place_holder5.Location = new System.Drawing.Point(251, 272);
            this.place_holder5.Name = "place_holder5";
            this.place_holder5.Size = new System.Drawing.Size(179, 25);
            this.place_holder5.TabIndex = 10;
            this.place_holder5.Text = "Please be patient";
            this.place_holder5.Visible = false;
            // 
            // place_holder4
            // 
            this.place_holder4.AutoSize = true;
            this.place_holder4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.place_holder4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.place_holder4.Location = new System.Drawing.Point(200, 228);
            this.place_holder4.Name = "place_holder4";
            this.place_holder4.Size = new System.Drawing.Size(318, 42);
            this.place_holder4.TabIndex = 9;
            this.place_holder4.Text = "Loading Backup...";
            this.place_holder4.Visible = false;
            // 
            // place_holder3
            // 
            this.place_holder3.AutoSize = true;
            this.place_holder3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.place_holder3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.place_holder3.Location = new System.Drawing.Point(165, 295);
            this.place_holder3.Name = "place_holder3";
            this.place_holder3.Size = new System.Drawing.Size(358, 25);
            this.place_holder3.TabIndex = 8;
            this.place_holder3.Text = "Or open backup from older sessions";
            this.place_holder3.Click += new System.EventHandler(this.Place_holder3_Click);
            // 
            // place_holder2
            // 
            this.place_holder2.AutoSize = true;
            this.place_holder2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.place_holder2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.place_holder2.Location = new System.Drawing.Point(173, 270);
            this.place_holder2.Name = "place_holder2";
            this.place_holder2.Size = new System.Drawing.Size(349, 25);
            this.place_holder2.TabIndex = 7;
            this.place_holder2.Text = "Please wait until a room is selected";
            // 
            // place_holder
            // 
            this.place_holder.AutoSize = true;
            this.place_holder.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.place_holder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.place_holder.Location = new System.Drawing.Point(121, 228);
            this.place_holder.Name = "place_holder";
            this.place_holder.Size = new System.Drawing.Size(488, 42);
            this.place_holder.TabIndex = 6;
            this.place_holder.Text = "Welcome to the ESP Sniffer!";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.label7.Location = new System.Drawing.Point(314, 224);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.label7.Size = new System.Drawing.Size(128, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "11:22:33:44:55:66";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.label6.Location = new System.Drawing.Point(340, 243);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 1;
            this.label6.Visible = false;
            // 
            // room
            // 
            this.room.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.room.Location = new System.Drawing.Point(229, 163);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(248, 217);
            this.room.TabIndex = 0;
            this.room.TabStop = false;
            this.room.Visible = false;
            this.room.Paint += new System.Windows.Forms.PaintEventHandler(this.room_Paint);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(17, 17);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(688, 489);
            this.cartesianChart1.TabIndex = 3;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.Visible = false;
            this.cartesianChart1.DataClick += new LiveCharts.Events.DataClickHandler(this.cartesianChart1_DataClick);
            // 
            // histogramChart1
            // 
            this.histogramChart1.Location = new System.Drawing.Point(17, 17);
            this.histogramChart1.Name = "histogramChart1";
            this.histogramChart1.Size = new System.Drawing.Size(688, 489);
            this.histogramChart1.TabIndex = 5;
            this.histogramChart1.Text = "cartesianChart2";
            this.histogramChart1.Visible = false;
            this.histogramChart1.DataClick += new LiveCharts.Events.DataClickHandler(this.histogramChart1_DataClick);
            // 
            // pieChart1
            // 
            this.pieChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pieChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.pieChart1.Location = new System.Drawing.Point(66, 31);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(595, 463);
            this.pieChart1.TabIndex = 4;
            this.pieChart1.Text = "pieChart1";
            this.pieChart1.Visible = false;
            this.pieChart1.DataClick += new LiveCharts.Events.DataClickHandler(this.pieChart1_DataClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.label8.Location = new System.Drawing.Point(54, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "ESP SNIFFER";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            this.label8.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Yu Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.label9.Location = new System.Drawing.Point(1137, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 26);
            this.label9.TabIndex = 6;
            this.label9.Text = "x";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            this.label9.MouseEnter += new System.EventHandler(this.label9_MouseEnter);
            this.label9.MouseLeave += new System.EventHandler(this.label9_MouseLeave);
            this.label9.MouseHover += new System.EventHandler(this.label9_MouseHover);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.label10.Location = new System.Drawing.Point(1099, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 26);
            this.label10.TabIndex = 7;
            this.label10.Text = "–";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            this.label10.MouseEnter += new System.EventHandler(this.label10_MouseEnter);
            this.label10.MouseLeave += new System.EventHandler(this.label10_MouseLeave);
            this.label10.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::GUI3_esp.Properties.Resources.ICONA_ESP;
            this.pictureBox1.Location = new System.Drawing.Point(11, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button_backup
            // 
            this.button_backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button_backup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_backup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button_backup.Location = new System.Drawing.Point(1043, 594);
            this.button_backup.Name = "button_backup";
            this.button_backup.Size = new System.Drawing.Size(131, 62);
            this.button_backup.TabIndex = 16;
            this.button_backup.Text = "BACKUPS";
            this.button_backup.UseVisualStyleBackColor = false;
            this.button_backup.Click += new System.EventHandler(this.Button_backup_Click);
            // 
            // date_now
            // 
            this.date_now.AutoSize = true;
            this.date_now.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_now.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.date_now.Location = new System.Drawing.Point(1026, 12);
            this.date_now.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.date_now.Name = "date_now";
            this.date_now.Size = new System.Drawing.Size(65, 20);
            this.date_now.TabIndex = 17;
            this.date_now.Text = "00:00:00";
            this.date_now.Click += new System.EventHandler(this.label11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(58)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1188, 673);
            this.Controls.Add(this.date_now);
            this.Controls.Add(this.button_backup);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESP SNIFFER";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.histocharticon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linecharticon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piecharticon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.users)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.room)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox room;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox time_start;
        private System.Windows.Forms.RichTextBox time_end2;
        private System.Windows.Forms.RichTextBox time_end;
        private System.Windows.Forms.RichTextBox time_start2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.DataGridView users;
        private XComponent.SliderBar.MACTrackBar trackBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox userCounter;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button live;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button Stats;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button piechart;
        private System.Windows.Forms.Button linechart;
        private System.Windows.Forms.PictureBox piecharticon;
        private System.Windows.Forms.PictureBox linecharticon;
        private System.Windows.Forms.PictureBox histocharticon;
        private System.Windows.Forms.Button histochart;
        private LiveCharts.WinForms.CartesianChart histogramChart1;
        private System.Windows.Forms.Label place_holder;
        private System.Windows.Forms.Label place_holder2;
        private System.Windows.Forms.Label place_holder3;
        private Button button_backup;
        private Label place_holder4;
        private Label place_holder5;
        private Label place_holder6;
        private Label mac_vendor_label;
        private Label date_now;

        public Label Place_holder3 { get => place_holder3; set => place_holder3 = value; }
    }
}

