namespace _Project.Scripts.Infrastructure.StateMachine
{
    public interface IState<in TContext> where TContext : class
    {
        void OnEnter(TContext context);
        void Exit();
    }
}