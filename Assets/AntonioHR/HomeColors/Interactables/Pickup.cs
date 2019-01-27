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
using UnityEngine.Events;

namespace AntonioHR.HomeColors.Interactables
{
    public class Pickup : ObjectTrigger<Player>
    {
        private Player player;
        private GameStateService gameStateService;

        [SerializeField]
        private UnityEvent PickedUp;
        [SerializeField]
        private UnityEvent PickupAnimationOver;
        [SerializeField]
        private Transform visuals;
        [SerializeField]
        private Light light;
        [SerializeField]
        private float lightIntensity = 3;

        private void Start()
        {
            gameStateService = ServiceManager.Get<GameStateService>();
        }

        protected override void OnTriggered(Player player)
        {
            this.player = player;
            PickedUp.Invoke();
            visuals.DOScale(0, .2f).OnComplete(OnPickupAnimationOver);
        }

        private void OnPickupAnimationOver()
        {
            light.DOIntensity(lightIntensity, .3f);
            PickupAnimationOver.Invoke();
            gameStateService.GainedPickup();
            player.OnGainedPickup();
        }
    }
}
