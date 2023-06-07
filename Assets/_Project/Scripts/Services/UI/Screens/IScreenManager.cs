using _Project.Scripts.StaticData.UI.Screens;

namespace _Project.Scripts.Services.UI.Screens
{
    public interface IScreenManager
    {
        void Show(ScreenTypeId typeId);
    }
}