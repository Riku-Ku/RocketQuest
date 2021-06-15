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
    }
}
