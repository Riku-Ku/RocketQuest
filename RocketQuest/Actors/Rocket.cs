using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RocketQuest.Actors
{
    class Rocket : HitBox
    {
        private int screenW, screenH;
        private Bitmap skin;

        public Rocket(int valueWidth, int valueHeight, int valueX, int valueY, Bitmap valueSkin)//Наследованный конструктор
            : base(valueWidth, valueHeight, valueX, valueY)
        {
            skin = valueSkin;
        }

        public Bitmap RocketSkin { get => skin; }

        #region
        /// <summary>
        ///  Создать со значениями экрана
        ///  <param name="screenWidth">Ширина экрана</param>
        ///  <param name="screenHeight">Высота экрана</param>
        /// </summary>
        public void SetBorders(int screenWidth, int screenHeight)
        {
            if(screenWidth > 0 & screenHeight > 0)
            {
                screenW = screenWidth;
                screenH = screenHeight;
            }
            else
                throw new ArgumentException("Screen Width & Height always > 0");
        }
        #endregion

        public void Moving(int valueAddToX, int valueAddToY)
        {
            if(valueAddToX + x <= screenW - width && valueAddToX + x >= 0)
                x += valueAddToX;

            if (valueAddToY + y <= screenH - height && valueAddToY + y >= 0)
                y += valueAddToY;
        }
    }
}
