using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.Interactables
{
    public class Npc : ObjectTrigger<Player>
    {
        private Player player;

        [SerializeField]
        Animator animator;
        [SerializeField]
        private Transform interactionPoint;
        [SerializeField]
        private MoodColor givenColor;

        protected override void OnTriggered(Player obj)
        {
            player = obj;

            player.SnapTo(interactionPoint.position, interactionPoint.rotation, () =>
            {
                player.AnimateInteraction();
                animator.SetTrigger("interact");
            });
        }

        void OnInteractKeyFrame()
        {
            player.GiveColor(givenColor);
        }
        void OnInteractOver()
        {
            player.Unsnap();
        }
    }
}
