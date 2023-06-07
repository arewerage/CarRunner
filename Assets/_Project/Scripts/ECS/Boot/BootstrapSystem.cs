using _Project.Scripts.ECS.Level.Generation;
using _Project.Scripts.ECS.Player.Spawning;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Boot
{
    using Scellecs.Morpeh;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class BootstrapSystem : IInitializer
    {
        public World World { get; set; }

        public void OnAwake()
        {
            World.CreateEntity().AddComponent<LastRoadTileComponent>();
            World.CreateEntity().AddComponent<LevelGenerateRequest>();
            World.CreateEntity().AddComponent<PlayerSpawnRequest>();
        }

        public void Dispose()
        {
        }
    }
}