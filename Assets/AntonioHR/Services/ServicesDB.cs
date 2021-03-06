﻿using AntonioHR.EasyDatabases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntonioHR.Services
{
    [CreateAssetMenu(menuName ="AntonioHR/Services/Database")]
    public class ServicesDB : EasyDatabase<Service, ServicesDB.IdEntry>
    {
        [Serializable]
        public class IdEntry : IdEntry<Service> { }

    }
}
