using _Project.Scripts.Services.PlayerProgress;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Project.Scripts.ECS.Score.Increasing
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class ScoreIncreaseSystem : ISystem
    {
        private readonly IPlayerProgressService _playerProgressService;
        
        private Filter _scoreIncreaseEvent;
        
        public World World { get; set; }

        public ScoreIncreaseSystem(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        public void OnAwake()
        {
            _scoreIncreaseEvent = World.Filter.With<ScoreIncreaseEvent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity scoreIncreaseEntity in _scoreIncreaseEvent)
            {
                _playerProgressService.Progress.Score.Value += 1;
                
                World.RemoveEntity(scoreIncreaseEntity);
            }
        }

        public void Dispose()
        {
        }
    }
}