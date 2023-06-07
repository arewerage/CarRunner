using _Project.Scripts.Infrastructure.StateMachine;

namespace _Project.Scripts.Infrastructure.Game.States
{
    public abstract class BaseState : IState<Game>
    {
        protected Game Game { get; private set; }

        public void OnEnter(Game context)
        {
            Game = context;
            Enter();
        }
        
        public virtual void Enter() {}
        public virtual void Exit() {}
        public virtual void Tick(float deltaTime) {}
        public virtual void FixedTick(float fixedDeltaTime) {}
        public virtual void LateTick(float deltaTime) {}
        public virtual void Restart() {}
    }
}