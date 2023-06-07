using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Services.StaticData
{
    public class StaticDataProvider<TStaticData> : IStaticDataProvider<TStaticData>
        where TStaticData : ScriptableObject
    {
        private TStaticData _staticData;
        
        public void Load(string path)
        {
            _staticData = Resources.Load<TStaticData>(path);
        }

        public TStaticData Get()
        {
            return _staticData;
        }
    }

    public class StaticDataProvider<TTypeId, TStaticData> : IStaticDataProvider<TTypeId, TStaticData>
        where TTypeId : Enum
        where TStaticData : StaticDataTypedBase<TTypeId>
    {
        private Dictionary<TTypeId, TStaticData> _staticData;

        public void LoadAll(string folder)
        {
            _staticData = Resources.LoadAll<TStaticData>(folder).ToDictionary(x => x.TypeId, x => x);
        }

        public TStaticData Get(TTypeId typeId)
        {
            return _staticData.TryGetValue(typeId, out TStaticData staticData) ? staticData : null;
        }
    }
}