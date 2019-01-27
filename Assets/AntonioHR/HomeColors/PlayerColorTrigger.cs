using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace AntonioHR.HomeColors
{
    public class PlayerColorTrigger : MonoBehaviour
    {
        private GameStateService stateService;

        [SerializeField]
        public UnityEvent trigger;
        [SerializeField]
        private MoodColor color;

        private void Start()
        {
            stateService = ServiceManager.Get<GameStateService>();
            stateService.PlayerGainedColor += PlayerGainedColors;
        }

        private void PlayerGainedColors(MoodColor obj)
        {
            if (obj == color)
                trigger.Invoke();
        }
    }
}
