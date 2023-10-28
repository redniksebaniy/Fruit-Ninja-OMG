using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.UI.Installers.Game.Samurai;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Samurai.Factory
{
    public class SamuraiBlockFactory : BlockFactory
    {
        [SerializeField] private SamuraiPanelInstaller samuraiPanelInstaller;
        
        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                samuraiPanelInstaller.StartEvent();
            };

            return newPrefab;
        }
    }
}