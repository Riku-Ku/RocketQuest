using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace RocketQuest
{
    class HitBox //Набор основных парраметров
    {
        protected int width, height, x = 0, y = 0, speedX = 0, speedY = 0;

        public HitBox()
        {

        }

        public HitBox(int valueX, int valueY, int valueWidth, int valueHeight, int speedValueX, int speedValueY)//конструктор по умолчанию
        {
            if (valueHeight > 0 & valueWidth > 0)
            {
                width = valueWidth;
                height = valueHeight;
                x = valueX;
                y = valueY;
                speedX = speedValueX;
                speedY = speedValueY;
            }
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

        public int GetX
        {
            get => x;
        }
        public int GetY
        {
            get => y;
        }

        public void Move()//Перемещение
        {
            x += speedX;
            y += speedY;
        }

        public void SetSpeed(int speedValueX, int speedValueY)//Задать скорость
        {
            speedX = speedValueX;
            speedY = speedValueY;
        }

        public int GetSpeedX
        {
            get => speedX;
        }

        public int GetSpeedY
        {
            get => speedY;
        }

        //public HitBox[] GetHitboxArray(int size, int speedValueX, int speedValueY)
        //{
        //    HitBox[] hitBoxes = new HitBox[size];


        //    return hitBoxes;
        //}
    }
}
