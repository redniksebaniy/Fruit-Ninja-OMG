using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.Base.Base;
using App.Scripts.UI.Installers.Game.Freeze;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Ice.Factory
{
    public class IceBlockFactory : BlockFactory
    {
        [SerializeField] private FreezePanelInstaller freezePanelInstaller;
        
        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                freezePanelInstaller.StartEvent();
            };

            return newPrefab;
        }
    }
}