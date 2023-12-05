using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_KihoonKim_StefanKobetich.Entities
{
    public static class PlayerInfo
    {
        public static string PlayerName { get; set; }
        public static int PlayerScore { get; set; }
        public static string GameMode { get; set; }

        // 다른 초기화 로직이나 메서드가 필요한 경우 추가할 수 있습니다.

        static PlayerInfo()
        {
            // 초기화 로직을 여기에 추가할 수 있습니다.
            PlayerName = "";
            PlayerScore = 0;
            GameMode = "";
        }
    }

}
