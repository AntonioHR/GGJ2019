using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntonioHR.HomeColors.Interactables;
using AntonioHR.Services;
using UnityEngine;

namespace AntonioHR.HomeColors.PlayerBehaviours
{
    public class Player : MonoBehaviour
    {
        [Serializable]
        private class ColorActivatedObj
        {
            public MoodColor color;
            public Transform obj;
        }

        [SerializeField]
        private PlayerBody body;
        [SerializeField]
        private PlayerMovement move;
        [SerializeField]
        private ColorActivatedObj[] colorObjs;
        

        private IngameScene scene;
        private GameStateService gameState;

        public void Prepare(IngameScene ingameScene)
        {
            gameState = ServiceManager.Get<GameStateService>();

            scene = ingameScene;
            body.Prepare(this);
            move.Prepare(this);
        }

        public void OnGainedPickup()
        {
        }

        public void AnimateInteraction()
        {
            body.AnimateInteraction();
        }

        public void OnTookDamage()
        {
        }

        public void Run()
        {
        }

        public void ResetToCheckpoint(Checkpoint lastCheckpoint)
        {
            move.MoveTo(lastCheckpoint.transform.position);
        }

        public void GiveColor(MoodColor givenColor)
        {
            gameState.OnPlayerGainedColor(givenColor);
            foreach (var obj in colorObjs.Where(x => x.color == givenColor))
            {
                obj.obj.gameObject.SetActive(true);
            }
        }

        public void SnapTo(Vector3 position, Quaternion rotation, Action callback)
        {
            move.SnapTo(position, rotation, callback);
        }

        public void Unsnap()
        {
            move.Unsnap();
        }
    }
}
