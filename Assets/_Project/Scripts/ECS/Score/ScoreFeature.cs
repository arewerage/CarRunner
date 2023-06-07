using _Project.Scripts.ECS.Score.Increasing;
using _Project.Scripts.Services.PlayerProgress;
using Scellecs.Morpeh;

namespace _Project.Scripts.ECS.Score
{
    public class ScoreFeature : IEcsFeature
    {
        private readonly IPlayerProgressService _playerProgressService;

        public ScoreFeature(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }
        
        public void InitializeFeature(SystemsGroup systemsGroup)
        {
            systemsGroup.AddSystem(new ScoreIncreaseSystem(_playerProgressService));
        }
    }
}