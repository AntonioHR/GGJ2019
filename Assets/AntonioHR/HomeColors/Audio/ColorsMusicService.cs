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

        private float pinkMaxInFrame;


        

        public override void Init()
        {
        }


        private void LateUpdate()
        {
            float setValue = pinkAudio.Eval(pinkMaxInFrame);
            Debug.LogFormat("Set Melody To {0}", setValue);
            mixer.SetFloat("Melody", setValue);
            pinkMaxInFrame = 0;
        }

        public void SetPinkNearby(float value)
        {
            
            pinkMaxInFrame = Mathf.Max(value, pinkMaxInFrame);
        }
    }
}
