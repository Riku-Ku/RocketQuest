using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Resources;

namespace RocketQuest.Actors
{
    class Meteor : HitBox
    {
        private Bitmap skin;
        public Meteor(int valueWidth, int valueHeight, int valueX, int valueY, Bitmap valueSkin)//Наследованный конструктор
            : base(valueWidth, valueHeight, valueX, valueY)
        {
            skin = valueSkin;
        }

        public Bitmap MeteorSkin { get => skin; }
    }
}
