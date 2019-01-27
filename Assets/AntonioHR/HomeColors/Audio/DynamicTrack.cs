using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace AntonioHR.HomeColors.Audio
{
    [Serializable]
    public class DynamicTrack
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
        private const float decay = 2f;

        [SerializeField]
        private string Id = "Melody";
        [SerializeField]
        private AudioRange range;

        private float valInFrame;
        private float val;
        


        public void Update(AudioMixer mixer)
        {
            //Debug.LogFormat("Set Melody To {0}", setValue);
            val = Mathf.Max(valInFrame, val - decay * Time.deltaTime);
            float setValue = range.Eval(val);
            mixer.SetFloat(Id, setValue);
            valInFrame = 0;
        }

        public void SetVolume(float value)
        {
            valInFrame = Mathf.Max(value, valInFrame);
        }
    }
}
