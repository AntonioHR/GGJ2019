using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.PlayerBehaviours
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerBody body;
        [SerializeField]
        private PlayerMovement move;
        [SerializeField]
        private IngameScene scene;

        public void Prepare(IngameScene ingameScene)
        {
            scene = ingameScene;
            body.Prepare(this);
            move.Prepare(this);
        }

        public void OnGainedPickup()
        {
        }

        public void Run()
        {
        }
    }
}
