using _Project.Scripts.ECS.Common.Collisions;
using _Project.Scripts.ECS.Score.Increasing;
using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Pools;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Obstacles.Collisions
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ObstacleDestroySystem : ISystem
    {
        private readonly ObjectPool<ObstacleEntityView> _obstaclePool;
        
        private Stash<TriggerEvent> _triggerEventStash;
        private Filter _triggerEvent;
        
        public World World { get; set; }

        public ObstacleDestroySystem(ObjectPool<ObstacleEntityView> obstaclePool)
        {
            _obstaclePool = obstaclePool;
        }

        public void OnAwake()
        {
            _triggerEvent = World.Filter.With<TriggerEvent>();
            _triggerEventStash = World.GetStash<TriggerEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity triggerEventEntity in _triggerEvent)
            {
                ref var triggerEvent = ref _triggerEventStash.Get(triggerEventEntity);
                
                if (triggerEvent.Self.IsNullOrDisposed() || triggerEvent.Other.IsNullOrDisposed())
                    continue;
                
                ref var obstacleView = ref triggerEvent.Self.GetComponent<ViewComponent<ObstacleEntityView>>(out bool selfExist);
                bool otherExist = triggerEvent.Other.Has<ViewComponent<PlayerEntityView>>();

                if (selfExist == false && otherExist == false)
                    continue;
                
                _obstaclePool.ReturnElement(obstacleView.View);
                World.RemoveEntity(triggerEvent.Self);

                World.CreateEntity().AddComponent<ScoreIncreaseEvent>();
            }
        }

        public void Dispose()
        {
        }
    }
}