﻿using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Project.Scripts.ECS.UnityComponents
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct ViewComponent<T> : IComponent where T : Component
    {
        public T View;
        public Entity ConnectedEntity;
    }
}