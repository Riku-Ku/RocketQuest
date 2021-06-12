using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace RocketQuest
{
    class HitBox
    {
        private Point coordinates=new Point(0,0);
        private int width;
        private int height;
        public int SetWidth
        { 
            get => width; 
            set 
            {
                if (value >= 0)
                    width = value;
            } 
        }
        public int SetHeight
        {
            get => height;
            set
            {
                if (value >= 0)
                    height = value;
            }
        }
        public Point SetPoint
        {
            get => coordinates;
            set
            {
                coordinates = value;
            }
        }
    }
}
