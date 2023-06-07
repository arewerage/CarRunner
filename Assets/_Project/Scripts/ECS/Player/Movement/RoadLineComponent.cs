using System;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Player.Movement
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct RoadLineComponent : IComponent
    {
        public RoadLineTypeId Current;
        public RoadLineTypeId Target;
    }
}