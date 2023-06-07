using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Pools;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Obstacles.Pooling
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ObstacleResetSystem : IFixedSystem
    {
        private const float ResetPosition = -40f;
        
        private readonly ObjectPool<ObstacleEntityView> _obstaclePool;
        
        private Stash<TransformComponent> _transformStash;
        private Stash<ViewComponent<ObstacleEntityView>> _obstacleEntityStash;
        private Filter _obstacles;
        
        public World World { get; set; }

        public ObstacleResetSystem(ObjectPool<ObstacleEntityView> obstaclePool)
        {
            _obstaclePool = obstaclePool;
        }

        public void OnAwake()
        {
            _obstacles = World.Filter.With<ViewComponent<ObstacleEntityView>>().With<TransformComponent>();
            _transformStash = World.GetStash<TransformComponent>();
            _obstacleEntityStash = World.GetStash<ViewComponent<ObstacleEntityView>>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity obstacle in _obstacles)
            {
                ref var transform = ref _transformStash.Get(obstacle);

                if (transform.Value.position.z < ResetPosition)
                {
                    ref var view = ref _obstacleEntityStash.Get(obstacle);
                    
                    _obstaclePool.ReturnElement(view.View);
                    World.RemoveEntity(obstacle);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}