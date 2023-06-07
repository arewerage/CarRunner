using _Project.Scripts.ECS;
using Scellecs.Morpeh;

namespace _Project.Scripts.Infrastructure.Game.States.GameStates
{
    public class GameLoopState : BaseState
    {
        private readonly IEcsWorld _ecsWorld;

        public GameLoopState(IEcsWorld ecsWorld)
        {
            _ecsWorld = ecsWorld;
        }
        
        public override void Enter()
        {
        }

        public override void Exit()
        {
            _ecsWorld.Dispose();
        }

        public override void Tick(float deltaTime)
        {
            _ecsWorld.World.Update(deltaTime);
            _ecsWorld.World.CleanupUpdate(deltaTime);
        }

        public override void FixedTick(float fixedDeltaTime)
        {
            _ecsWorld.World.FixedUpdate(fixedDeltaTime);
        }

        public override void LateTick(float deltaTime)
        {
            _ecsWorld.World.LateUpdate(deltaTime);
        }
    }
}