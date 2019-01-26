using AntonioHR.HomeColors.PlayerBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.Interactables
{
    public abstract class PlayerTrigger : MonoBehaviour
    {
        [SerializeField]
        private bool allowMultipleTriggers = false;

        private bool triggered;

        private void OnTriggerEnter(Collider other)
        {
            if(!allowMultipleTriggers && triggered)
                return;

            var playerBody = other.GetComponent<PlayerBody>();
            if(playerBody != null)
            {
                triggered = true;
                OnTouchedPlayer(playerBody.Owner);
            }
        }

        protected abstract void OnTouchedPlayer(Player player);
    }
}
