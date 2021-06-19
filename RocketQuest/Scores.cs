using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

    class Scores
    {
        List<ScoreLine> scoreData = new List<ScoreLine>();

        string scorePath = Path.Combine(Environment.CurrentDirectory, "scores.txt");//файл c очками

        int score = 0;

        public List<string> GetStringScoreData()//получиьт данные
        {
            List<string> tempScoreList = new List<string>();
            foreach(ScoreLine line in scoreData)
            {
                tempScoreList.Add(line.NikName + " - " + line.ScoreValue);
            }
            return tempScoreList;
        }


        public int scoreGeter
        {
            get => score;
        }

        public void AddScore()
        {
            score++;
        }

        public void ResetScore()
        {
            score++;
        }


        public void ScoreReader()
        {
            if (File.Exists(scorePath))
            {
                using (var sr = new StreamReader(scorePath))//считывание из файла
                {
                    string temp = default;

                    Regex firstItemRegex = new Regex(@"^\w+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    Regex secondItemRegex = new Regex(@"\w+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    while ((temp = sr.ReadLine()) != null)
                    {
                        scoreData.Add(new ScoreLine(Convert.ToString(firstItemRegex.Match(temp)),
                            Convert.ToInt32(Convert.ToString(secondItemRegex.Match(temp)))));
                    }
                }
                scoreData = scoreData.OrderByDescending(s => s.ScoreValue).ToList();//сорторовка
            }
            else
            {
                using (FileStream fs = File.Create(scorePath)) ;//Создание файла
            }
        }

        public void ScoreWriter()
        {
            using (StreamWriter outputFile = new StreamWriter(scorePath))//Запись в файл
            {
                string temp = default;

                for (int i = 0; i < scoreData.Count; i++)
                {
                    temp += scoreData[i].NikName + "-" + scoreData[i].ScoreValue + Environment.NewLine;
                }

                outputFile.Write("");
                outputFile.Write(temp);
            }
        }

       

        public void AddPlayerScoreToList(string nikName)//чек списка
        {
            bool has = false;

            if (scoreData.Count > 0)
            {
                for (int i = 0; i < scoreData.Count; i++)//Чек на присутствие
                    if (scoreData[i].NikName == nikName)
                        has = true;


                if (has == true)
                    for (int i = 0; i < scoreData.Count; i++)
                    {
                        if (scoreData[i].NikName == nikName & scoreData[i].ScoreValue < score)
                        {
                            scoreData[i].ScoreValue = score;
                            break;
                        }
                        else
                            break;
                    }
            }
            else
                scoreData.Add(new ScoreLine(nikName, score));

            scoreData = scoreData.OrderByDescending(s => s.ScoreValue).ToList();//сорторовка


            //if (scoreData.Count > 0)
            //{
            //    bool key = false;
            //    foreach(ScoreLine sl in scoreData)
            //    {
            //        if (key)
            //        {

            //        }
            //        if(sl.NikName == nikName && sl.ScoreValue < score)
            //        {
            //            sl.ScoreValue = score;
            //            break;
            //        }
            //    }

            //    for (int i = 0; i < scoreData.Count; i++)
            //    {
            //        if (scoreData[i].NikName == nikName)
            //        {
            //            if (scoreData[i].ScoreValue < score)
            //            {
            //                scoreData[i].ScoreValue = score;
            //                break;
            //            }
            //            else
            //                break;
            //        }
            //        else

            //    }
            //}
            //else
            //    scoreData.Add(new ScoreLine(nikName, score));
        }
    }
}
