using System;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score.FruitParticleProvider.Scriptable
{
    [CreateAssetMenu(fileName = "Sprite Color", menuName = "Scriptable Object/Blocks/Sprite Color Config", order = 0)]
    public class SpriteColorScriptable : ScriptableObject
    {
        public SpriteToColorInfo[] spriteColorsInfos;
        
        [Serializable]
        public class SpriteToColorInfo
        {
            public Sprite sprite;
            public Color color;
        }
    }
    
}