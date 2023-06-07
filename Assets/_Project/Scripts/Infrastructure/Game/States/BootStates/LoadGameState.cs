using _Project.Scripts.Constants;
using _Project.Scripts.Infrastructure.Game.States.GameStates;
using _Project.Scripts.Services.Scenes;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using _Project.Scripts.StaticData.UI.Screens;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.Game.States.BootStates
{
    public class LoadGameState : BaseState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataProvider<LevelStaticData> _levelStaticData;
        private readonly IStaticDataProvider<PlayerStaticData> _playerStaticData;
        private readonly IStaticDataProvider<ScreenTypeId, ScreenStaticData> _screenStaticData;

        public LoadGameState(
            ISceneLoader sceneLoader,
            IStaticDataProvider<LevelStaticData> levelStaticData,
            IStaticDataProvider<PlayerStaticData> playerStaticData,
            IStaticDataProvider<ScreenTypeId, ScreenStaticData> screenStaticData)
        {
            _sceneLoader = sceneLoader;
            _levelStaticData = levelStaticData;
            _playerStaticData = playerStaticData;
            _screenStaticData = screenStaticData;
        }

        public override void Enter()
        {
            _levelStaticData.Load(StaticDataAddress.Level);
            _playerStaticData.Load(StaticDataAddress.Player);
            _screenStaticData.LoadAll(StaticDataAddress.Screens);
            
            EnterAsync().Forget();
        }

        private async UniTaskVoid EnterAsync()
        {
            await _sceneLoader.LoadAsync(SceneAddress.Game);
            
            Game.ChangeState<InitGameState>();
        }
    }
}