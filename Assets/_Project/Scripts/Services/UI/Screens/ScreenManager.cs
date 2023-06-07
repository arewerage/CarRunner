using _Project.Scripts.Services.Factories;
using _Project.Scripts.StaticData.UI.Screens;
using _Project.Scripts.UI.Screens;

namespace _Project.Scripts.Services.UI.Screens
{
    public class ScreenManager : IScreenManager
    {
        private readonly IFactory<ScreenTypeId, BaseScreen> _screenFactory;

        public ScreenManager(IFactory<ScreenTypeId, BaseScreen> screenFactory)
        {
            _screenFactory = screenFactory;
        }
        
        public void Show(ScreenTypeId typeId)
        {
            _screenFactory.Create(typeId);
        }
    }
}