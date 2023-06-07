using _Project.Scripts.ECS.UnityComponents;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Common.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class MovementSystem : ISystem
    {
        private Stash<VelocityComponent> _velocityStash;
        private Stash<SpeedComponent> _speedStash;
        private Stash<TransformComponent> _transformStash;
        private Filter _roadTiles;

        public World World { get; set; }

        public void OnAwake()
        {
            _velocityStash = World.GetStash<VelocityComponent>();
            _speedStash = World.GetStash<SpeedComponent>();
            _transformStash = World.GetStash<TransformComponent>();
            _roadTiles = World.Filter.With<VelocityComponent>().With<SpeedComponent>()
                .With<TransformComponent>().With<TranslationComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity roadTile in _roadTiles)
            {
                ref var velocity = ref _velocityStash.Get(roadTile);
                ref var speed = ref _speedStash.Get(roadTile);
                ref var transform = ref _transformStash.Get(roadTile);
                
                transform.Value.Translate(velocity.Value * (speed.Value * deltaTime));
            }
        }

        public void Dispose()
        {
        }
    }
}