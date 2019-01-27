
using AntonioHR.HomeColors.Audio;
using AntonioHR.HomeColors.Interactables;
using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.HomeColors
{
    public class IngameScene : GameScene
    {
        [SerializeField]
        private Player player;
        [SerializeField]
        private Checkpoint startingCheckpoint;

        private GameStateService gameState;

        public override void Prepare(ServiceManager serviceManager)
        {
            gameState = serviceManager.GetOrLoadService<GameStateService>();
            serviceManager.GetOrLoadService<ColorsMusicService>();

            player.Prepare(this);
            gameState.CurrentPlayer = player;
            gameState.RegisterCheckpoint(startingCheckpoint);
        }

        public override void Run()
        {
        }
    }
}
