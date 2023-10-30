using App.Scripts.Commands.Data.Types.Base;

namespace App.Scripts.Commands.Data.Types
{
    public class PlayerRecords : CustomData
    {
        public int Highscore;

        public PlayerRecords()
        {
            Highscore = 0;
        }
    }
}