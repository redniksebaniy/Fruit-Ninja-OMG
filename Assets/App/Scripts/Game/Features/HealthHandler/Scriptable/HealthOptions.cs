using System;
using UnityEngine;

namespace App.Scripts.Game.Features.HealthHandler.Scriptable
{
    [Serializable]
    public struct HealthOptions
    {
        [Min(1)] 
        public int startHealthCount;

        [Min(1)] 
        public int maxHealthCount;
    }
}