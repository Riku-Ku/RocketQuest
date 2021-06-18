using RocketQuest.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketQuest.Physics
{
    class ColissionChecker
    {
        private static int screenW = 0 , screenH = 0;

        public static bool MeteorOutCheck(HitBox spaceObject)//Проверка на выход метеора за поле
        {
            if (((spaceObject.GetX + spaceObject.Width) < 0 ))
                return true;

            return false;
        }

        public static bool CheckPlayerMoving(HitBox hitBox)//Возможность перемещения
        {
            if ((hitBox.GetX <= screenW - hitBox.Width && hitBox.GetX >= 0) ||
                (hitBox.GetY <= screenH - hitBox.Height && hitBox.GetY >= 0))
                return true;

            return false;
        }

        public void SetBorders(int screenWidth, int screenHeight)//значения экрана
        {
            if (screenWidth > 0 & screenHeight > 0)
            {
                screenW = screenWidth;
                screenH = screenHeight;
            }
            else
                throw new ArgumentException("Screen Width & Height always > 0");
        }

        public static bool Colussion(HitBox meteor, HitBox rocket)//Столкновения
        {
            int rightUpMeteor = meteor.GetX + meteor.Width;
            int rightDownMeteor = rightUpMeteor + meteor.Height;
            int LeftDownMeteorY = meteor.GetY + meteor.Height;
            int LeftDownRocketY = rocket.GetY + rocket.Height;

            if (meteor.GetX >= rocket.GetX && meteor.GetX <= rocket.GetX + rocket.Width && meteor.GetY >= rocket.GetY && meteor.GetY <= rocket.GetY + rocket.Height)
                return true;
            if (meteor.GetX >= rocket.GetX && meteor.GetX <= rocket.GetX + rocket.Width && LeftDownMeteorY >= rocket.GetY && LeftDownMeteorY <= rocket.GetY + rocket.Height)
                return true;
            if (meteor.GetX + meteor.Width >= rocket.GetX && meteor.GetX + meteor.Width <= rocket.GetX + rocket.Width && meteor.GetY >= rocket.GetY && meteor.GetY <= rocket.GetY + rocket.Height)
                return true;
            if (meteor.GetX + meteor.Width >= rocket.GetX && meteor.GetX + meteor.Width <= rocket.GetX + rocket.Width && LeftDownMeteorY >= rocket.GetY && LeftDownMeteorY <= rocket.GetY + rocket.Height)
                return true;
            if (rocket.GetX >= meteor.GetX && rocket.GetX <= meteor.GetX + meteor.Width && rocket.GetY >= meteor.GetY && rocket.GetY <= meteor.GetY + meteor.Height)
                return true;
            if (rocket.GetX >= meteor.GetX && rocket.GetX <= meteor.GetX + meteor.Width && LeftDownRocketY >= meteor.GetY && LeftDownRocketY <= meteor.GetY + meteor.Height)
                return true;
            if (rocket.GetX + rocket.Width >= meteor.GetX && rocket.GetX + rocket.Width <= meteor.GetX + meteor.Width && rocket.GetY >= meteor.GetY && rocket.GetY <= meteor.GetY + meteor.Height)
                return true;
            if (rocket.GetX + rocket.Width >= meteor.GetX && rocket.GetX + rocket.Width <= meteor.GetX + meteor.Width && LeftDownRocketY >= meteor.GetY && LeftDownRocketY <= meteor.GetY + meteor.Height)
                return true;
            return false;
        }
    }
}
