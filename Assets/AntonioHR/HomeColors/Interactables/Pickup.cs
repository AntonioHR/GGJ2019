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
        private MoodColor moodColor;
        [SerializeField]
        private UnityEvent PickedUpTriggers;
        [SerializeField]
        private UnityEvent PickupAnimationOver;
        [SerializeField]
        private Transform visuals;
        [SerializeField]
        private Light light;
        [SerializeField]
        private float lightIntensity = 3;


        public event Action PickedUp;

        public bool WasPickedUp { get; private set; }

        private void Start()
        {
            gameStateService = ServiceManager.Get<GameStateService>();
        }

        protected override void OnTriggered(Player player)
        {
            if (gameStateService.PlayerHasColor(moodColor))
            {
                WasPickedUp = true;
                if (PickedUp != null)
                    PickedUp();
                this.player = player;
                PickedUpTriggers.Invoke();
                visuals.DOScale(.5f, .2f).SetLoops(2, LoopType.Yoyo).OnComplete(OnPickupAnimationOver);
            } else
            {
                gameStateService.OnPlayerTookDamage();
                player.OnTookDamage();
                Reset();
            }
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
