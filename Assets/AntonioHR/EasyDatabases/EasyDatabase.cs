using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AntonioHR.EasyDatabases
{
    public abstract class ByTypeDatabase<TObj> : ScriptableObject
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


        public LoadedEasyDatabase<TContainer> LoadWithContainers<TContainer>(ContainerCreationCallback<TContainer, TObj> creationCallback)
            where TContainer : IContainer<TObj>
        {
            Dictionary<Type, TContainer> byType = byTypeEntries.ToDictionary(x => x.GetType(), x => creationCallback(x));
            Dictionary<string, TContainer> byID = byIdEntries.ToDictionary(x => x.Id, x => creationCallback(x.Value));
            return new LoadedEasyDatabase<TContainer>(byType, byID);
        }
    }
}