using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace RocketQuest
{
    class HitBox //Набор основных парраметров
    {
        protected int width, height, x, y;

        public HitBox()
        {

        }

        public HitBox(int valueWidth, int valueHeight, int positionX, int positionY)//конструктор по умолчанию
        {
            if (valueHeight > 0 & valueWidth > 0)
            {
                width = valueWidth;
                height = valueHeight;
                x = positionX;
                y = positionY;
            }
            else
                throw new ArgumentException("Width & Height always > 0");
        }
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
            set { x = value; }
        }
        public int Y
        {
            get => y;
            set { y = value; }
        }
       
    }
}
