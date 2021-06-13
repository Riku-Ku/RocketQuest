using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace RocketQuest
{
    class HitBox
    {
        private int width, height, x, y, screenWidth, screenHeight;
        public int Width
        { 
            get => width; 
            set 
            {
                if (value >= 0)
                    width = value;
            } 
        }
        public int Height
        {
            get => height;
            set
            {
                if (value >= 0)
                    height = value;
            }
        }
        public int X
        {
            get => x;
            set
            {
                if (value <= screenWidth - width && value >= 0 )
                    x = value;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                if (value <= screenHeight - height && value >= 0)
                    y = value;
            }
        }

        public int ScreenWidth
        {
            set
            {
                screenWidth = value;
            }
        }
        public int ScreenHeight
        {
            set
            {
                screenHeight = value;
            }
        }
    }
}
