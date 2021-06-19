using RocketQuest.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketQuest.Physics
{
    class ColissionChecker
    {
        public static bool MeteorOutCheck(HitBox spaceObject)//Проверка на выход метеора за поле
        {
            if (((spaceObject.GetX + spaceObject.Width) < 0 ))
                return true;

            return false;
        }

        public static bool CheckPlayerMoving(HitBox hitBox , int screenWidth, int screenHeight )//Возможность перемещения
        {
            //if ((hitBox.GetX < 0 || hitBox.GetX > screenWidth - hitBox.Width) ||
            //    (hitBox.GetY < 0 || hitBox.GetY > screenHeight - hitBox.Height))

            if (hitBox.GetX < 0)
            {
                hitBox.SetLocation(0, hitBox.GetY);
                return false;
            }

            else if (hitBox.GetY < 0)
            {
                hitBox.SetLocation(hitBox.GetX, 0);
                return false;
            }

            else if (hitBox.GetX > screenWidth - hitBox.Width)
            {
                hitBox.SetLocation(screenWidth, hitBox.GetY);
                return false;
            }

            else if (hitBox.GetY > screenHeight - hitBox.Height)
            {
                hitBox.SetLocation(hitBox.GetX, screenHeight);
                return false;
            }

            return true;
        }

        public static bool Colission(HitBox meteor, HitBox rocket)//Столкновения
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
