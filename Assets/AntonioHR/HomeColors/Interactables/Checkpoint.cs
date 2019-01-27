using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Interactables;
using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonioHR.HomeColors.Interactables
{
    public class Checkpoint : ObjectTrigger<Player>
    {
        GameStateService service;

        private void Start()
        {
            service = ServiceManager.Get<GameStateService>();
        }
        protected override void OnTriggered(Player obj)
        {
            service.RegisterCheckpoint(this);
        }
    }
}
