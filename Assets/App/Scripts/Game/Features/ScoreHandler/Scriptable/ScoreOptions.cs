using System;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreHandler.Scriptable
{
    [Serializable]
    public struct ScoreOptions
    {
        [Min(0)] public int scoreAmount;

        [Min(0)] public float comboMaxTime;
        
        [Min(0)] public int comboMaxCount;
    }
}