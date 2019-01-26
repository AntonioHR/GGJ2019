using AntonioHR.HomeColors.Audio;
using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Interactables;
using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.Interactables
{
    public class PickupSoundTrigger : ObjectNearnessTrigger<Player>
    {
        private ColorsMusicService musicService;

        private void Start()
        {
            musicService = ServiceManager.Get<ColorsMusicService>();
        }

        protected override void OnHasNoObjects()
        {
        }

        protected override void OnHasObjects()
        {
            
        }

        protected override void UpdateNearness(Player player, float lerpedNearness)
        {
            musicService.SetPinkNearby(lerpedNearness);
        }
    }
}
