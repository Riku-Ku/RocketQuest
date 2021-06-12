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

            hitbox.SetWidth = 400;
            hitbox.SetHeight = 300;
            hitbox.SetPoint = new Point(20, 30);

            timerAction.Enabled = true;//Конфиги таймера
            timerAction.Interval = 50;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Событие тика"
            timerAction.Start();

            this.KeyDown += new KeyEventHandler(Keys_Down); 
        }

        private void Keys_Down(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    hitbox.SetPoint = new Point(hitbox.SetPoint.X, hitbox.SetPoint.Y + 5);
                    break;
                case Keys.Left:
                    hitbox.SetPoint = new Point(hitbox.SetPoint.X - 5, hitbox.SetPoint.Y);
                    break;
                case Keys.Right:
                    hitbox.SetPoint = new Point(hitbox.SetPoint.X + 5, hitbox.SetPoint.Y);
                    break;
                case Keys.Up:
                    hitbox.SetPoint = new Point(hitbox.SetPoint.X, hitbox.SetPoint.Y - 5);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

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
            e.Graphics.FillRectangle(Brushes.Blue, hitbox.SetPoint.X, hitbox.SetPoint.Y, hitbox.SetWidth, hitbox.SetHeight);
        }
    }
}
