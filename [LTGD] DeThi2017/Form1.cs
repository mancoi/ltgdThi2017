using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _LTGD__DeThi2017
{
    public partial class Form1 : Form
    {
        int dx = 8, dy = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string nhanS = "Nhấn S để bắt đầu/dừng lại";
            Font f = new Font("Arial", 40, FontStyle.Regular);
            LinearGradientBrush lnBr = new LinearGradientBrush(new Rectangle(10, 10, 10, 10), Color.Red, Color.Gray, LinearGradientMode.ForwardDiagonal);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Center;

            Rectangle rec = new Rectangle(0, 40, ClientRectangle.Width, ClientRectangle.Height);
            e.Graphics.DrawString(nhanS, f, lnBr, rec, format);

            string nhanMuiTen = "Nhấn các phím mũi tên để chuyển hướng";
            Font f2 = new Font("Arial", 40, FontStyle.Regular);
            HatchBrush hatchBr = new HatchBrush(HatchStyle.DarkHorizontal, Color.Green, Color.Blue);
            StringFormat format2 = new StringFormat();
            format2.LineAlignment = StringAlignment.Far;
            format2.Alignment = StringAlignment.Center;

            Rectangle rec2 = new Rectangle(0, -40, ClientRectangle.Width, ClientRectangle.Height);

            e.Graphics.DrawString(nhanMuiTen, f2, hatchBr, rec2, format2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picBall.Left = ClientRectangle.Width / 2 - 59;
            picBall.Top = ClientRectangle.Height / 2 -59;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.S:
                    timer1.Enabled = !timer1.Enabled;
                    break;
                case Keys.Up:
                    if (dy == 0)
                        dy = 8;
                    if (dy > 0)
                        dy = -dy;
                    dx = 0;
                    break;
                case Keys.Down:
                    if (dy == 0)
                        dy = 8;
                    if (dy < 0)
                        dy = -dy;
                    dx = 0;
                    break;
                case Keys.Left:
                    if (dx == 0)
                        dx = 8;
                    if (dx > 0)
                        dx = -dx;
                    dy = 0;
                    break;
                case Keys.Right:
                    if (dx == 0)
                        dx = 8;
                    if (dx < 0)
                        dx = -dx;
                    dy = 0;
                    break;
                case Keys.PageUp:
                    if (dx > 0)
                        dx++;
                    else if (dx < 0)
                        dx--;
                    else if (dy > 0)
                        dy++;
                    else if (dy < 0)
                        dy--;
                    break;
                case Keys.PageDown:
                    if (dx > 0)
                        dx--;
                    else if (dx < 0)
                        dx++;
                    else if (dy > 0)
                        dy--;
                    else if (dy < 0)
                        dy++;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picBall.Left <= 0)
                picBall.Left = ClientRectangle.Width - 118;
            if (picBall.Left >= ClientRectangle.Width)
                picBall.Left = 0;
            if (picBall.Top <= 0)
                picBall.Top = ClientRectangle.Height - 118;
            if (picBall.Top >= ClientRectangle.Height)
                picBall.Top = 0;
            picBall.Left += dx;
            picBall.Top += dy;
        }

        private void menuChangeBackColor(object sender, EventArgs e)
        {
            ColorDialog clDialog = new ColorDialog();
            clDialog.FullOpen = true;
            if (clDialog.ShowDialog() == DialogResult.OK)
                this.BackColor = clDialog.Color;
        }

        private void menuChangeImage(object sender, EventArgs e)
        {
            OpenFileDialog opfDialog = new OpenFileDialog();
            opfDialog.Filter = "jpeg file (*.jpg)|*.jpg|"
                                + "gif file (*.gif)|*.gif|"
                                + "png file (*.png)|*.png|"
                                + "bmp file (*.bmp)|*.bmp";
            if (opfDialog.ShowDialog() == DialogResult.OK)
                picBall.Image = Image.FromFile(opfDialog.FileName);
        }

    }
}
