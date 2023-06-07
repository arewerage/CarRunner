using _Project.Scripts.ECS.Obstacles.Collisions;
using _Project.Scripts.ECS.Obstacles.Pooling;
using _Project.Scripts.ECS.Obstacles.Spawning;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Pools;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS.Obstacles
{
    public class ObstacleFeature : IEcsFeature
    {
        private readonly IStaticDataProvider<LevelStaticData> _levelStaticData;
        private readonly ObjectPool<ObstacleEntityView> _obstaclePool;

        public ObstacleFeature(
            IStaticDataProvider<LevelStaticData> levelStaticData,
            ObjectPool<ObstacleEntityView> obstaclePool)
        {
            _levelStaticData = levelStaticData;
            _obstaclePool = obstaclePool;
        }
        
        public void InitializeFeature(SystemsGroup systemsGroup)
        {
            LevelStaticData levelStaticData = _levelStaticData.Get();

            systemsGroup.AddSystem(new ObstacleSpawnSystem(levelStaticData, _obstaclePool));
            systemsGroup.AddSystem(new ObstacleTimerSpawnSystem(levelStaticData));
            systemsGroup.AddSystem(new ObstacleResetSystem(_obstaclePool));
            systemsGroup.AddSystem(new ObstacleDestroySystem(_obstaclePool));
        }
    }
}