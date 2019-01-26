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
}