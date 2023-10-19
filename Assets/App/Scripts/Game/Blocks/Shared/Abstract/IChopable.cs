using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Abstract
{
    public interface IChopable
    {
        public void Chop(Vector2 direction);
    }
}