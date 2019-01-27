using DG.Tweening;
using NaughtyAttributes;
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
        float delayBetweens = 1.5f;
        float endFades = .5f;

        float titleFadeInTime = 1f;
        float titleTime = 2;
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private CanvasGroup whiteCanvasGroup;
        [SerializeField]
        private CanvasGroup aGameByCanvasGroup;
        [SerializeField]
        private CanvasGroup musicBy;
        [SerializeField]
        private CanvasGroup thankYouForPlayingCanvasGroup;
        public void Show(TweenCallback callback)
        {
            var seq = DOTween.Sequence();

            var fadeIn = canvasGroup.DOFade(1, titleFadeInTime);
            var fadeOut = canvasGroup.DOFade(0, .3f);
            seq.Append(fadeIn);
            seq.Insert(titleFadeInTime + titleTime, fadeOut);
            fadeOut.OnStart(() => callback());

        }

        [Button]
        internal void ShowGameWon()
        {
            var seq = DOTween.Sequence();
            float time = 0;
            seq.Insert(time, whiteCanvasGroup.DOFade(1, endFades));
            time = AdvanceTime(time);
            seq.Insert( time, canvasGroup.DOFade(1, endFades));
            time = AdvanceTime(time);
            seq.Insert(time, aGameByCanvasGroup.DOFade(1, endFades));
            time = AdvanceTime(time);
            seq.Insert(time, musicBy.DOFade(1, endFades));
            time = AdvanceTime(time);
            seq.Insert(time, thankYouForPlayingCanvasGroup.DOFade(1, endFades));
        }

        private float AdvanceTime(float time)
        {
            time += delayBetweens + endFades;
            return time;
        }
    }
}
