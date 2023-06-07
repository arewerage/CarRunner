namespace _Project.Scripts.Infrastructure.Game.States.BootStates
{
    public class BootstrapState : BaseState
    {
        public override void Enter()
        {
            Game.ChangeState<LoadGameState>();
        }
    }
}