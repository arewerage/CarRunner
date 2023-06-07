namespace _Project.Scripts.Services.PlayerProgress
{
    public interface IPlayerProgressService
    {
        Data.PlayerProgress Progress { get; }
        
        void New();
    }
}