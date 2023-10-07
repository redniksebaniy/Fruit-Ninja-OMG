﻿using UnityEngine;

namespace App.Scripts.Game.Spawning.BlockProvider.Scriptable
{
    [CreateAssetMenu(fileName = "Block Container", menuName = "Scriptable Objects/Blocks Config", order = 0)]
    public class BlockProviderScriptable : ScriptableObject
    {
        public BlockInfo[] blocks;
    }
}