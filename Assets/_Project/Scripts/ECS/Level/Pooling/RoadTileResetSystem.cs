using _Project.Scripts.ECS.Level.Generation;
using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Mono;
using _Project.Scripts.StaticData;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Project.Scripts.ECS.Level.Pooling
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class RoadTileResetSystem : IFixedSystem
    {
        private const float ResetPosition = -40f;
        
        private readonly LevelStaticData _levelStaticData;
        
        private Stash<TransformComponent> _transformStash;
        private Filter _roadTiles;
        private Filter _lastRoadTiles;
        
        public World World { get; set; }

        public RoadTileResetSystem(LevelStaticData levelStaticData)
        {
            _levelStaticData = levelStaticData;
        }

        public void OnAwake()
        {
            _roadTiles = World.Filter.With<ViewComponent<RoadTileEntityView>>().With<TransformComponent>();
            _lastRoadTiles = World.Filter.With<LastRoadTileComponent>().With<TransformComponent>();
            _transformStash = World.GetStash<TransformComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity roadTile in _roadTiles)
            {
                ref var transform = ref _transformStash.Get(roadTile);

                if (transform.Value.position.z < ResetPosition)
                {
                    ref var lastTransform = ref _transformStash.Get(_lastRoadTiles.First());

                    Vector3 offset = Vector3.forward * _levelStaticData.TilingOffsetZ;
                    transform.Value.position = lastTransform.Value.position;
                    lastTransform.Value.position = transform.Value.position + offset;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}