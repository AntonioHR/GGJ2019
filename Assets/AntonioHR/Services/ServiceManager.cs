﻿using System;
using System.Collections;
using System.Collections.Generic;
using AntonioHR.EasyDatabases;
using UnityEngine;

namespace AntonioHR.Services
{
    public class ServiceManager : MonoBehaviour
    {
        private static ServiceManager instance = null;

        public static ServiceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    new GameObject("[ServiceManager]").AddComponent<ServiceManager>();
                    instance.Prepare();
                    DontDestroyOnLoad(instance);
                }
                return instance;
            }
        }

        private class Entry : IContainer<Service>
        {
            private Service prefab;
            private ServiceManager owner;

            public Entry(Service prefab, ServiceManager owner)
            {
                this.prefab = prefab;
                this.owner = owner;
            }

            public Service Service { get; private set; }
            

            public bool IsLoaded { get { return Service != null; } }

            public Service Value
            {
                get { return prefab; }
            }

            public void Load()
            {
                Service = GameObject.Instantiate(prefab, owner.transform);
            }

        }



        private LoadedEasyDatabase<Entry, Service> db;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                GameObject.Destroy(this);
        }

        private void Prepare()
        {
            var db = Resources.Load<ServicesDB>("Services");
            this.db = db.Load<Entry>(prefab => new Entry(prefab, this));
        }
        

        public T GetOrLoadService<T>(Action<T> onLoadedCallback = null) where T : Service
        {
            var entry = db.Get<T>();

            if (entry.IsLoaded)
                return (T)entry.Service;
            else
            {
                entry.Load();
                T result = (T)entry.Service;
                if(onLoadedCallback != null)
                    onLoadedCallback(result);
                result.Init();
                return result;
            }
        }


        public static T Get<T>() where T : Service
        {
            return instance.GetOrLoadService<T>(null);
        }
    }
}