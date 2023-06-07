using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Common.Collisions
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ClearTriggerEventSystem : ILateSystem
    {
        private Filter _triggerEnterEvent;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _triggerEnterEvent = World.Filter.With<TriggerEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity enterEvent in _triggerEnterEvent)
            {
                enterEvent.RemoveComponent<TriggerEvent>();
                World.RemoveEntity(enterEvent);
            }
        }

        public void Dispose()
        {
        }
    }
}