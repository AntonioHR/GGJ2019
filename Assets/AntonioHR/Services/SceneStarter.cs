using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.Services
{
    public class SceneStarter : MonoBehaviour
    {
        [SerializeField]
        private GameScene scene;

        private void Start()
        {
            ServiceManager serviceManager = ServiceManager.Instance;

            scene.Prepare();
            scene.Run();
        }
    }
}
