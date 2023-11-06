using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakBrick
{
    public partial class Form1 : Form
    {
        List<PictureBox> tuglalar=new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();

            for (int satir = 0; satir < 5; satir++)
            {
                for (int sutun = 0; sutun < 20; sutun++)
                {
                    PictureBox p = new PictureBox() { BackColor = Color.Brown, BorderStyle = BorderStyle.FixedSingle, Width = 50, Height = 20, Top = satir * 20, Left = sutun * 50 };
                    panel1.Controls.Add(p);
                    tuglalar.Add(p);
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (player.Left >= 10)
                {
                    player.Left -= 10;
                }

            }
            else if (e.KeyCode == Keys.Right)
            {
                if (player.Right <= panel1.Width - 20)
                {
                    player.Left += 10;
                }

            }
        }

        int yatayHareketYon = 2;
        int dikeyHareketYon = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (ball.Bounds.IntersectsWith(player.Bounds) && ball.Top<player.Top)
            {
                dikeyHareketYon= - 1;
            }

            foreach (var tugla in tuglalar)
            {
                if (ball.Bounds.IntersectsWith(tugla.Bounds))
                {
                    dikeyHareketYon = 1;
                    tuglalar.Remove(tugla);
                    panel1.Controls.Remove(tugla);
                    break;
                }
            }



            if (ball.Bottom >= panel1.Height)
            {
                //burada oyun biter
                timer1.Stop();
                dikeyHareketYon = -1;
                MessageBox.Show("Oyun Bitti");

            }
            else if (ball.Right >= panel1.Width)
            {
                yatayHareketYon = -2;
            }
            else if (ball.Top <= 0)
            {
                dikeyHareketYon = 1;
            }
            else if (ball.Left <= 0)
            {
                yatayHareketYon = 2;
            }




            ball.Left += yatayHareketYon;
            ball.Top += dikeyHareketYon;
        }
    }
}
