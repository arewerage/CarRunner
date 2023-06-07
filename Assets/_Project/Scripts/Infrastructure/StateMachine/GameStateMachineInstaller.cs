using _Project.Scripts.Infrastructure.Game.States;
using _Project.Scripts.Infrastructure.Game.States.BootStates;
using Zenject;

namespace _Project.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BaseState>()
                .To(typeof(BootstrapState), typeof(LoadGameState))
                .WhenInjectedInto<GameStateMachine<BaseState, Game.Game>>();
            
            Container.BindInterfacesTo<GameStateMachine<BaseState, Game.Game>>().AsSingle();
        }
    }
}