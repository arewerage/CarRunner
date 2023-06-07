using _Project.Scripts.ECS.Common.Movement;
using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Extensions;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Pools;
using _Project.Scripts.StaticData;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Project.Scripts.ECS.Obstacles.Spawning
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ObstacleSpawnSystem : ISystem
    {
        private const float SpawnPositionZ = 80f;

        private readonly LevelStaticData _levelStaticData;
        private readonly ObjectPool<ObstacleEntityView> _obstaclePool;
        
        private Filter _obstacleSpawnRequest;
        
        public World World { get; set; }

        public ObstacleSpawnSystem(
            LevelStaticData levelStaticData,
            ObjectPool<ObstacleEntityView> obstaclePool)
        {
            _levelStaticData = levelStaticData;
            _obstaclePool = obstaclePool;
        }

        public void OnAwake()
        {
            _obstacleSpawnRequest = World.Filter.With<ObstacleSpawnRequest>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity request in _obstacleSpawnRequest)
            {
                SpawnObstacle();
                
                World.RemoveEntity(request);
            }
        }

        public void Dispose()
        {
        }

        private void SpawnObstacle()
        {
            RoadLineTypeId roadLineTypeId = EnumExtensions.Random<RoadLineTypeId>();
            ObstacleEntityView obstacleEntityView = _obstaclePool.GetElement();

            Entity obstacleEntity = World.CreateEntity();
            obstacleEntity.SetComponent(new ViewComponent<ObstacleEntityView> { View = obstacleEntityView, ConnectedEntity = obstacleEntity });
            obstacleEntity.SetComponent(new TransformComponent { Value = obstacleEntityView.transform });
            obstacleEntity.SetComponent(new VelocityComponent { Value = Vector3.back });
            obstacleEntity.SetComponent(new SpeedComponent { Value = _levelStaticData.Speed });
            obstacleEntity.AddComponent<TranslationComponent>();

            float offset = _levelStaticData.GetRoadLineData(roadLineTypeId).OffsetX;
            obstacleEntityView.transform.position = Vector3.forward * SpawnPositionZ + Vector3.right * offset;
            
            CollisionDetector detector = obstacleEntityView.gameObject.AddComponent<CollisionDetector>();
            detector.Initialize(World, obstacleEntity);
        }
    }
}