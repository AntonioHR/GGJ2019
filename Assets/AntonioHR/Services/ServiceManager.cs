using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.Services
{
    public class ServiceManager : MonoBehaviour
    {
        private static ServiceManager instance;
        public static ServiceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("[ServiceManager]").AddComponent<ServiceManager>();
                    instance.Prepare();
                    DontDestroyOnLoad(instance);
                }
                return instance;
            }
        }

        private class Entry : IContainer<Service>
        {
            private Service prefab;

            public Service Value
            {
                get { return prefab; }
            }
        }

        private void Prepare()
        {
            var db = Resources.Load<ServicesDB>("Services");

            
        }
    }
}