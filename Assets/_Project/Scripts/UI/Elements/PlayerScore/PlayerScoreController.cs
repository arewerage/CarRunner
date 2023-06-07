using _Project.Scripts.Services.PlayerProgress;
using UniRx;
using Zenject;

namespace _Project.Scripts.UI.Elements.PlayerScore
{
    public class PlayerScoreController : IInitializable
    {
        private readonly PlayerScoreView _view;
        private readonly IPlayerProgressService _playerProgressService;

        public PlayerScoreController(PlayerScoreView view, IPlayerProgressService playerProgressService)
        {
            _view = view;
            _playerProgressService = playerProgressService;
        }
        
        public void Initialize()
        {
            _playerProgressService.Progress.Score
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(x => _view.ScoreText.SetText(x.ToString()))
                .AddTo(_view);
        }
    }
}