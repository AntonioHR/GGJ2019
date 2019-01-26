using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.Services
{
    public abstract class GameScene : MonoBehaviour
    {
        public abstract void Prepare(ServiceManager serviceManager);
        public abstract void Run();

    }
}
