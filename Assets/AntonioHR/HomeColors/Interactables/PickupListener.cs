using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace AntonioHR.HomeColors.Interactables
{
    public class PickupListener : MonoBehaviour
    {
        public enum Mode { CollectAll, CollectMany }

        public Transform[] pickupTransformsRecursive;


        [SerializeField]
        private List<Pickup> manualPickups = new List<Pickup>();
        
        private Pickup[] listenedPckups;
        [SerializeField]
        private UnityEvent trigger;
        [SerializeField]
        private Mode mode = Mode.CollectAll;


        [ShowIf("IsCollectAll")]
        [SerializeField]
        private int collectAllTolerance = 0;
        [ShowIf("IsCollectMany")]
        [SerializeField]
        private int collectManyRequirement = 3;

        private int toPickup;
        private int pickedup;


        private void Start()
        {

            if (manualPickups.Count > 0)
            {
                listenedPckups = manualPickups.ToArray();
            }
            else
            {
                var allPickups = pickupTransformsRecursive.SelectMany(x => x.GetComponentsInChildren<Pickup>()).Distinct();
                listenedPckups = allPickups.Where(x => !x.WasPickedUp).ToArray();
            }
            Debug.Assert(listenedPckups.Length > 0);

            foreach (var pickup in listenedPckups)
            {
                toPickup++;
                pickup.PickedUp += OnPickedUpNew;
            }
        }

        private void OnDestroy()
        {
            foreach (var pickup in listenedPckups)
            {
                pickup.PickedUp -= OnPickedUpNew;
            }
        }

        private void OnPickedUpNew()
        {
            toPickup--;
            pickedup++;
            if (RequirementMet())
            {
                trigger.Invoke();
            }
        }

        private bool RequirementMet()
        {
            switch (mode)
            {
                case Mode.CollectAll:
                    return toPickup == collectAllTolerance;
                case Mode.CollectMany:
                    return pickedup == collectManyRequirement;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsCollectAll()
        {
            return mode == Mode.CollectAll;
        }
        public bool IsCollectMany()
        {
            return mode == Mode.CollectMany;
        }
    }
}
