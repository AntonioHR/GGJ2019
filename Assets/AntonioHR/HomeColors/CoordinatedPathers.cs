using AntonioHR.Util;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.PlayerBehaviours
{
    public class CoordinatedPathers : MonoBehaviour
    {
        [SerializeField]
        private Transform[] pathers;
        [Space]
        [SerializeField]
        private float timePerStep = .5f;
        [SerializeField]
        private float timeBetweenSteps = .3f;
        [SerializeField]
        private AnimationCurve moveCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        public void Start()
        {
            for (int i = 0; i < pathers.Length; i++)
            {
                var path = pathers.CycleStartingAt(i + 1).Select(x => x.position).ToArray();

                var seq = DOTween.Sequence();
                float time = 0;

                foreach (var pos in path)
                {
                    seq.Insert(time, pathers[i].DOMove(pos, timePerStep).SetEase(moveCurve));
                    time += timePerStep;
                    time += timeBetweenSteps;
                }
                seq.SetLoops(-1);
            }
        }
    }
}
