using System;
using System.Collections.Generic;
using System.Text;

namespace RocketQuest
{
    class ScoreLine//Хранение очков
    {
        public string NikName { get; set; }
        public int ScoreValue { get; set; }

        public ScoreLine(string NikName, int ScoreValue)
        {
            this.NikName = NikName;
            this.ScoreValue = ScoreValue;
        }
    }
}
