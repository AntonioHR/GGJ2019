using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace AntonioHR.HomeColors.Audio
{
    public class ColorsMusicService : Service
    {
        [Serializable]
        private class AudioRange
        {
            public float min;
            public float max;
            public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
            public float Eval(float value)
            {
                return Mathf.Lerp(min, max, curve.Evaluate(value));
            }
        }
        
        [SerializeField]
        private AudioMixer mixer;

        [SerializeField]
        private AudioRange pinkAudio;
        [SerializeField]
        private float decay = 2f;

        private float pinkValInFrame;
        private float pinkVal;

        public override void Init()
        {
        }


        private void LateUpdate()
        {
            //Debug.LogFormat("Set Melody To {0}", setValue);
            pinkVal = Mathf.Max(pinkValInFrame, pinkVal - decay * Time.deltaTime);
            float setValue = pinkAudio.Eval(pinkVal);
            mixer.SetFloat("Melody", setValue);
            pinkValInFrame = 0;
        }

        public void SetPinkNearby(float value)
        {
            pinkValInFrame = Mathf.Max(value, pinkValInFrame);
        }
    }
}
