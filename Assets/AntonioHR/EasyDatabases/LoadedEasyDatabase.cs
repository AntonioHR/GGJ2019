using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AntonioHR.EasyDatabases
{
    public class LoadedEasyDatabase<TObj> : ScriptableObject
    {
        private Dictionary<Type, TObj> byTypeEntries;
        private Dictionary<string, TObj> byIdEntries;

        public LoadedEasyDatabase(Dictionary<Type, TObj> byTypeEntries, Dictionary<string, TObj> byIdEntries)
        {
            this.byTypeEntries = byTypeEntries;
            this.byIdEntries = byIdEntries;
        }


        public T Get<T>() where T: TObj
        {
            return (T)byTypeEntries[typeof(T)];
        }


        public T Get<T>(string id) where T : TObj
        {
            return (T)byIdEntries[id];
        }

        public TObj Get(string id)
        {
            return byIdEntries[id];
        }
    }



    public class LoadedEasyDatabase<TContainer, TObj> : ScriptableObject
        where TContainer : IContainer<TObj>
    {
        private Dictionary<Type, TContainer> byTypeEntries;
        private Dictionary<string, TContainer> byIdEntries;

        public LoadedEasyDatabase(Dictionary<Type, TContainer> byTypeEntries, Dictionary<string, TContainer> byIdEntries)
        {
            this.byTypeEntries = byTypeEntries;
            this.byIdEntries = byIdEntries;
        }


        public TContainer Get<T>() where T : TObj
        {
            return byTypeEntries[typeof(T)];
        }


        public TContainer Get<T>(string id) where T : TObj
        {
            return byIdEntries[id];
        }

        public TContainer Get(string id)
        {
            return byIdEntries[id];
        }
    }
}