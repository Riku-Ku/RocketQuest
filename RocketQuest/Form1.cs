﻿using RocketQuest.Actors;
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

        int rocketSpeed = 10, meteorSpeed = 5;//Скорость ракеты
        bool isWdown, isAdown, isSdown, isDdown;
        Random randGenerator = new Random();

        Rocket player = new Rocket(100, 70, 0, 0, RocketQuest.Properties.Resources.Player);
        Meteor[] meteors = new Meteor[10];//масив метеоритов

        public MainWindow()
        {
            InitializeComponent();
            this.BackgroundImage = RocketQuest.Properties.Resources.backGRND;


            for(int i = 0; i < 10; i++)//добавление метеоритов в
            {
                int temp = randGenerator.Next(20, 100);
                meteors[i] = new Meteor(temp, temp, randGenerator.Next(this.Width), randGenerator.Next(this.Height), RandomMeteorSkin());
            }


            timerAction.Enabled = true;//Конфиги таймера
            timerAction.Interval = 10;
            timerAction.Tick += new EventHandler(timerAction_Tick);//"Событие тика"
            timerAction.Start();
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
            player.SetBorders(this.Width, this.Height);
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(player.RocketSkin, player.X, player.Y, player.Width, player.Height);

            foreach(Meteor meteor in meteors)
            {
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
            }
            return RocketQuest.Properties.Resources.meteorGrey_big2;
        }
    }
}
