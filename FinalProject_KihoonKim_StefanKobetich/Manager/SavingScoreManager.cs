//using FinalProject_KihoonKim_StefanKobetich.Entities;
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
//        //    List<PlayerInfo> highScores = new List<PlayerInfo>();

//        //    if (File.Exists(logsPath))
//        //    {
//        //        string[] lines = File.ReadAllLines(logsPath);

//        //        foreach (string line in lines)
//        //        {
//        //            string[] parts = line.Split(',');
//        //            if (parts.Length == 3 && int.TryParse(parts[1], out int score))
//        //            {
//        //                HighScoreEntry entry = new HighScoreEntry
//        //                {
//        //                    PlayerName = parts[0],
//        //                    Score = score,
//        //                    GameMode = parts[2]
//        //                };
//        //                highScores.Add(entry);
//        //            }
//        //        }
//        //    }

//        //    using (StreamReader sr = new StreamReader(logsPath))
//        //    {
//        //        // tempInfor is like just One line
//        //        while ((tempInfo = sr.ReadLine()) != null)
//        //        {
//        //            Patient patient = new Patient();
//        //            // split according to "|"
//        //            String[] eachInfo = tempInfo.Split('|');

//        //            // id
//        //            patient.id = Convert.ToInt32(eachInfo[0]);
//        //            patient.name = eachInfo[1];
//        //            // name
//        //            DateTime parsedDate = DateTime.Parse(eachInfo[2]);
//        //            patient.dOB = parsedDate;
//        //            //problem
//        //            patient.problem = eachInfo[3];
//        //            // note
//        //            patient.clinicalNote = eachInfo[4];

//        //            patients.Add(patient);
//        //        }
//        //    }
//        //    return patients;
//        //}

//        //    return highScores;
//        }

//        public static void SaveHighScores(List<HighScoreEntry> highScores)
//        {
//            try
//            {
//                List<string> lines = highScores.Select(entry => $"{entry.PlayerName},{entry.Score},{entry.GameMode}").ToList();
//                File.WriteAllLines(FileName, lines);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"하이스코어 저장 오류: {ex.Message}");
//            }
//        }
//    }
//}
