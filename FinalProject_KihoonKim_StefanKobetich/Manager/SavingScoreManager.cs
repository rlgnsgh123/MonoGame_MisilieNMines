using FinalProject_KihoonKim_StefanKobetich.Entities;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Manager
{
    public class SavingScoreManager
    {
        private const string logsPath = "./HighScores.txt";

        static public void MakingFile()
        {
            if (!File.Exists(logsPath))
            {
                var textFile = File.Create(logsPath);
                textFile.Close();
            }
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
