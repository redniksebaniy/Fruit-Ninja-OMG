﻿using UnityEngine;

namespace App.Scripts.Game.Features.ScoreHandler.Scriptable
{
    [CreateAssetMenu(fileName = "Score Options", menuName = "Scriptable Object/Feature/Score Config", order = 0)]
    public class ScoreOptionsScriptable : ScriptableObject
    {
        public ScoreOptions options;
    }
}