using _Project.Scripts.ECS;
using _Project.Scripts.Infrastructure.Game;
using _Project.Scripts.Infrastructure.Game.States;
using _Project.Scripts.Infrastructure.Game.States.GameStates;
using _Project.Scripts.Infrastructure.StateMachine;
using _Project.Scripts.Mono;
using _Project.Scripts.Services.Factories;
using _Project.Scripts.Services.Pools;
using _Project.Scripts.Services.UI;
using _Project.Scripts.Services.UI.Factories;
using _Project.Scripts.Services.UI.Screens;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PoolData<RoadTileEntityView> _roadTilePoolData;
        [SerializeField] private PoolData<ObstacleEntityView> _obstaclePoolData;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MonoFactory<UIRoot>>().AsSingle();
            Container.BindInterfacesTo<UIRootProvider>().AsSingle();
            Container.BindInterfacesTo<ScreenFactory>().AsSingle();
            Container.BindInterfacesTo<ScreenManager>().AsSingle();
            Container.BindInterfacesTo<MonoFactory<PlayerEntityView>>().AsSingle();
            
            InstallPools();
            EcsInstaller.Install(Container);
            
            InstallStateInjector();
        }

        private void InstallPools()
        {
            Container.BindInstance(_roadTilePoolData).WhenInjectedInto<ObjectPool<RoadTileEntityView>>();
            Container.BindInterfacesTo<MonoPoolFactory<RoadTileEntityView>>()
                .WhenInjectedInto<ObjectPool<RoadTileEntityView>>();
            Container.Bind<ObjectPool<RoadTileEntityView>>().AsSingle();

            Container.BindInstance(_obstaclePoolData).WhenInjectedInto<ObjectPool<ObstacleEntityView>>();
            Container.BindInterfacesTo<MonoPoolFactory<ObstacleEntityView>>()
                .WhenInjectedInto<ObjectPool<ObstacleEntityView>>();
            Container.Bind<ObjectPool<ObstacleEntityView>>().AsSingle();
        }

        private void InstallStateInjector()
        {
            Container.Bind<BaseState>()
                .To(typeof(InitGameState), typeof(GameLoopState))
                .WhenInjectedInto<SceneStateInjector<BaseState, Game>>();

            Container.BindInterfacesTo<SceneStateInjector<BaseState, Game>>().AsSingle();
        }
    }
}