using RocketQuest.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketQuest.Physics
{
    class ColissionChecker
    {
        public static bool OutFromScreen(Meteor SpaceObject, int screenWidth, int screenHeight)//Проверка на границы экрана
        {
            if (((SpaceObject.X + SpaceObject.Width) < 0 || (SpaceObject.Y + SpaceObject.Height) < 0) ||
                ((SpaceObject.X > screenWidth || SpaceObject.Y > screenHeight)))
                return true;

            return false;
        }
        public static bool Colussion(Meteor meteor, Rocket rocket)
        {
            int rightUpMeteor = meteor.X + meteor.Width;
            int rightDownMeteor = rightUpMeteor + meteor.Height;
            int LeftDownMeteorY = meteor.Y + meteor.Height;
            int LeftDownRocketY = rocket.Y + rocket.Height;


            //int rightUpRocket = rocket.X + rocket.Width;
            //int rightDownRocket = rightUpRocket+ rocket.Width;
            //int leftDownRocket = rocket.X + rocket.Height;
            if (meteor.X >= rocket.X && meteor.X <= rocket.X + rocket.Width && meteor.Y >= rocket.Y && meteor.Y <= rocket.Y + rocket.Height)
                return true;
            if (meteor.X >= rocket.X && meteor.X <= rocket.X + rocket.Width && LeftDownMeteorY >= rocket.Y && LeftDownMeteorY <= rocket.Y + rocket.Height)
                return true;
            if (meteor.X +meteor.Width>= rocket.X && meteor.X + meteor.Width <= rocket.X + rocket.Width && meteor.Y >= rocket.Y && meteor.Y <= rocket.Y + rocket.Height)
                return true;
            if (meteor.X + meteor.Width >= rocket.X && meteor.X + meteor.Width <= rocket.X + rocket.Width && LeftDownMeteorY >= rocket.Y && LeftDownMeteorY <= rocket.Y + rocket.Height)
                return true;
            if (rocket.X >= meteor.X && rocket.X <= meteor.X + meteor.Width && rocket.Y >= meteor.Y && rocket.Y <= meteor.Y + meteor.Height)
                return true;
            if (rocket.X >= meteor.X && rocket.X <= meteor.X + meteor.Width && LeftDownRocketY >= meteor.Y && LeftDownRocketY <= meteor.Y + meteor.Height)
                return true;
            if (rocket.X+rocket.Width >= meteor.X && rocket.X+rocket.Width <= meteor.X + meteor.Width && rocket.Y >= meteor.Y && rocket.Y <= meteor.Y + meteor.Height)
                return true;
            if (rocket.X+rocket.Width >= meteor.X && rocket.X+rocket.Width <= meteor.X + meteor.Width && LeftDownRocketY >= meteor.Y && LeftDownRocketY <= meteor.Y + meteor.Height)
                return true;
            return false;
        }
    }
}
