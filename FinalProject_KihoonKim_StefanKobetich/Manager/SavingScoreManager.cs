using MissilesNMinesEscape.Entities;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissilesNMinesEscape.Manager
{
    public class SavingScoreManager
    {
        private const string logsPath = "./GameScores.txt";

        static public void MakingFile()
        {
            if (!File.Exists(logsPath))
            {
                var textFile = File.Create(logsPath);
                textFile.Close();
                SeedPlayerScores();
            }
           
        }
        static void SeedPlayerScores()
        {
            using StreamWriter streamWriter = File.AppendText(logsPath);

            string line1 = "Stefan,1200,Hard Mode";
            string line2 = "Kihoon,300,Easy Mode";
            string line3 = "Jimyung,900,Hard Mode";
            string line4 = "Will,400,Easy Mode";
            string line5 = "Kisun,800,Hard Mode";
            
            streamWriter.WriteLine(line1);
            streamWriter.WriteLine(line2);
            streamWriter.WriteLine(line3);
            streamWriter.WriteLine(line4);
            streamWriter.WriteLine(line5);
        }

        public static List<PlayerInfo> LoadGameScores()
        {
            List<PlayerInfo> highScores = new List<PlayerInfo>();
            string tempPlayerInfo;
            
            using (StreamReader sr = new StreamReader(logsPath))
            {
                // tempInfor is like just One line
                while ((tempPlayerInfo = sr.ReadLine()) != null)
                {
                    string[] eachScore = tempPlayerInfo.Split(',');
                    PlayerInfo playerInfo = new PlayerInfo
                    {
                        PlayerName = eachScore[0],
                        PlayerScore = int.Parse(eachScore[1]),
                        GameMode = eachScore[2]
                    };
                    highScores.Add(playerInfo);
                }
            }
            return highScores;
        }

        public static List<PlayerInfo> LoadTop5HighScores()
        {
            List<PlayerInfo> allHighScores = LoadGameScores();
            return allHighScores.OrderByDescending(score => score.PlayerScore).Take(5).ToList();
        }


        public static void AddNewPlayerInfo(PlayerInfo playerInfo)
        {
            using StreamWriter streamWriter = File.AppendText(logsPath);

            string line = $"{playerInfo.PlayerName},{playerInfo.PlayerScore},{playerInfo.GameMode}";
            streamWriter.WriteLine(line);

        }
    }
}
