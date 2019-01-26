using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AntonioHR.EasyDatabases
{
    public delegate TResult LoadCallback<TResult, TObj>(TObj obj);

    [Serializable]
    public class IdEntry<T>
    {
        public string Id;
        public T Value;
    }

    public abstract class EasyDatabase<TObj, TEntriesID> : ScriptableObject
        where TEntriesID : IdEntry<TObj>
    {

        [SerializeField]
        private List<TObj> byTypeEntries;
        [SerializeField]
        private List<TEntriesID> byIdEntries;


        public LoadedEasyDatabase<TObj> Load()
        {
            return new LoadedEasyDatabase<TObj>(byTypeEntries.ToDictionary(x => x.GetType()), byIdEntries.ToDictionary(x => x.Id, x => x.Value));
        }


        public LoadedEasyDatabase<TContainer, TObj> Load<TContainer>(LoadCallback<TContainer, TObj> creationCallback)
            where TContainer : IContainer<TObj>
        {
            Dictionary<Type, TContainer> byType = byTypeEntries.ToDictionary(x => x.GetType(), x => creationCallback(x));
            Dictionary<string, TContainer> byID = byIdEntries.ToDictionary(x => x.Id, x => creationCallback(x.Value));
            return new LoadedEasyDatabase<TContainer, TObj>(byType, byID);
        }
    }
}