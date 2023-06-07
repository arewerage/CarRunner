using _Project.Scripts.UI.Elements.PlayerScore;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Screens.HUD
{
    public class HUDScreenInstaller : MonoInstaller
    {
        [SerializeField] private PlayerScoreView _playerScoreView;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_playerScoreView).AsSingle();
            Container.BindInterfacesTo<PlayerScoreController>().AsSingle();
        }
    }
}