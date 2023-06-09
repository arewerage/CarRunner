﻿using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Common.Collisions
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct TriggerEvent : IComponent
    {
        public Entity Self;
        public Entity Other;
    }
}