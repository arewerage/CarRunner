using _Project.Scripts.UI;

namespace _Project.Scripts.Services.UI
{
    public interface IUIRootProvider
    {
        UIRoot UIRoot { get; }

        void Initialize();
    }
}