using _Project.Scripts.Services.StaticData;
using _Project.Scripts.StaticData.UI.Screens;
using _Project.Scripts.UI.Screens;
using Zenject;

namespace _Project.Scripts.Services.UI.Factories
{
    public class ScreenFactory : Services.Factories.IFactory<ScreenTypeId, BaseScreen>
    {
        private readonly IInstantiator _instantiator;
        private readonly IUIRootProvider _uiRootProvider;
        private readonly IStaticDataProvider<ScreenTypeId, ScreenStaticData> _screenStaticData;

        public ScreenFactory(
            IInstantiator instantiator,
            IUIRootProvider uiRootProvider,
            IStaticDataProvider<ScreenTypeId, ScreenStaticData> screenStaticData)
        {
            _instantiator = instantiator;
            _uiRootProvider = uiRootProvider;
            _screenStaticData = screenStaticData;
        }
        
        public BaseScreen Create(ScreenTypeId typeId)
        {
            ScreenStaticData staticData = _screenStaticData.Get(typeId);
            return _instantiator.InstantiatePrefabForComponent<BaseScreen>(staticData.Prefab, _uiRootProvider.UIRoot.transform);
        }
    }
}