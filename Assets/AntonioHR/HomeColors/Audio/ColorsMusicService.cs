using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Audio;

namespace AntonioHR.HomeColors.Audio
{
    public class ColorsMusicService : Service
    {
        

        private AudioMixer mixer;
        private float pinkMax;

        public override void Init()
        {
        }


        private void LateUpdate()
        {
            mixer.SetFloat("Melody", pinkMax);
            pinkMax = 0;
        }

        public void SetPinkNearby(float value)
        {
            pinkMax = value;
        }
    }
}
