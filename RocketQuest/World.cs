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

        static int playerSpeed = 25, meteorSpeed = -20, meteorCount = 10, complexity = -5, screenWidth = 0, screenHeight = 0;//Кол-во метеоритов

        HitBox player = new HitBox(100, 70, 0, 0, 0, 0);//игрок
        HitBox[] meteors = new HitBox[meteorCount];
        

        public void WorldFrame()//положение мира
        {
            PlayerMover();
            MeteorMover();
        }

        private void MeteorMover()//перемещение метеора
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                if (ColissionChecker.MeteorOutCheck(meteorHitBox))
                {
                    meteorHitBox.SetLocation(randGenerator.Next(screenWidth) + randGenerator.Next(screenWidth), screenHeight);
                }
                else
                {
                    meteorHitBox.Move();
                }
            }
        }

        private void PlayerMover()//Передвижение игрока
        {
            if (ColissionChecker.CheckPlayerMoving(player))
            {
                if (MainWindow.isWdown)
                    player.SetSpeed(0, -playerSpeed);
                else if (MainWindow.isAdown)
                    player.SetSpeed(-playerSpeed, 0);
                else if(MainWindow.isSdown)
                    player.SetSpeed(0, playerSpeed);
                else if (MainWindow.isDdown)
                    player.SetSpeed(playerSpeed, 0);
            }
            player.Move();
        }

        public void InitializeMeteors()//первичное создание метеоров
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                meteorHitBox.SetSpeed(meteorSpeed, 0);
            }
        }

        private void СomplexityIncreasing()//Увеличение сложности
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                meteorHitBox.SetSpeed(meteorHitBox.GetSpeedX + complexity, 0);
            }
        }

        private void СomplexityRest()//Сброс сложности
        {
            foreach (HitBox meteorHitBox in meteors)
            {
                meteorHitBox.SetSpeed(meteorSpeed, 0);
            }
        }
    }
}
