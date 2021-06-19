using System;
using System.Collections.Generic;
using System.Text;
using RocketQuest.Actors;
using RocketQuest.Physics;

namespace RocketQuest
{
    class World
    {
        Random randGenerator = new Random();

        static int playerSpeed = 10, meteorSpeed = -20, meteorCount = 10, complexity = -5, screenWidth = 0, screenHeight = 0;//Кол-во метеоритов

        HitBox player = new HitBox(10, 80, 100, 60, 0, 0);//игрок
        HitBox[] meteors = new HitBox[meteorCount];
        
        public HitBox[] GetMeteors()
        {
            return meteors;
        }

        public HitBox GetPlayerData()
        {
            return player;
        }

        public bool WorldFrame()//положение мира
        {
            PlayerMover();
            MeteorMover();

            foreach (HitBox meteorHitBox in meteors)//чек на столкновение
            {
                if (ColissionChecker.Colission(player, meteorHitBox))
                {
                    return true;
                }
            }
            return false;
        }

        private void MeteorMover()//перемещение метеора
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                if (ColissionChecker.MeteorOutCheck(meteorHitBox))//чек на выход за поле
                {
                    meteorHitBox.SetLocation(randGenerator.Next(screenWidth) + screenWidth, screenHeight);
                }
                else
                {
                    meteorHitBox.Move();
                }
            }
        }

        private void PlayerMover()//Передвижение игрока
        {
            if (ColissionChecker.CheckPlayerMoving(player, screenWidth, screenHeight))
            {
                if (MainWindow.isWdown)
                    player.SetSpeed(0, -playerSpeed);
                else if (MainWindow.isAdown)
                    player.SetSpeed(-playerSpeed, 0);
                else if (MainWindow.isSdown)
                    player.SetSpeed(0, playerSpeed);
                else if (MainWindow.isDdown)
                    player.SetSpeed(playerSpeed, 0);
            }
            else
            {
                player.SetSpeed(0, 0);
            }

            player.Move();
        }

        public void SetBorders(int screenWidthValue, int screenHeightValue)//значения экрана
        {
            if (screenWidthValue > 0 & screenHeightValue > 0)
            {
                screenWidth = screenWidthValue;
                screenHeight = screenHeightValue;
            }
            else
                throw new ArgumentException("Screen Width & Height always > 0");
        }


        public void InitializeMeteors()//первичное создание метеоров
        {
            for(int i = 0; i < meteors.Length; i++)
            {
                int meteorTempSize = randGenerator.Next(20, 100);
                meteors[i] = new HitBox(randGenerator.Next(screenWidth) + screenWidth, randGenerator.Next(screenHeight),
                    meteorTempSize, meteorTempSize, meteorSpeed, 0);
            }
        }

        public void СomplexityIncreasing()//Увеличение сложности
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                meteorHitBox.SetSpeed(meteorHitBox.GetSpeedX + complexity, 0);
            }
        }

        public void СomplexityRest()//Сброс сложности
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                meteorHitBox.SetSpeed(meteorSpeed, 0);
            }
        }

        public void WorldRestart()
        {

        }
    }
}
