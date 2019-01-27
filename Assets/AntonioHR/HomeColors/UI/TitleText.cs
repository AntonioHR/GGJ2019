using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.UI
{
    public class TitleText : MonoBehaviour
    {
        float titleFadeInTime = 1f;
        float titleTime = 2;
        [SerializeField]
        private CanvasGroup canvasGroup;

        public void Show(TweenCallback callback)
        {
            var seq = DOTween.Sequence();

            var fadeIn = canvasGroup.DOFade(1, titleFadeInTime);
            var fadeOut = canvasGroup.DOFade(0, .3f);
            seq.Append(fadeIn);
            seq.Insert(titleFadeInTime + titleTime, fadeOut);
            fadeOut.OnStart(() => callback());
        }
    }
}
