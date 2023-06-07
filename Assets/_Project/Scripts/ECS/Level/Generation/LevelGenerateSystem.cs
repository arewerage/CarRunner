using _Project.Scripts.ECS.Common.Movement;
using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Pools;
using _Project.Scripts.StaticData;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Project.Scripts.ECS.Level.Generation
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class LevelGenerateSystem : ISystem
    {
        private readonly LevelStaticData _levelStaticData;
        private readonly ObjectPool<RoadTileEntityView> _roadTilePool;

        private Stash<TransformComponent> _transformStash;
        private Filter _levelGenerateRequest;
        private Filter _lastRoadTile;
        
        public World World { get; set; }

        public LevelGenerateSystem(
            LevelStaticData levelStaticData,
            ObjectPool<RoadTileEntityView> roadTilePool)
        {
            _levelStaticData = levelStaticData;
            _roadTilePool = roadTilePool;
        }

        public void OnAwake()
        {
            _levelGenerateRequest = World.Filter.With<LevelGenerateRequest>();
            _lastRoadTile = World.Filter.With<LastRoadTileComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity request in _levelGenerateRequest)
            foreach (Entity lastRoadTileEntity in _lastRoadTile)
            {
                for (int i = 0; i < _levelStaticData.MaxRoadTiles; i++)
                    GenerateTile(i, lastRoadTileEntity);
                
                World.RemoveEntity(request);
            }
        }

        public void Dispose()
        {
        }

        private void GenerateTile(int index, Entity lastRoadTransform)
        {
            RoadTileEntityView roadTileEntityView = _roadTilePool.GetElement();

            Entity roadTileEntity = World.CreateEntity();
            roadTileEntity.SetComponent(new ViewComponent<RoadTileEntityView> { View = roadTileEntityView, ConnectedEntity = roadTileEntity });
            roadTileEntity.SetComponent(new TransformComponent { Value = roadTileEntityView.transform });
            roadTileEntity.SetComponent(new VelocityComponent { Value = Vector3.back });
            roadTileEntity.SetComponent(new SpeedComponent { Value = _levelStaticData.Speed });
            roadTileEntity.AddComponent<TranslationComponent>();

            roadTileEntityView.transform.position = Vector3.forward * (index * _levelStaticData.TilingOffsetZ);
            lastRoadTransform.SetComponent(new TransformComponent { Value = roadTileEntityView.transform });
        }
    }
}