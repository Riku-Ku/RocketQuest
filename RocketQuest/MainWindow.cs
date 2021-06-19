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
using System.IO;
using System.Text.RegularExpressions;
using RocketQuest.Graphics;

//старый код this.BackgroundImage = RocketQuest.Properties.Resources.backGRND;


namespace RocketQuest
{
    public partial class MainWindow : Form
    {
        Timer timerAction = new Timer();//Таймер на обновление
        Timer timerСomplexity = new Timer();//Таймер на задержку перед первым появлвением метеоров

        public static bool isWdown, isAdown, isSdown, isDdown;//Чек клавиш

        World space = new World();//Генерация мира
        Scores scores = new Scores();


        public MainWindow()
        {
            InitializeComponent();

            timerAction.Interval = 20;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Тик главного таймера"

            timerСomplexity.Interval = 5000;
            timerСomplexity.Tick += new EventHandler(timerСomplexity_Tick);//Дописать событие тика!!!!!!!!!!!(ускорение метеоров)
        }

        private void timerСomplexity_Tick(object sender, EventArgs e)//повышение сложности
        {
            space.СomplexityIncreasing();
        }

        private void timerAction_Tick(object sender, EventArgs e)//"Событие таймера мира"
        {
            if (space.WorldFrame())
            {
                GameStop();
            }

            this.Invalidate();

            scores.AddScore();//Добавление очков

            scoreDisplay.Text = Convert.ToString(scores.scoreGeter);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            scores.ScoreReader();//чтение из файла

            scoreList.DataSource = scores.GetStringScoreData();

            MenuConfig(this);//внешка менб
        }



        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            foreach(HitBox meteorHitBox in space.GetMeteors())
            {
                e.Graphics.DrawImage(DrawingTools.RandomMeteorSkin(), meteorHitBox.GetX, meteorHitBox.GetY, meteorHitBox.Width, meteorHitBox.Height);
            }
            e.Graphics.DrawImage(RocketQuest.Properties.Resources.Player, space.GetPlayerData().GetX, space.GetPlayerData().GetY, space.GetPlayerData().Width, space.GetPlayerData().Height);
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

        private void startBTN_Click_1(object sender, EventArgs e)//кнопка старт нажата
        {
            space.SetBorders(this.Width, this.Height);//screen size
            space.InitializeMeteors();//спавн метеоров

            timerAction.Enabled = true;
            timerAction.Start();

            timerСomplexity.Enabled = true;
            timerСomplexity.Start();

            menuPanel.Hide();

            scoreDisplay.Location = new Point(Screen.FromControl(this).Bounds.Width - scoreDisplay.Size.Width - 30, 15);//отображение очков
            scoreDisplay.Show();
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            //scores.ScoreWriter();
        }

        private void GameStop()
        {
            timerAction.Stop();
            timerAction.Enabled = false;

            timerСomplexity.Stop();
            timerСomplexity.Enabled = false;

            scoreDisplay.Hide();

            menuPanel.Show();

            stateLabel.Text = "Ваш счет: " + scores.scoreGeter;

            scores.AddPlayerScoreToList(nickNameField.Text);
            scores.ScoreWriter();
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

            nickNameField.Size = new Size((int)(menuPanel.Width * 0.2), 40);
            nickNameField.Font = new Font("Arial", 18, FontStyle.Bold);
            nickNameField.PlaceholderText = "ВВЕДИТЕ НИК";
            nickNameField.Location = new Point((int)(menuPanel.Width * 0.5) - nickNameField.Width - 20, startBTN.Location.Y + nickNameField.Height * 3);
            //nickName.BackColor = Color.FromArgb(178, 115, 72, 171);

            exitBTN.Size = new Size((int)(menuPanel.Width * 0.2), 60);
            exitBTN.Font = new Font("Arial", 20, FontStyle.Bold);
            exitBTN.Location = new Point((int)(menuPanel.Width * 0.5) - nickNameField.Width - 20, nickNameField.Location.Y + exitBTN.Height +15);
            exitBTN.Text = "ВЫХОД";
            exitBTN.ForeColor = Color.White;
            exitBTN.FlatStyle = FlatStyle.Flat;
            exitBTN.BackColor = Color.FromArgb(178, 115, 72, 171);

            scoreList.Location = new Point((int)(menuPanel.Width * 0.5) + 20, startBTN.Location.Y + nickNameField.Height * 3);
            scoreList.Size = new Size((int)(menuPanel.Width * 0.2), exitBTN.Height * 2 + nickNameField.Height);
            scoreList.Font = new Font("Arial", 18);
        }
    }
}
