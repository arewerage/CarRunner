using _Project.Scripts.Infrastructure.Game;
using _Project.Scripts.Infrastructure.StateMachine;
using _Project.Scripts.Services.Input;
using _Project.Scripts.Services.PlayerProgress;
using _Project.Scripts.Services.Scenes;
using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData;
using _Project.Scripts.StaticData.UI.Screens;
using Zenject;

namespace _Project.Scripts.CompositionRoot
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputService>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<StaticDataProvider<LevelStaticData>>().AsSingle();
            Container.BindInterfacesTo<StaticDataProvider<PlayerStaticData>>().AsSingle();
            Container.BindInterfacesTo<StaticDataProvider<ScreenTypeId, ScreenStaticData>>().AsSingle();
            Container.BindInterfacesTo<PlayerProgressService>().AsSingle();
            
            GameStateMachineInstaller.Install(Container);

            Container.BindInterfacesTo<Game>().AsSingle();
        }
    }
}