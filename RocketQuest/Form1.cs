using RocketQuest.Actors;
using RocketQuest.Physics;
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
        Timer timerAction = new Timer();//Таймер на обновление
        Timer timerMeteorMover = new Timer();//Таймер на движение метеора
        Timer timerDelayBeforeMeteor = new Timer();//Таймер на задержку перед первым появлвением метеоров


        int rocketSpeed = 15, meteorSpeed = 25, score = 0;//Скорость ракеты
        static int meteorCount = 10;//Кол-во метеоритов
        bool isWdown, isAdown, isSdown, isDdown, delayEnd;
        Random randGenerator = new Random();

        Rocket player = new Rocket(100, 70, 0, 0, RocketQuest.Properties.Resources.Player);
        Meteor[] meteors = new Meteor[meteorCount];//масив метеоритов

        public MainWindow()
        {
            InitializeComponent();
            
            //this.BackgroundImage = RocketQuest.Properties.Resources.backGRND;
            this.BackColor = Color.Black;
            Cursor.Hide();
                for (int i = 0; i < meteors.Length; i++)//добавление метеоритов в
                {
                    int temp = randGenerator.Next(20, 100);
                    meteors[i] = new Meteor(temp, temp, randGenerator.Next(Screen.FromControl(this).Bounds.Width), randGenerator.Next(Screen.FromControl(this).Bounds.Height), RandomMeteorSkin());
                }



            timerAction.Enabled = true;//Конфиги таймера
            timerAction.Interval = 25;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Событие тика"
            timerAction.Start();


            timerDelayBeforeMeteor.Enabled = true;//Конфиги таймера
            timerDelayBeforeMeteor.Interval = 5000;
            timerDelayBeforeMeteor.Tick += new EventHandler(timerDelay_Tick);//"Событие тика"
            timerDelayBeforeMeteor.Start();
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            meteorSpeed += 2;
            score+=5;
            label1.Text = Convert.ToString(score);
        }

        private void timerAction_Tick(object sender, EventArgs e)
        {
            OnPlayerMove();

            
                foreach (Meteor meteor in meteors)
                {
                    meteor.X -= meteorSpeed;
                }

            this.Invalidate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //label1.Location.X = Screen.FromControl(this).Bounds.Width - 20; /*new Point((Screen.FromControl(this).Bounds.Width - 20, Screen.FromControl(this).Bounds.Height));*/
            player.SetBorders(this.Width, this.Height);
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(player.RocketSkin, player.X, player.Y, player.Width, player.Height);
            
                foreach (Meteor meteor in meteors)
                {
                
                    if (ColissionChecker.Colussion(meteor,player))                    
                        this.Close();
                    
                    if (ColissionChecker.OutFromScreen(meteor, this.Width, this.Height))
                    {
                        meteor.Y = randGenerator.Next(this.Height);
                        meteor.X = this.Width + randGenerator.Next(100);
                    }
                    else
                        e.Graphics.DrawImage(meteor.MeteorSkin, meteor.X, meteor.Y, meteor.Width, meteor.Height);
                }
                
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
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

        private void OnPlayerMove()
        {
            if (isWdown) player.Moving(0, -rocketSpeed);
            if (isAdown) player.Moving(-rocketSpeed, 0);
            if (isSdown) player.Moving(0, rocketSpeed);
            if (isDdown) player.Moving(rocketSpeed, 0);
        }

        private Bitmap RandomMeteorSkin()
        {
            switch (randGenerator.Next(4))
            {
                case (0):
                    return RocketQuest.Properties.Resources.meteorBrown_big1;
                case (1):
                    return RocketQuest.Properties.Resources.meteorBrown_big3;
                case (2):
                    return RocketQuest.Properties.Resources.meteorGrey_big1;
                default:
                    return RocketQuest.Properties.Resources.meteorGrey_big2;
            }          
        }
    }
}
