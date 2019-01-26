using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AntonioHR.EasyDatabases
{
    public delegate TResult LoadCallback<TResult, TObj>(TObj obj);

    public abstract class EasyDatabase<TObj> : ScriptableObject
    {

        [Serializable]
        private class IdEntry
        {
            public string Id;
            public TObj Value;
        }

        [SerializeField]
        private List<TObj> byTypeEntries;
        [SerializeField]
        private List<IdEntry> byIdEntries;


        public LoadedEasyDatabase<TObj> Load()
        {
            return new LoadedEasyDatabase<TObj>(byTypeEntries.ToDictionary(x => x.GetType()), byIdEntries.ToDictionary(x => x.Id, x => x.Value));
        }


        public LoadedEasyDatabase<TResult> Load<TResult>(LoadCallback<TResult, TObj> creationCallback)
        {
            Dictionary<Type, TResult> byType = byTypeEntries.ToDictionary(x => x.GetType(), x => creationCallback(x));
            Dictionary<string, TResult> byID = byIdEntries.ToDictionary(x => x.Id, x => creationCallback(x.Value));
            return new LoadedEasyDatabase<TResult>(byType, byID);
        }
    }
}