using System;
using System.Collections.Generic;
using System.Text;
using RocketQuest.Actors;

namespace RocketQuest
{
    class World
    {
        static int rocketSpeed = 25, meteorSpeed = -20, meteorCount = 10, complexity = 5;//Кол-во метеоритов

        HitBox player = new HitBox(100, 70, 0, 0, rocketSpeed, rocketSpeed);//игрок
        HitBox[] meteors = new HitBox[meteorCount];
        

        public void WorldFrame()
        {

        }
        public void InitializeMeteors()
        {
            foreach (HitBox hitBox in meteors)
            {
                hitBox.SetSpeed(meteorSpeed, 0);
            }
        }

        public void СomplexityIncreasing()
        {
            foreach (HitBox hitBox in meteors)
            {
                hitBox.SetSpeed(meteorSpeed + complexity, 0);
            }
        }

        public void СomplexityRest()
        {

        }
    }
}
