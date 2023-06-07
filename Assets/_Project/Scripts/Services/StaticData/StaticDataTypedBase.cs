using System;
using UnityEngine;

namespace _Project.Scripts.Services.StaticData
{
    public abstract class StaticDataTypedBase<TTypeId> : ScriptableObject
        where TTypeId : Enum
    {
        [SerializeField] protected TTypeId _typeId;

        public TTypeId TypeId => _typeId;
    }
}