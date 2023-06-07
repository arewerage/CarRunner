using System;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS
{
    public interface IEcsWorld : IDisposable
    {
        World World { get; }

        void Initialize(bool updateByUnity = true);
    }
}