using _Project.Scripts.StaticData;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Obstacles.Spawning
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ObstacleTimerSpawnSystem : ISystem
    {
        private readonly LevelStaticData _levelStaticData;

        private float _timer;
        
        public World World { get; set; }

        public ObstacleTimerSpawnSystem(LevelStaticData levelStaticData)
        {
            _levelStaticData = levelStaticData;
        }

        public void OnAwake()
        {
            _timer = 0f;
        }

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer < _levelStaticData.ObstacleSpawningRate)
                return;

            World.CreateEntity().AddComponent<ObstacleSpawnRequest>();
            _timer = 0f;
        }

        public void Dispose()
        {
        }
    }
}