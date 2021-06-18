using RocketQuest.Actors;
using RocketQuest.Physics;
//using RocketQuest.MenuItems;
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
        Timer timerDelayBeforeMeteor = new Timer();//Таймер на задержку перед первым появлвением метеоров
        
        
        //PanelMenuMain panelM = new PanelMenuMain();//Задник меню

        int rocketSpeed = 15, meteorSpeed = 10, score;//Скорость ракеты
        static int meteorCount = 10;//Кол-во метеоритов
        bool isWdown, isAdown, isSdown, isDdown;
        Random randGenerator = new Random();

        Rocket player = new Rocket(100, 70, 0, 0, RocketQuest.Properties.Resources.Player);
        Meteor[] meteors = new Meteor[meteorCount];//масив метеоритов


        public MainWindow()
        {
            InitializeComponent();

            this.BackgroundImage = RocketQuest.Properties.Resources.backGRND;

            //Конфиги таймера
            timerAction.Interval = 20;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Тик главного таймера"
            //


            //Конфиги таймера сложности
            timerDelayBeforeMeteor.Interval = 4500;
            timerDelayBeforeMeteor.Tick += new EventHandler(timerDelay_Tick);
            //
        }

        private void timerDelay_Tick(object sender, EventArgs e)//"Событие тика таймера сложности"
        {
            meteorSpeed += 2;
        }

        private void timerAction_Tick(object sender, EventArgs e)//"Событие тика главного таймера"
        {
            OnPlayerMove();

            score++;
            scoreDisplay.Text = score.ToString();


            foreach (Meteor meteor in meteors)
            {
                meteor.X -= meteorSpeed;
            }

            this.Invalidate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            player.SetBorders(this.Width, this.Height);

            MenuConfig(this);
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            scoreDisplay.Location = new Point(Screen.FromControl(this).Bounds.Width - scoreDisplay.Size.Width - 5, 15);

            e.Graphics.DrawImage(player.RocketSkin, player.X, player.Y, player.Width, player.Height);

            foreach (Meteor meteor in meteors)
            {

                if (ColissionChecker.Colussion(meteor, player))
                {
                    GameStop();
                    menuPanel.Show();
                }

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

        private void startBTN_Click_1(object sender, EventArgs e)
        {
            GameStart();
            menuPanel.Hide();
            
        }

        private void SetEventsToBTN(Panel panelMenuBack)
        {
            //panelMenuBack. += new EventHandler(StartBTN_Click);
        }

        //private void StartBTN_Click(object sender, System.EventArgs e)
        //{
        //    GameStart();
        //    scoreDisplay.Show();
        //    MessageBox.Show("ЪьЪьЪ");
        //}

        private void GameStart()
        {
            GameInitilize();

            timerAction.Enabled = true;
            timerAction.Start();
            timerDelayBeforeMeteor.Enabled = true;
            timerDelayBeforeMeteor.Start();

            score = 0;
            scoreDisplay.Show();
        }

        private void GameStop()
        {
            timerAction.Stop();
            timerAction.Enabled = false;

            timerDelayBeforeMeteor.Stop();
            timerDelayBeforeMeteor.Enabled = false;

            scoreDisplay.Hide();

            stateLabel.Text = "Ваш счет: " + score;
        }

        private void MenuConfig(Form formMain) //онфиги меню
        {
            scoreDisplay.ForeColor = Color.White;
            //scoreDisplay.TextAlign = ContentAlignment.MiddleRight;
            scoreDisplay.BackColor = Color.Transparent;
            scoreDisplay.Font = new Font("Arial", 18, FontStyle.Bold);
            scoreDisplay.Hide();

            Size menuSize = new Size(formMain.Width, formMain.Height);
            menuPanel.Size = menuSize;
            menuPanel.Location = new Point(0, 0);
            menuPanel.BackgroundImage = RocketQuest.Properties.Resources.menuBackGr;
            menuPanel.BackgroundImageLayout = ImageLayout.Stretch;
            menuPanel.BringToFront();

            stateLabel.Text = "ГЛАВНОЕ МЕНЮ";
            stateLabel.Font = new Font("Arial", 28, FontStyle.Bold);
            stateLabel.ForeColor = Color.White;
            stateLabel.Location = new Point((int)(menuPanel.Width * 0.5) - (int)(stateLabel.Width * 0.5), (int)(stateLabel.Height * 0.2));
            stateLabel.BackColor = Color.Transparent;

            startBTN.Size = new Size((int)(menuPanel.Width * 0.2), 60);
            startBTN.Location = new Point((int)(menuPanel.Width * 0.5) - (int)(startBTN.Width * 0.5), (int)(menuPanel.Height * 0.3));
            startBTN.Text = "ИГРАТЬ!";
            startBTN.Font = new Font("Arial", 20, FontStyle.Bold);
            startBTN.ForeColor = Color.White;
            startBTN.FlatStyle = FlatStyle.Flat;
            startBTN.BackColor = Color.FromArgb(178, 115, 72, 171);

            nickName.Size = new Size((int)(menuPanel.Width * 0.2), 40);
            nickName.Font = new Font("Arial", 18, FontStyle.Bold);
            nickName.PlaceholderText = "ВВЕДИТЕ НИК";
            nickName.Location = new Point((int)(menuPanel.Width * 0.5) - nickName.Width - 20, startBTN.Location.Y + nickName.Height * 3);
            //nickName.BackColor = Color.FromArgb(178, 115, 72, 171);

            exitBTN.Size = new Size((int)(menuPanel.Width * 0.2), 60);
            exitBTN.Font = new Font("Arial", 20, FontStyle.Bold);
            exitBTN.Location = new Point((int)(menuPanel.Width * 0.5) - nickName.Width - 20, nickName.Location.Y + exitBTN.Height +15);
            exitBTN.Text = "ВЫХОД";
            exitBTN.ForeColor = Color.White;
            exitBTN.FlatStyle = FlatStyle.Flat;
            exitBTN.BackColor = Color.FromArgb(178, 115, 72, 171);

            scoreList.Location = new Point((int)(menuPanel.Width * 0.5) + 20, startBTN.Location.Y + nickName.Height * 3);
            scoreList.Size = new Size((int)(menuPanel.Width * 0.2), exitBTN.Height * 2 + nickName.Height);
            scoreList.Font = new Font("Arial", 18);
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");
            scoreList.Items.Add("pepe");

        }

        private void GameInitilize()//конфиги применяемые перед началом игры
        {
            player.X = (int)(Screen.FromControl(this).Bounds.Width * 0.5);
            player.Y = (int)(Screen.FromControl(this).Bounds.Height * 0.5);
            
            for (int i = 0; i < meteors.Length; i++)//добавление метеоритов в
            {
                int temp = randGenerator.Next(20, 100);
                meteors[i] = new Meteor(temp, temp, Screen.FromControl(this).Bounds.Width + randGenerator.Next(Screen.FromControl(this).Bounds.Width), randGenerator.Next(Screen.FromControl(this).Bounds.Height), RandomMeteorSkin());
            }
        }
    }
}
