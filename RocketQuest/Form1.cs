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
        HitBox hitboxRocket = new HitBox();
        HitBox hitboxMeteor = new HitBox();
        

        
        Timer timerAction = new Timer();//Таймер на обновление
        Timer timerMeteorMover = new Timer();//Таймер на движение метеора
        int rocketSpeed = 20, meteorSpeed = 5;//Скорость ракеты
        bool isWdown, isAdown, isSdown, isDdown;

        public MainWindow()
        {
            InitializeComponent();
            DoubleBuffered = true;

            hitboxRocket.Width = 100;
            hitboxRocket.Height = 60;
            

            hitboxMeteor.Height = 30;
            hitboxMeteor.Width = 30;
            

            timerAction.Enabled = true;//Конфиги таймера
            timerAction.Interval = 100;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Событие тика"
            timerAction.Start();

            timerMeteorMover.Enabled = true;//Конфиги таймера
            timerMeteorMover.Interval = 500;
            timerMeteorMover.Tick += new EventHandler(timerMeteorMover_Tick);//"Событие тика"
            timerMeteorMover.Start();

            this.KeyDown += new KeyEventHandler(Keys_Down);
        }

        private void Keys_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) isWdown = true;
            if (e.KeyCode == Keys.A) isAdown = true;
            if (e.KeyCode == Keys.S) isSdown = true;
            if (e.KeyCode == Keys.D) isDdown = true;
        }
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) isWdown = false;
            if (e.KeyCode == Keys.A) isAdown = false;
            if (e.KeyCode == Keys.S) isSdown = false;
            if (e.KeyCode == Keys.D) isDdown = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            hitboxMeteor.ScreenHeight = this.Size.Height;
            hitboxMeteor.ScreenWidth = this.Size.Width;

            hitboxRocket.ScreenHeight = this.Size.Height;
            hitboxRocket.ScreenWidth = this.Size.Width;

            hitboxRocket.X = 100;
            hitboxRocket.Y = 100;

            hitboxMeteor.X = this.Size.Width - hitboxMeteor.Width;
            hitboxMeteor.Y = this.Size.Height /2;
        }

        private void timerMeteorMover_Tick(object sender, EventArgs e)
        {
            hitboxMeteor.X -= meteorSpeed;
        }

            private void timerAction_Tick(object sender, EventArgs e)
        {
            if (isWdown) hitboxRocket.Y -= rocketSpeed;
            if (isSdown) hitboxRocket.Y += rocketSpeed;
            if (isAdown) hitboxRocket.X -= rocketSpeed;
            if (isDdown) hitboxRocket.X += rocketSpeed;

             
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
            e.Graphics.FillRectangle(Brushes.Blue, hitboxRocket.X, hitboxRocket.Y, hitboxRocket.Width, hitboxRocket.Height);
            e.Graphics.FillRectangle(Brushes.Red, hitboxMeteor.X, hitboxMeteor.Y, hitboxMeteor.Width, hitboxMeteor.Height);
            e.Graphics.ResetTransform();
        }

        private void MeteorSpawn(PaintEventArgs e)
        {
            
            
        }

    }
}
