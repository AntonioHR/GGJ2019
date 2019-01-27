using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Interactables;
using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors.Interactables
{
    class GameWinTrigger : ObjectTrigger<Player>
    {
        private GameStateService gameState;

        protected override void OnTriggered(Player obj)
        {
            obj.Snap();
            gameState.OnGameWon();
        }

        private void Start()
        {
            gameState = ServiceManager.Get<GameStateService>();
        }
    }
}
