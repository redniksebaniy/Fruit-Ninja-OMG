using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Base
{
    public interface IChopable
    {
        public void Chop(Vector2 direction);
    }
}