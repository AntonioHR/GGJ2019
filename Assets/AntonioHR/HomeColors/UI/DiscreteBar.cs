using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AntonioHR.HomeColors.UI
{
    public class DiscreteBar : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;

        private List<GameObject> activeIndicators = new List<GameObject>();

        private GameStateService stateService;

        private void Start()
        {
            stateService = ServiceManager.Get<GameStateService>();

            stateService.HealthChanged += (_, val) => SetValue(val);
            SetValue(stateService.Health);
        }

        public void SetValue(int value)
        {
            while(value > activeIndicators.Count)
            {
                activeIndicators.Add(GameObject.Instantiate(prefab, transform));
            }

            while (value < activeIndicators.Count)
            {
                var index = activeIndicators.Count - 1;
                Destroy(activeIndicators[index]);
                activeIndicators.RemoveAt(index);
            }
        }
    }
}
