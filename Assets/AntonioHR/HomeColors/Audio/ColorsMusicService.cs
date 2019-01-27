using AntonioHR.Services;
using Assets.AntonioHR.HomeColors;
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
        [SerializeField]
        private AudioMixer mixer;
        [SerializeField]
        private AudioMixerSnapshot calmSnapshot;
        [SerializeField]
        private AudioMixerSnapshot tenseSnapshot;
        [SerializeField]
        private DynamicTrack calmTrack;
        [SerializeField]
        private DynamicTrack tenseTrack;
        private GameStateService gameStateService;

        public override void Init()
        {
            gameStateService = ServiceManager.Get<GameStateService>();
        }

        private void LateUpdate()
        {

            calmTrack.Update(mixer);
            tenseTrack.Update(mixer);
        }

        public void SetNearby(MoodColor color, float lerpedNearness)
        {
            if (gameStateService.PlayerHasColor(color))
            {
                calmTrack.SetVolume(lerpedNearness);
            }
            else
            {
                tenseTrack.SetVolume(lerpedNearness);
            }
        }

        public void SetOnPinkRoom()
        {
        }
    }
}
