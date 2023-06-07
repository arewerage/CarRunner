using System.Collections.Generic;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS
{
    public class EcsWorld : IEcsWorld
    {
        private readonly IEnumerable<IEcsFeature> _ecsFeatures;

        private SystemsGroup _systemsGroup;

        public World World { get; }

        public EcsWorld(IEnumerable<IEcsFeature> ecsFeatures)
        {
            World = World.Default;
            _ecsFeatures = ecsFeatures;
        }

        public void Initialize(bool updateByUnity = false)
        {
            World.UpdateByUnity = updateByUnity;
            _systemsGroup = World.CreateSystemsGroup();

            foreach (IEcsFeature ecsFeature in _ecsFeatures)
                ecsFeature.InitializeFeature(_systemsGroup);
            
            World.AddSystemsGroup(0, _systemsGroup);
        }

        public void Dispose()
        {
            World.RemoveSystemsGroup(_systemsGroup);
            _systemsGroup?.Dispose();
        }
    }
}