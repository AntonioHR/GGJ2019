using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Interactables;
using AntonioHR.Services;
using DG.Tweening;
using UnityEngine;

namespace AntonioHR.HomeColors.Interactables
{
    public class Pickup : ObjectTrigger<Player>
    {
        private Player player;
        private GameStateService gameStateService;

        private void Start()
        {
            gameStateService = ServiceManager.Get<GameStateService>();
        }

        protected override void OnTriggered(Player player)
        {
            this.player = player;
            transform.DOScale(0, .2f).OnComplete(OnPickedup);
        }

        private void OnPickedup()
        {
            gameStateService.GainedPickup();
            player.OnGainedPickup();
            GameObject.Destroy(gameObject);
        }
    }
}
