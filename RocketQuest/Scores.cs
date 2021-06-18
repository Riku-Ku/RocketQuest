using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RocketQuest
{
    class Scores
    {
        List<Tuple<string, int>> scoreHolder = new List<Tuple<string, int>>();//Данные по очкам
        string scorePath = Path.Combine(Environment.CurrentDirectory, "scores.txt");//файлы по очкам
    }
}
