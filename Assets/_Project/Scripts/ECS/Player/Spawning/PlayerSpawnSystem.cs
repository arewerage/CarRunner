using _Project.Scripts.Constants;
using _Project.Scripts.ECS.Common.Movement;
using _Project.Scripts.ECS.Player.Movement;
using _Project.Scripts.ECS.UnityComponents;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Factories;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Player.Spawning
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class PlayerSpawnSystem : ISystem
    {
        private readonly IFactory<string, PlayerEntityView> _playerFactory;
        private readonly IStaticDataProvider<PlayerStaticData> _playerStaticData;

        private Filter _playerSpawnRequest;
        
        public World World { get; set; }

        public PlayerSpawnSystem(
            IFactory<string, PlayerEntityView> playerFactory,
            IStaticDataProvider<PlayerStaticData> playerStaticData)
        {
            _playerFactory = playerFactory;
            _playerStaticData = playerStaticData;
        }

        public void OnAwake()
        {
            _playerSpawnRequest = World.Filter.With<PlayerSpawnRequest>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (Entity request in _playerSpawnRequest)
            {
                SpawnPlayer();
                
                World.RemoveEntity(request);
            }
        }

        public void Dispose()
        {
        }

        private void SpawnPlayer()
        {
            PlayerStaticData staticData = _playerStaticData.Get();
            PlayerEntityView playerEntityView = _playerFactory.Create(PrefabAddress.PlayerCar);

            Entity player = World.CreateEntity();
            player.SetComponent(new ViewComponent<PlayerEntityView> { View = playerEntityView, ConnectedEntity = player });
            player.SetComponent(new RigidbodyComponent { Value = playerEntityView.Body });
            player.SetComponent(new RoadLineComponent { Current = RoadLineTypeId.Middle, Target = RoadLineTypeId.Middle });
            player.SetComponent(new SlidingTimeComponent { Value = staticData.HorizontalSlidingTime });
            player.SetComponent(new VelocityComponent());

            CollisionDetector detector = playerEntityView.gameObject.AddComponent<CollisionDetector>();
            detector.Initialize(World, player);
        }
    }
}