using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace AntonioHR.HomeColors.Interactables
{
    public class GenericPlayerTrigger : ObjectTrigger<Player>
    {

        [SerializeField]
        private UnityEvent trigger;

        protected override void OnTriggered(Player obj)
        {
            trigger.Invoke();
        }
    }
}
