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
        private class Mapping
        {
            public DynamicTrack track;
            public MoodColor color;
        }
        [SerializeField]
        private AudioMixer mixer;
        [SerializeField]
        private DynamicTrack tenseTrack;
        [SerializeField]
        private Mapping[] mappings;
        private GameStateService gameStateService;

        public override void Init()
        {
            gameStateService = ServiceManager.Get<GameStateService>();
        }

        private void LateUpdate()
        {
            
            foreach (var mapping in mappings)
            {
                mapping.track.Update(mixer);
            }
            tenseTrack.Update(mixer);
        }

        public void SetNearby(MoodColor color, float lerpedNearness)
        {
            if (gameStateService.PlayerHasColor(color))
            {
                var map = mappings.Where(x => x.color == color).First();
                map.track.SetVolume(lerpedNearness);
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
