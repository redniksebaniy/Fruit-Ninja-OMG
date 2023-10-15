using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Game.AnimatedPanel
{
    public class AnimatedPanelView : MonoBehaviour
    {
        // [SerializeField] private Image panelImage;
        //
        // [SerializeField] private RectTransform[] bottom;
        //
        // private void OnEnable()
        // {
        //     DOTween.To(() => panelImage.color.a, (x) =>
        //     {
        //         var color = panelImage.color;
        //         color.a = x;
        //     }, 0.75f, 0.25f).WaitForCompletion();
        //
        //     foreach (var rectTransform in bottom)
        //     {
        //         var pos = rectTransform.position.y;       
        //         rectTransform.DOMoveY(pos, 0.5f).SetEase(Ease.OutBack);
        //     }
        // }
    }
}