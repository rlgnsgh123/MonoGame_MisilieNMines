﻿//using FinalProject_KihoonKim_StefanKobetich.Entities;
//using SharpDX.Direct3D9;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FinalProject_KihoonKim_StefanKobetich.Manager
//{
//    public class SavingScoreManager
//    {
//        private const string logsPath = "./GameScores.txt";

//        static public void MakingFile()
//        {
//            if (!File.Exists(logsPath))
//            {
//                var textFile = File.Create(logsPath);
//                textFile.Close();
//            }
//        }

//        public static List<PlayerInfo> LoadGameScores()
//        {
//            List<PlayerInfo> highScores = new List<PlayerInfo>();
//            string tempPlayerInfo;
//            if (File.Exists(logsPath))
//            {
//                string[] lines = File.ReadAllLines(logsPath);

//                foreach (string line in lines)
//                {
//                    string[] parts = line.Split(',');
//                    if (parts.Length == 3 && int.TryParse(parts[1], out int score))
//                    {
//                        HighScoreEntry entry = new HighScoreEntry
//                        {
//                            PlayerName = parts[0],
//                            Score = score,
//                            GameMode = parts[2]
//                        };
//                        highScores.Add(entry);
//                    }
//                }
//            }

//            using (StreamReader sr = new StreamReader(logsPath))
//            {
//                // tempInfor is like just One line
//                while ((tempPlayerInfo = sr.ReadLine()) != null)
//                {
//                    string[] eachScore = tempPlayerInfo.Split(',');
//                    PlayerInfo playerInfo = new PlayerInfo
//                    {
//                        PlayerName = eachScore[0],
//                        PlayerScore = int.Parse(eachScore[1]),
//                        GameMode = eachScore[2]

//                    };
//                    highScores.Add(eachScore);
//                }
//            }
//            return highScores;
//        }

//                return highScores;
//        highScores

//    public static void SaveHighScores(List<HighScoreEntry> highScores)
//    {
//        try
//        {
//            List<string> lines = highScores.Select(entry => $"{entry.PlayerName},{entry.Score},{entry.GameMode}").ToList();
//            File.WriteAllLines(FileName, lines);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"하이스코어 저장 오류: {ex.Message}");
//        }
//    }
//}
//}
