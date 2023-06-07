using _Project.Scripts.Constants;
using _Project.Scripts.Services.Factories;
using _Project.Scripts.UI;

namespace _Project.Scripts.Services.UI
{
    public class UIRootProvider : IUIRootProvider
    {
        private readonly IFactory<string, UIRoot> _factory;

        public UIRootProvider(IFactory<string, UIRoot> factory)
        {
            _factory = factory;
        }
        
        public UIRoot UIRoot { get; private set; }
        
        public void Initialize()
        {
            if (UIRoot != null)
                return;

            UIRoot = _factory.Create(PrefabAddress.UIRoot);
        }
    }
}