using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace NyanCat
{
    public partial class NyanCat : Form
    {
        public NyanCat()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            Point MousePoint = MousePosition;
            int Frame = 0;
            string text = "Your computer has been trashed by the MEMZ Trojan. Now enjoy the Nyan Cat...";
            File.WriteAllBytes($"{Environment.GetEnvironmentVariable("Temp")}\\Minecraft.ttf", Properties.Resources.Minecraft);
            File.WriteAllBytes($"{Environment.GetEnvironmentVariable("Temp")}\\Nyan_Cat_Prelude.mp3", Properties.Resources.Nyan_Cat_Prelude);
            SoundPlayer sp = new SoundPlayer(Properties.Resources.Nyan_Cat);
            MouseClick += Exit;
            label1.MouseClick += Exit;
            MouseWheel += Exit;
            label1.MouseWheel += Exit;
            MouseMove += MouseMoved;
            label1.MouseMove += MouseMoved;
            LostFocus += LoseFocus;
            label1.LostFocus += LoseFocus;
            axWindowsMediaPlayer1.LostFocus += LoseFocus;
            KeyDown += Exit;
            void Exit(object a, EventArgs b) { Application.Exit(); }
            void LoseFocus(object a, EventArgs b) { if (!Focused && !label1.Focused && !axWindowsMediaPlayer1.Focused) { Exit(a, b); } }
            void MouseMoved(object a, EventArgs b) { if (MousePoint != MousePosition) { Exit(a, b); } }
            Cursor.Hide();
            label1.Location = new Point((Size.Width / 2) - 360, (Size.Height / 2) - 200);
            System.Windows.Forms.Timer BG_Show = new System.Windows.Forms.Timer { Interval = 1 };
            BG_Show.Tick += new EventHandler((object sender3, EventArgs e3) =>
            {
                BG_Show.Interval = 70;
                if (Frame == 0)
                {
                    BackgroundImage = Properties.Resources._00;
                }

                if (Frame == 1)
                {
                    BackgroundImage = Properties.Resources._01;
                }

                if (Frame == 2)
                {
                    BackgroundImage = Properties.Resources._02;
                }

                if (Frame == 3)
                {
                    BackgroundImage = Properties.Resources._03;
                }

                if (Frame == 4)
                {
                    BackgroundImage = Properties.Resources._04;
                }

                if (Frame == 5)
                {
                    BackgroundImage = Properties.Resources._05;
                }

                if (Frame == 6)
                {
                    BackgroundImage = Properties.Resources._06;
                }

                if (Frame == 7)
                {
                    BackgroundImage = Properties.Resources._07;
                }

                if (Frame == 8)
                {
                    BackgroundImage = Properties.Resources._08;
                }

                if (Frame == 9)
                {
                    BackgroundImage = Properties.Resources._09;
                }

                if (Frame == 10)
                {
                    BackgroundImage = Properties.Resources._10;
                }

                if (Frame == 11)
                {
                    BackgroundImage = Properties.Resources._11;
                }
                if (Frame >= 11)
                {
                    Frame = 0;
                }
                else
                {
                    Frame += 1;
                }
            });//彩虹猫
            System.Windows.Forms.Timer T_Show = new System.Windows.Forms.Timer { Interval = 20 };
            T_Show.Tick += new EventHandler((object sender2, EventArgs e2) =>
            {
                try
                {
                    label1.Text = $"{text.Substring(0, label1.Text.Length)}_";
                }
                catch
                {
                    T_Show.Enabled = false;
                    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
                    {
                        Interval = 1
                    };
                    for (int i = 0; i < 4; i++)
                    {
                        label1.Text = text;
                        if (i % 2 == 0)
                        {
                            label1.Text += " ";
                        }
                        else
                        {
                            label1.Text += "_";
                        }
                        label1.Refresh();
                        Thread.Sleep(250);
                    };
                    sp.PlayLooping();
                    timer.Enabled = false;
                    label1.Visible = false;
                    BG_Show.Enabled = true;
                }
            });//打字机
            System.Windows.Forms.Timer E_Show = new System.Windows.Forms.Timer { Interval = 2 };
            E_Show.Tick += new EventHandler((object sender1, EventArgs e1) =>
            {
                if (E_Show.Interval == 1)
                {
                    if (axWindowsMediaPlayer1.status.Substring(0, 4) == "正在播放")
                    {
                        E_Show.Interval = 5000;
                    }
                    return;
                }
                if (E_Show.Interval == 2)
                {
                    axWindowsMediaPlayer1.URL = $"{Environment.GetEnvironmentVariable("Temp")}\\Nyan_Cat_Prelude.mp3";
                    E_Show.Interval = 1;
                    return;
                }
                E_Show.Enabled = false;
                label1.AutoSize = true;
                PrivateFontCollection p = new PrivateFontCollection();
                p.AddFontFile($"{Environment.GetEnvironmentVariable("Temp")}\\Minecraft.ttf");
                label1.Font = new Font(p.Families[0], (float)10.5, FontStyle.Regular);
                label1.ForeColor = Color.Black;
                label1.BackColor = Color.White;
                label1.Text = "";
                T_Show.Enabled = true;
            });//蓝屏
            E_Show.Enabled = true;
            Show();
        }
    }
}