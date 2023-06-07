using _Project.Scripts.Infrastructure.Game.States;
using _Project.Scripts.Infrastructure.Game.States.BootStates;
using _Project.Scripts.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Game
{
    public class Game : IGame, IInitializable, ITickable, IFixedTickable, ILateTickable
    {
        private readonly IStateMachine<BaseState, Game> _stateMachine;

        public Game(IStateMachine<BaseState, Game> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        /// <summary>
        /// Entry point
        /// </summary>
        public void Initialize()
        {
            ChangeState<BootstrapState>();
        }

        public void Tick()
        {
            _stateMachine.CurrentState.Tick(Time.deltaTime);
        }

        public void FixedTick()
        {
            _stateMachine.CurrentState.FixedTick(Time.fixedDeltaTime);
        }

        public void LateTick()
        {
            _stateMachine.CurrentState.LateTick(Time.deltaTime);
        }

        public void Restart()
        {
            _stateMachine.CurrentState.Restart();
        }

        public void ChangeState<TState>() where TState : BaseState
        {
            _stateMachine.ChangeState<TState>(this);
        }
    }
}