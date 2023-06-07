using _Project.Scripts.ECS;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.PlayerProgress;
using _Project.Scripts.Services.Pools;
using _Project.Scripts.Services.UI;
using _Project.Scripts.Services.UI.Screens;
using _Project.Scripts.StaticData.UI.Screens;

namespace _Project.Scripts.Infrastructure.Game.States.GameStates
{
    public class InitGameState : BaseState
    {
        private readonly IUIRootProvider _uiRootProvider;
        private readonly IScreenManager _screenManager;
        private readonly IEcsWorld _ecsWorld;
        private readonly ObjectPool<RoadTileEntityView> _roadTilePool;
        private readonly ObjectPool<ObstacleEntityView> _obstaclePool;
        private readonly IPlayerProgressService _playerProgressService;

        public InitGameState(
            IUIRootProvider uiRootProvider,
            IScreenManager screenManager,
            IEcsWorld ecsWorld,
            ObjectPool<RoadTileEntityView> roadTilePool,
            ObjectPool<ObstacleEntityView> obstaclePool,
            IPlayerProgressService playerProgressService)
        {
            _uiRootProvider = uiRootProvider;
            _screenManager = screenManager;
            _ecsWorld = ecsWorld;
            _roadTilePool = roadTilePool;
            _obstaclePool = obstaclePool;
            _playerProgressService = playerProgressService;
        }
        
        public override void Enter()
        {
            _playerProgressService.New();
            _roadTilePool.Initialize();
            _obstaclePool.Initialize();
            _uiRootProvider.Initialize();
            _ecsWorld.Initialize();
            
            _screenManager.Show(ScreenTypeId.HUD);
            
            Game.ChangeState<GameLoopState>();
        }
    }
}