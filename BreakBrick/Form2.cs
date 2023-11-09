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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();


            for (int dikeyTuglaSayisi = 0; dikeyTuglaSayisi < 4; dikeyTuglaSayisi++)
            {
                for (int yatayTuglaSayisi = 0; yatayTuglaSayisi < 20; yatayTuglaSayisi++)
                {
                    PictureBox brick = new PictureBox();
                    brick.BackColor = Color.Brown;
                    brick.Size = new Size(50, 20);
                    brick.BorderStyle = BorderStyle.FixedSingle;
                    brick.Location = new Point(yatayTuglaSayisi * 50, 20*dikeyTuglaSayisi);
                    brick.Tag = "brick";
                    panel1.Controls.Add(brick);
                }
            }         
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
          this.Text=player.Left.ToString();
            if (e.KeyCode==Keys.Left && player.Left>=10)
            {
                player.Left -= 10;
            }
            else if(e.KeyCode==Keys.Right && player.Right<panel1.Width) 
            {
                player.Left += 10;
            }
        }

        int ballDirectionX = 2;
        int ballDirectionY =2;

        private void timer1_Tick(object sender, EventArgs e)
        {

            //alt kenara değerse oyun biter
            if (ball.Bottom>=panel1.Height)
            {
                timer1.Stop();
                MessageBox.Show("Oyun Bitti!");
            }

            foreach (var control in panel1.Controls)
            {
                if (control is PictureBox p)
                {
                    if (p.Tag!=null && p.Tag.ToString()=="brick")
                    {
                        if (ball.Bounds.IntersectsWith(p.Bounds))
                        {
                            ballDirectionY *= -1;
                            panel1.Controls.Remove(p);
                            break;
                        }
                    }
                }
            }


            if (ball.Bounds.IntersectsWith(player.Bounds)|| ball.Top <= 0)
            {
                ballDirectionY *= -1;
            }
            if (ball.Right>=panel1.Width|| ball.Left <= 0)
            {
                ballDirectionX *= -1;
            }
         
            

           ball.Location=new Point(ball.Left+ballDirectionX, ball.Top+ballDirectionY);
        }
    }
}
