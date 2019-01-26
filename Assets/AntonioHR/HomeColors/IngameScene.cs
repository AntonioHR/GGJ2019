using AntonioHR.HomeColors.Player;
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
        private PlayerMovement player;


        public override void Prepare(ServiceManager serviceManager)
        {
            serviceManager.GetOrLoadService<GameStateService>();
        }

        public override void Run()
        {
            player.OnGameStarted();
        }
    }
}
