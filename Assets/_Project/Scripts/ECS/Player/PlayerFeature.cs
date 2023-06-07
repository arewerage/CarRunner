using _Project.Scripts.ECS.Player.Movement;
using _Project.Scripts.ECS.Player.Spawning;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Factories;
using _Project.Scripts.Services.Input;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS.Player
{
    public class PlayerFeature : IEcsFeature
    {
        private readonly IInputService _inputService;
        private readonly IFactory<string, PlayerEntityView> _playerFactory;
        private readonly IStaticDataProvider<PlayerStaticData> _playerStaticData;
        private readonly IStaticDataProvider<LevelStaticData> _levelStaticData;

        public PlayerFeature(
            IInputService inputService,
            IFactory<string, PlayerEntityView> playerFactory,
            IStaticDataProvider<PlayerStaticData> playerStaticData,
            IStaticDataProvider<LevelStaticData> levelStaticData)
        {
            _inputService = inputService;
            _playerFactory = playerFactory;
            _playerStaticData = playerStaticData;
            _levelStaticData = levelStaticData;
        }
        
        public void InitializeFeature(SystemsGroup systemsGroup)
        {
            systemsGroup.AddSystem(new PlayerSpawnSystem(_playerFactory, _playerStaticData));
            systemsGroup.AddSystem(new PlayerInputSystem(_inputService));
            systemsGroup.AddSystem(new PlayerDriveRoadLineSystem(_levelStaticData));
        }
    }
}