using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    [System.Serializable]
    public class PlayerData
    {
        public PlayerStat PlayerStats;

        public PlayerData(PlayerStat stat)
        {
            PlayerStats = new PlayerStat(stat);
        }
    }
}
