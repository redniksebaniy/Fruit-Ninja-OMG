using App.Scripts.Game.Blocks.Shared.Abstract;

namespace App.Scripts.Game.Blocks.Bomb
{
    public class BombBlock : Block
    {
        public override void Init()
        {
            
        }

        public override void Chop()
        {
            Destroy(gameObject);
        }
    }
}