namespace _Project.Scripts.Services.PlayerProgress
{
    public class PlayerProgressService : IPlayerProgressService
    {
        public Data.PlayerProgress Progress { get; private set; }

        public void New()
        {
            Progress = new Data.PlayerProgress();
        }
    }
}