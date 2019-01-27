using AntonioHR.Util;
using DG.Tweening;
using NaughtyAttributes;
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
                float time = timeBetweenSteps;

                var prevPos = pathers[i].position;

                foreach (var pos in path)
                {
                    seq.Insert(time, pathers[i].DOMove(pos, timePerStep).SetEase(moveCurve));
                    time += timePerStep;
                    time += timeBetweenSteps;
                    prevPos = pos;
                }
                seq.SetEase(Ease.Linear);
                seq.SetLoops(-1);
            }
        }

        [Button]
        private void ConfigToChildren()
        {
            var list = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                list.Add(transform.GetChild(i));
            }

            pathers = list.ToArray();
        }

        private void OnDrawGizmosSelected()
        {
            if(pathers == null )
            {
                return;
            }

            Gizmos.color = Color.magenta;
            foreach (var path in pathers)
            {
                Gizmos.DrawSphere(path.position, .1f);
            }
        }
    }
}
