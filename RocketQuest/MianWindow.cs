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

//старый код this.BackgroundImage = RocketQuest.Properties.Resources.backGRND;


namespace RocketQuest
{
    public partial class MainWindow : Form
    {
        Timer timerAction = new Timer();//Таймер на обновление
        Timer timerDelayBeforeMeteor = new Timer();//Таймер на задержку перед первым появлвением метеоров

        public static bool isWdown, isAdown, isSdown, isDdown;//Чек клавиш


        public MainWindow()
        {
            InitializeComponent();

            timerAction.Interval = 20;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Тик главного таймера"

            timerDelayBeforeMeteor.Interval = 4500;
            timerDelayBeforeMeteor.Tick += new EventHandler(timerDelay_Tick);//Дописать событие тика!!!!!!!!!!!(ускорение метеоров)
        }

        private void timerAction_Tick(object sender, EventArgs e)//"Событие тика главного таймера"
        {
            this.Invalidate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            MenuConfig(this);//Конфиги меню
            scoreDisplay.Location = new Point(Screen.FromControl(this).Bounds.Width - scoreDisplay.Size.Width - 30, 15);


            World
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            

            e.Graphics.DrawImage(player.RocketSkin, player.GetX, player.GetY, player.Width, player.Height);

            foreach (Meteor meteor in meteors)
            {

                if (ColissionChecker.Colussion(meteor, player))
                {
                    GameStop();
                    menuPanel.Show();
                }

                if (ColissionChecker.MeteorOutCheck(meteor, this.Width, this.Height))
                {
                    
                }
                else
                    e.Graphics.DrawImage(meteor.MeteorSkin, meteor.GetX, meteor.GetY, meteor.Width, meteor.Height);
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

        private void startBTN_Click_1(object sender, EventArgs e)
        {
            GameStart();
            menuPanel.Hide();
            
        }

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

            AddPlayerScoreToList();
            DisplayScoreInList();
            ScoreWriter();
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
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ScoreReader()
        {
            if (File.Exists(scorePath))
            {
                using (var sr = new StreamReader(scorePath))//считывание из файла
                {
                    string temp = "";
                    Regex firstItemRegex = new Regex(@"[(]\w+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    Regex secondItemRegex = new Regex(@"[,][ ]\w+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    while ((temp = sr.ReadLine()) != null)
                    {
                        scoreHolder.Add(new Tuple<string, int>(Convert.ToString(firstItemRegex.Match(temp)).Substring(1),
                            Convert.ToInt32(Convert.ToString(secondItemRegex.Match(temp)).Substring(2))));
                    }
                }
                scoreHolder = scoreHolder.OrderByDescending(s => s.Item2).ToList();
            }
            else
            {
                using (FileStream fs = File.Create(scorePath))//Создание файла
                {
                }
            }
        }

        private void ScoreWriter()
        {
            using (StreamWriter outputFile = new StreamWriter(scorePath))//Запись в файл
            {
                string temp = default;
                for (int i = 0; i < scoreHolder.Count; i++)
                {
                    temp += scoreHolder[i] + Environment.NewLine;
                }
                outputFile.Write("");
                outputFile.Write(temp);
            }
        }

        private void DisplayScoreInList()//Запись в лист в меню
        {
            scoreList.Items.Clear();

            for (int i = 0; i < scoreHolder.Count; i++)
            {
                scoreList.Items.Add(scoreHolder[i]);
            }
        }

        private void AddPlayerScoreToList()
        {
            
            //scoreHolder = scoreHolder.Where(s )

            if(scoreHolder.Count > 0)
            {

                for (int i = 0; i < scoreHolder.Count; i++)
                {
                    if (scoreHolder[i].Item1 == nickName.Text)
                    {
                        if(scoreHolder[i].Item2 < score)
                        {
                            scoreHolder[i] = new Tuple<string, int>(nickName.Text, score);
                            break;
                        }
                    }
                    else if(!(scoreHolder[i].Item1 == nickName.Text))
                    {
                        scoreHolder.Add(new Tuple<string, int>(nickName.Text, score));
                        break;
                    }
                }
            }
            else
                scoreHolder.Add(new Tuple<string, int>(nickName.Text, score));

            scoreHolder = scoreHolder.OrderByDescending(s => s.Item2).ToList();
        }
    }
}
