using _Project.Scripts.ECS.Level.Generation;
using _Project.Scripts.ECS.Level.Pooling;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Pools;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS.Level
{
    public class LevelFeature : IEcsFeature
    {
        private readonly IStaticDataProvider<LevelStaticData> _levelStaticData;
        private readonly ObjectPool<RoadTileEntityView> _roadTilePool;

        public LevelFeature(
            IStaticDataProvider<LevelStaticData> levelStaticData,
            ObjectPool<RoadTileEntityView> roadTilePool)
        {
            _levelStaticData = levelStaticData;
            _roadTilePool = roadTilePool;
        }
        
        public void InitializeFeature(SystemsGroup systemsGroup)
        {
            LevelStaticData levelStaticData = _levelStaticData.Get();
            
            systemsGroup.AddSystem(new LevelGenerateSystem(levelStaticData, _roadTilePool));
            systemsGroup.AddSystem(new RoadTileResetSystem(levelStaticData));
        }
    }
}