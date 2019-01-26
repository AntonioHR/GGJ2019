using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Services;
using DG.Tweening;
using UnityEngine;

namespace AntonioHR.HomeColors.Interactables
{
    public class Pickup : PlayerTrigger
    {
        private Player player;
        private GameStateService gameStateService;

        private void Start()
        {
            gameStateService = ServiceManager.GetService<GameStateService>();
        }

        protected override void OnTouchedPlayer(Player player)
        {
            this.player = player;
            transform.DOScale(0, .2f).OnComplete(OnPickedup);
        }

        private void OnPickedup()
        {
            gameStateService.GainedPickup();
            player.OnGainedPickup();
            GameObject.Destroy(this);
        }
    }
}
