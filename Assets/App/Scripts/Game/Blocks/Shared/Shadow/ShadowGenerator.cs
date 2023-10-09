using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Shadow
{
    public class ShadowGenerator : MonoBehaviour
    {
        [Header("Original Sprite Renderer")]
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [Header("Shadow Options")]
        [SerializeField] private string shadowObjectName;

        [SerializeField] private int shadowLayerID;
        
        [SerializeField] private Vector3 shadowOffset;

        [SerializeField] [Range(0, 1)] private float shadowIntensity;
        
        private SpriteRenderer _shadowRenderer;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _shadowRenderer = new GameObject(shadowObjectName).AddComponent<SpriteRenderer>();
            _shadowRenderer.transform.parent = transform;
            
            _shadowRenderer.sprite = originalRenderer.sprite;
            
            Color shadowColor = Color.black;
            shadowColor.a = shadowIntensity;
            _shadowRenderer.color = shadowColor;
            
            _shadowRenderer.gameObject.layer = shadowLayerID;
            
            UpdateShadow();
        }

        private void Update()
        {
            UpdateShadow();
        }

        private void UpdateShadow()
        {
            float scale = transform.lossyScale.z;
            _shadowRenderer.transform.position = transform.position + shadowOffset * scale * 2;
        }
    }
}