using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketQuest
{
    public partial class MainWindow : Form
    {
        HitBox hitbox = new HitBox(); 
        Timer timerAction = new Timer();//Таймер на обновление

        public MainWindow()
        {
            InitializeComponent();
            DoubleBuffered = true;

            hitbox.Width = 100;
            hitbox.Height = 100;
            hitbox.X = 10;
            hitbox.Y = 10;

            timerAction.Enabled = true;//Конфиги таймера
            timerAction.Interval = 10;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Событие тика"
            timerAction.Start();

            this.KeyDown += new KeyEventHandler(Keys_Down);

        }

        private void Keys_Down(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    hitbox.Y += 10;
                    break;
                case Keys.Left:
                    hitbox.X -= 10;
                    break;
                case Keys.Right:
                    hitbox.X += 10;
                    break;
                case Keys.Up:
                    hitbox.Y -= 10;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            hitbox.ScreenHeight = this.Size.Height;
            hitbox.ScreenWidth = this.Size.Width;
        }

        private void timerAction_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            RocketAppClosing();
        }

        private void RocketAppClosing()
        {
            this.Close();
        } 

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(Brushes.Blue, hitbox.X, hitbox.Y, hitbox.Width, hitbox.Height);
            e.Graphics.ResetTransform();
        }
    }
}
