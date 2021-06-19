using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RocketQuest.Graphics
{
    class DrawingTools
    {
        public static Bitmap RandomMeteorSkin()
        {
            Random randGenerator = new Random();//ранд генератор

            switch (randGenerator.Next(4))
            {
                case (0):
                    return RocketQuest.Properties.Resources.meteor1;
                case (1):
                    return RocketQuest.Properties.Resources.meteorBrown_big3;
                case (2):
                    return RocketQuest.Properties.Resources.meteorGrey_big1;
                default:
                    return RocketQuest.Properties.Resources.meteorGrey_big2;
            }
        }

        //    public static Bitmap GetScinsForArray(int identif)
        //    {

        //    }
    }
}
